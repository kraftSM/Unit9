using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caHw_9_2
{
    internal class Program
    {
        static string UnitName = "Un:9";
        static string UnDescr = "Exeptiions/Action.";
        static string ExName = "HW-2/2";
        static string ExDescr = "Action/delegates";

        static string[] dimOfFamily; 
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
        static void iniSortingDim()
        {
            dimOfFamily = new string[5];
            dimOfFamily[0] = "Петров";
            dimOfFamily[1] = "Брыльская"; 
            dimOfFamily[2] = "Яковлев";
            dimOfFamily[3] = "Рязанов";
            dimOfFamily[4] = "Мягков"; 
        }
        static void ShowSortingDim()
        {
            for (int j = 0; j < dimOfFamily.Length; j++) Console.WriteLine("{0}: dimOfFamily[j] = {1} ", ExTitle, dimOfFamily[j]);
            
        }

            static void Main(string[] args)
        {
            Console.WriteLine("{0}:Startig ", ExTitle);
            Console.WriteLine("{0} ", Promt);
            iniSortingDim();
            ShowSortingDim();
            try
            {
               
                //    for (int j = 0; j < dimOfFamily.Length; j++)
                //{ Console.WriteLine("{0}: dimOfFamily[j] = {1} ", ExTitle, dimOfFamily[j]);
                //}
                //if (TestPath(dPath))
                //{
                
                //    //TestDir(dPath);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}: Get Exception.", Promt, ex.Message);
            }
            Console.WriteLine("{0}: Finishing.", ExTitle);
            Console.WriteLine("{0}: Finished. Press key.", UnTitle);
            Console.ReadKey();
        }
    }
}
