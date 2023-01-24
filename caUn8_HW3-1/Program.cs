using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace caUn8_Hw1_4
{
    internal class Program
    {
        static string UnitName = "Un:8";
        static string UnDescr = "File System Operation";
        static string ExName = "HW-1/4";
        static string ExDescr = "Clear 30min-idle Items";

        static string inFileFullNamelPath;
        //static string inFileName = "Students.dat";
        static string inFilePath = @"D:\WinTemp\SkillFactory\TimeSpan\";

        static string DirPath = @"D:\WinTemp\ТасКом";
        static long TotalFileSize = 0;
        static int Deep = 0;
        static int crDeep = 0;
        static DateTime refTime;
        static double maxTimeGap = 1.0;
        enum checkTimeModes { LastWrite, lastAcsees };
        static checkTimeModes ctMode;
        static protected string UnTitle
        {
            get
            { return UnitName + "[" + UnDescr + "]"; }
        }
        static protected string ExTitle
        {
            get
            { return UnitName + "." + ExName + "[" + ExDescr + "]"; }
        }
        static protected string Promt
        {
            get
            { return UnitName + "." + ExName + ":"; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("{0}:Startig ", ExTitle);
            Console.WriteLine("{0} ", Promt);
            //ctMode = checkTimeModes.LastWrite;
            ctMode = checkTimeModes.lastAcsees;
            iniTimeLine();
            try
            {
                string dPath = GetPath(DirPath);
                if (TestPath(dPath))
                {
                    Console.WriteLine("{0}: DirPath= {1} It's OK.", ExTitle, dPath);
                    TestDir(dPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}: Get Exception.{1}", Promt, ex.Message);
            }
            Console.WriteLine("{0}: Finishing.", ExTitle);
            Console.WriteLine("{0}: Finished. Press key.", UnTitle);
            Console.ReadKey();
        }
        static string GetPath(string inPath)
        {
            //Get working path
            return inPath;
            return inFilePath; //jast from string  const
        }
        static void iniTimeLine()
        {
            refTime = DateTime.Now;
            Console.WriteLine("{0} refTime={1}; maxTimeGap={2} ", Promt, refTime, maxTimeGap);
        }
        static void TestDir(string inPath)
        {
            TestDirFiles(inPath, ctMode);
            DirectoryInfo cdDirInfo = new DirectoryInfo(inPath);
            foreach (var cDir in cdDirInfo.GetDirectories())   // Test all Files INFO
            {
                Console.WriteLine("{0}!{4}>{1}.Size={2}.|TotalSize:{3}", Promt, cDir.FullName, TotalFileSize, TotalFileSize, crDeep);
                crDeep = crDeep + 1;
                TestDirFiles(cDir.FullName, ctMode); //Directory
                crDeep = crDeep - 1;
                //GetDirSize(cDir.FullName); //Directory
                //TotalFileSize = TotalFileSize + cFl.Length;
                //
                //Console.WriteLine("{0}|TotalSize:{3}>\t\t {1}.Size={2}.", Promt, cFl.Name, cFl.Length, TotalFileSize);

            }

        }
        static bool CheckFileTime(FileInfo crFile, checkTimeModes flPrcMode = 0)
        {
            TimeSpan diff;
            DateTime flTimeVal;
            if (flPrcMode > 0)
                flTimeVal = crFile.LastAccessTime;
            else
                flTimeVal = crFile.LastWriteTime;
            diff = refTime - flTimeVal;
            double interval = diff.TotalMinutes;
            Console.WriteLine("{0}> {1}", Promt, interval);
            if (maxTimeGap < interval)
                return false;
            else return true;
        }
        static void procesingFile(FileInfo crFile)
        {
            //TimeSpan diff;
            //diff = refTime - flTimeVal;
            //double interval = diff.TotalMinutes;
            Console.WriteLine("{0}>  File {1} processed", Promt, crFile.Name);
            //return interval;
        }
        static void TestDirFiles(string inPath, checkTimeModes flPrcMode = 0)
        {
            DirectoryInfo cDirInfo = new DirectoryInfo(inPath); // 
            //cDirInfo.GetFiles();
            foreach (var cFl in cDirInfo.GetFiles())   // Test all Files INFO
            {
                //Directory
                TotalFileSize = TotalFileSize + cFl.Length;
                Console.WriteLine("{0}> {1}.LastWriteTime={2}.|", Promt, flPrcMode);

                //Console.WriteLine("{0}!{3}> {1}.LastAccessTime={2}.|", Promt, cFl.Name, cFl.LastAccessTime, crDeep);
                if (CheckFileTime(cFl, flPrcMode))
                {
                    //Console.WriteLine("{0}> {1}", Promt, CheckFileTime(cFl.LastAccessTime));
                    procesingFile(cFl);
                }
            }
        }


        static bool TestPath(string ftPath)
        {
            if (Directory.Exists(ftPath))
                return true;
            return false;
        }
    }
}
