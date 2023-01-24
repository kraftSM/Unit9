using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
//using static System.Net.WebRequestMethods;

namespace caUn8_Hw2_4
{
    internal class Program
    {
        static string UnitName = "Un:8";
        static string UnDescr = "File System Operation";
        static string ExName = "HW-2/4";
        static string ExDescr = "Test dir Size";

        static string DirPath = @"D:\WinTemp\ТасКом";
        static long TotalFileSize = 0;
        static int Deep = 0;


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

            //ExName = "2"; ExDescr = "File Info Test"; Console.WriteLine("{0}:Start ", ExTitle); //Ex Title show
            Console.WriteLine("{0} ", Promt);
            string dPath = GetPath(DirPath);
            if (TestPath(dPath))
            {
                Console.WriteLine("{0}: DirPath= {1} It's OK.", ExTitle, dPath);
                GetDirSize(dPath);
                //string[] files = Directory.GetFiles(dPath);// Получим все файлы корневого каталога
                //foreach (string s in files)   // Выведем их все
                //{
                //    Console.WriteLine("{0}: {1}.", Promt, s);

                //}

            }


            Console.WriteLine("{0}: Finishing.", ExTitle);
            Console.WriteLine("{0}: Finished. Press key.", UnTitle);
            Console.ReadKey();

        }
        static string GetPath(string inPath)
        {
            return inPath;
        }
        static void GetDirSize(string inPath)
        {
            GetDirsFileSize(inPath);
            DirectoryInfo cdDirInfo = new DirectoryInfo(inPath);
            foreach (var cDir in cdDirInfo.GetDirectories())   // Test all Files INFO
            {
                Console.WriteLine("{0}>{1}.Size={2}.|TotalSize:{3}", Promt, cDir.FullName, TotalFileSize, TotalFileSize); 
                GetDirSize(cDir.FullName); //Directory
                //TotalFileSize = TotalFileSize + cFl.Length;
                //
                //Console.WriteLine("{0}|TotalSize:{3}>\t\t {1}.Size={2}.", Promt, cFl.Name, cFl.Length, TotalFileSize);

            }

        }
        static void GetDirsFileSize(string inPath)
        {
            DirectoryInfo cDirInfo = new DirectoryInfo(inPath); // 
            //cDirInfo.GetFiles();
            foreach (var cFl in cDirInfo.GetFiles() )   // Test all Files INFO
            {
                //Directory
                TotalFileSize = TotalFileSize + cFl.Length;
                //Console.WriteLine("{0}> {1}.Size={2}.|TotalSize:{3}", Promt, cFl.Name, cFl.Length, TotalFileSize);

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
