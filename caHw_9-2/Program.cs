using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caHw_9_2
{
    class ErrUserEentryExeption : Exception
    {
        public ErrUserEentryExeption() : base() { }
        public ErrUserEentryExeption(string message) : base(message) { }
    }
    internal class Program
    {
        static string UnitName = "Un:9";
        static string UnDescr = "Exeptions/Action.";
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
            for (int j = 0; j < dimOfFamily.Length; j++) Console.WriteLine("{0}: dimOfFamily[{1} ] = {2} ", Promt, j, dimOfFamily[j]);

        }
 
        static void SortingDim(int sortType = 0)
        {
            //for (int j = 0; j < dimOfFamily.Length; j++) 
            Console.WriteLine("{0}: Sorting dimOfFamily sortType ={1}", Promt, sortType);
            //ShowSortingDim();
        }
        static void Main(string[] args)
        {

            Console.WriteLine("{0}|{1}:Startig ", UnTitle, ExTitle);
            Console.WriteLine("{0} ", Promt);

            ErrUserEentryExeption usrEx = new ErrUserEentryExeption("Допустимы сиволы 1,2,q/Q");
             iniSortingDim();
                ShowSortingDim();
                Console.WriteLine("{0}: Для выбора направления сортирвки введите\n1:(А..Я), 2-(Я..Ф), Q-выход ", Promt);
                var userEntry = Console.ReadLine();
            try
            {
                switch (userEntry)
                {
                    case "1":
                        SortingDim(0);
                        break;
                    case "2":
                        SortingDim(1);
                        break;
                    case "q": break;
                    case "Q": break;
                    default:
                        {
                            throw (usrEx);
                        }


                }
            }
            catch (ErrUserEentryExeption exc)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}: Get ErrUserEentryExeption. Msg:{1}", Promt, exc.Message);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}: Get Exception.", Promt, ex.Message);
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
Console.WriteLine("{0}: Finishing.", ExTitle);
Console.WriteLine("{0}: Finished.\nPress any key.", UnTitle);
Console.ReadKey();
        }
    }
}
