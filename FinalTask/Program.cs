using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

 
namespace FinalTask
{
    [Serializable]
    class Student
    {
        private string sName;
        private string sGrp;
        private DateTime sDOB;
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Student(string Name, string Group, DateTime BurthDate)
        {
            sName = Name;
            sGrp = Group;
            sDOB = BurthDate;
        }
    }
    internal class Program
    {
        static string inFileFullNamelPath;
        static string inFileName = "Students.dat";
        static string inFilePath = @"D:\WinTemp\SkillFactory\StudentDat\";
        
        //static string inFileFullNamelPath = @"D:\WinTemp\SkillFactory\StudentDat\Students.dat";       

        static Student[] rdStud;// = (Student[])bf.Deserialize(fs);
        static int rdcStud = 0;
        static int wrcStud = 0;
        static void Main(string[] args)
        {
            inFileFullNamelPath = inFilePath + inFileName; // строим полный путь, проверку на правильность позже...

                ReadBinary();
            foreach (Student st in rdStud) 
            {
                AddStudentToGroupFile(st); // оптимизацию не делаю, просто пишу по одной строке в файлы группы
                //Console.WriteLine($"Имя:: {st.Name} gr: {st.Group} dob: {st.DateOfBirth}");
                //MakeFileForGroup(st.Group);
            }
            //for (int i = 0; i < rdStud.Length; i++)
            //{
            //    Console.WriteLine("Имя: {0}, ДатаРожденья: {1}", rdStud[i].Name, rdStud[i].DateOfBirth);
            //    AddStudentToGroupFile(rdStud[i]);
            //}
            Console.WriteLine("rdcStud:{0}  wrcStud:{1}", rdcStud, wrcStud); 
            Console.WriteLine("Task End");
            Console.ReadKey();
        }


        static void ReadBinary()
        {
            if (File.Exists(inFileFullNamelPath))
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    // десериализация
                    using (FileStream fs = new FileStream(inFileFullNamelPath, FileMode.OpenOrCreate))
                    {
                        //Student[] rdStud = (Student[])bf.Deserialize(fs);
                        rdStud = (Student[])bf.Deserialize(fs);
                        Console.WriteLine("Объект десериализован");
                        foreach (Student st in rdStud)
                        {
                            Console.WriteLine($"Имя: {st.Name} gr: {st.Group} dob: {st.DateOfBirth}");
                            rdcStud++;
                            //MakeFileForGroup(st.Group);
                            //Console.WriteLine("Имя: {st.stName} --- gr: {st.stGroup} dob: {st.stDateOfBirth}");
                            //Console.WriteLine("Имя: {0} ", st.stName);

                        }
                    }


                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                    //throw;
                }

            }
        }
        static void AddStudentToGroupFile(Student stinfo)
        {
            string grFileName = inFilePath + stinfo.Group + ".txt";

            using (StreamWriter sw = File.AppendText(grFileName))  // создает файл, если его нет
            {
                sw.WriteLine(":{0} :{1}", stinfo.Name, stinfo.DateOfBirth);
                wrcStud++;
            }

        }
        static void MakeFileForGroup(string fName)
        {
            string NewFileName = inFilePath + fName + ".txt";

            if (!File.Exists(NewFileName))
            {
                File.Create(NewFileName);
                Console.WriteLine($"GroupFile:  {NewFileName} created");

            }
        }
    }
}
