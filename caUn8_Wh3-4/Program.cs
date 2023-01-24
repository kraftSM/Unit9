using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caUn8_Wh3_4
{
    internal class Program
    {
    static string UnitName = "Un:8";
    static string UnDescr = "File System Operation";
    static string ExName = "HW-3/4";
    static string ExDescr = "Clear 30min-idle Items";

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

            Console.WriteLine("{0}: Finishing.", ExTitle);
            Console.WriteLine("{0}: Finished. Press key.", UnTitle);
            Console.ReadKey();
        }
    }
}
