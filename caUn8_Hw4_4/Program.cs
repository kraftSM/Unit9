using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    [Serializable]
    class Stud
    {
        //private string sName;
        //private string sGrp;
        //private DateTime sDOB;
        public string StName { get; set; }
        public string stGroup { get; set; }
        public DateTime stDateOfBirth { get; set; }
        //public Stud(string Name, string Group, DateTime BurthDate)
        //{
        //    sName = Name;
        //    sGrp = Group;
        //    sDOB = BurthDate;
        //}

    }
    internal class Program
    {
        static string inFileNametlPath = "Students.dat";
        static string inFileFullNamelPath = @"D:\WinTemp\SkillFactory\Students.dat";
        static string inFilePath = "D:\\WinTemp\\SkillFactory\\";
        static void Main(string[] args)
        {
            ReadBinary();

            Console.WriteLine("NfskEnd");
            Console.ReadLine();
        }
        static void ReadBinary()
        {
            // string sName;
            //string sGrp;
            //DateTime sDOB;

            if (File.Exists(inFileFullNamelPath))
            {
                BinaryFormatter bf = new BinaryFormatter();
                // десериализация
                using (FileStream fs = new FileStream(inFileFullNamelPath, FileMode.Open))
                {
                    Stud[] rdStud = (Stud[])bf.Deserialize(fs);
                    Console.WriteLine("Объект десериализован");
                    //foreach (Stud st in rdStud)
                    //{
                    //    Console.WriteLine($"Имя: {st.StName} --- gr: {st.stGroup} lh: {st.stDateOfBirth}");
                    //}
                }
            }

            //try { 
            //if (File.Exists(inFileFullNamelPath))
            //{
            //        var newPet = (Pet)formatter.Deserialize(fs);
            //        Console.WriteLine("Объект десериализован");
            //        Console.WriteLine($"Имя: {newPet.Name} --- Возраст: {newPet.Age}"); 
            //        using (var stream = File.Open(inFileFullNamelPath, FileMode.Open))
            //    {
            //        using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
            //        {
            //            sName = reader.ReadString();
            //            sGrp = reader.ReadString();
            //            sDOB = Convert.ToDateTime( reader.ReadInt32());

            //        }
            //    }

            //    Console.WriteLine("sName is: " + sName);
            //    Console.WriteLine("sGrp  is: " + sGrp);
            //    Console.WriteLine("sDOB is: "+ sDOB);
            //    }          
            //}

        }
    }
}
