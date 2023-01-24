using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

        static bool UpSort = true;
        static bool rqExit = false;
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

        static void SortingDim(bool sortUp = true)
        {
            int rsCompare = 0;
            //Console.WriteLine("{0}: Sorting dimOfFamily sortUp ={1}", Promt, sortUp);
            for (int j = 0; j < dimOfFamily.Length; j++)

            {
                string workItem = dimOfFamily[j];
                //Console.WriteLine("{0}: workItem ={1}", Promt, workItem);
                for (int k = j + 1; k < dimOfFamily.Length; k++)
                {
                    rsCompare = String.Compare(dimOfFamily[j], dimOfFamily[k]);
                    //Console.WriteLine("{0}: vs :{1} rsCompare ={2}", dimOfFamily[j], dimOfFamily[k], rsCompare);
                    if (rsCompare != 0)
                    {
                        if (sortUp & (rsCompare > 0)) ItemSwap(ref dimOfFamily[j], ref dimOfFamily[k]);
                        if (!sortUp & (rsCompare < 0)) ItemSwap(ref dimOfFamily[j], ref dimOfFamily[k]);
                    }
                 }
                //ShowSortingDim();
            }
            ShowSortingDim();

        }
        static void ItemSwap(ref string Item1, ref string Item2)
        {
            string temp = Item1;
            Item1 = Item2;
            Item2 = temp;
            //Console.WriteLine("{0}:Items swaping {1}<>{2}", Promt, Item1, Item2);
        }
        static bool ItemCompare(string Item1, string Item2)
        {
            if (String.Compare(Item1, Item2) > 0)
                return false;
            else return true;
        }
        static void Main(string[] args)
        {

            Console.WriteLine("{0}|{1}:Startig ", UnTitle, ExTitle);
            Console.WriteLine("{0} ", Promt);

            ErrUserEentryExeption usrEx = new ErrUserEentryExeption("Допустимы сиволы 1,2,q/Q");

            iniSortingDim();
            ShowSortingDim();
            Console.WriteLine("{0}: Для выбора направления сортировки введите\n1:(А...Я), 2-(Я...А), Q-выход ", Promt);
            var userEntry = Console.ReadLine();
            try
            {
                switch (userEntry)
                {
                    case "1":
                        UpSort = true;
                        break;
                    case
                    "2": UpSort = false;
                        break;

                    case "q": 
                        rqExit = true;
                        break;
                    case "Q": 
                        rqExit = true;
                        break;
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

            //used for Sorting debug
            //try
            //{
            //    if (!rqExit) SortingDim(UpSort);
            //}
            //catch (Exception ex)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("{0}: Get Exception.", Promt, ex.Message);
            //}
            //finally
            //{
            //    Console.ForegroundColor = ConsoleColor.White;
            //}
            if (!rqExit) SortingDim(UpSort); //used for Sorting working



            Console.WriteLine("\n{0}: Finishing.", ExTitle);
            Console.WriteLine("{0}: Finished.\nPress any key.", UnTitle);
            Console.ReadKey();
        }
    }
}
