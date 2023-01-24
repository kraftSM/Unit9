using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace caHw_9_1
{
    class TestExeption : Exception
    {
        public TestExeption() : base() { }
        public TestExeption(string message) : base(message) { }
    }

    internal class Program
    {
        static string UnitName = "Un:9";
        static string UnDescr = "Exeptiions.";
        static string ExName = "HW-1/9";
        static string ExDescr = "My own Exception";

        static Exception[] dimOfException;

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
        static void iniExceptionDim()
        {
            dimOfException = new Exception[5];
            dimOfException[0] = new TestExeption("Тестовое исключение Unita_9");
            dimOfException[1] = new DivideByZeroException("Деление на 0");
            dimOfException[2] = new ArgumentOutOfRangeException("Ошибка аргумента");
            dimOfException[3] = new OutOfMemoryException("Ошибка доступа к ОЗУ");
            dimOfException[4] = new AccessViolationException("Нарушение прав доступа");
        }
        static void Main(string[] args)
        {

            Console.WriteLine("{0}:Startig ", ExTitle);
            Console.WriteLine("{0} ", Promt);
            iniExceptionDim();            

            for (int j = 0; j < dimOfException.Length; j++)
            {
                try
                {
                    Console.WriteLine("{0}: Activating Exception from dimOfException[{1}]  = {2}", Promt, j, dimOfException[j].GetType());
                    throw (dimOfException[j]);
                }
                catch (TestExeption exc)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0}: [TestExeption] Get Exception of type:{1} . Msg:{2}", Promt, exc.GetType(), exc.Message);
                }

                catch (DivideByZeroException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine("{0}: [DivideByZeroException] Get Exception of type:{1} . Msg:{2}", Promt, ex.GetType(), ex.Message);
                }
                catch (OutOfMemoryException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine("{0}: [OutOfMemoryException] Get Exception of type:{1} . Msg:{2}", Promt, ex.GetType(), ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0}: [ArgumentOutOfRangeException] Get Exception of type:{1} . Msg:{2}", Promt, ex.GetType(), ex.Message);
                }
                catch (AccessViolationException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine("{0}: [AccessViolationException] Get Exception of type:{1} . Msg:{2}", Promt, ex.GetType(), ex.Message);
                }

                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine("{0}: Get Common Exception. Msg:{1}", Promt, ex.Message);
                }
                finally {
                    Console.ForegroundColor = ConsoleColor.White; 
                }

                Console.WriteLine("{0}: Finishing.", ExTitle);
                Console.WriteLine("{0}: Finished. Press key.", UnTitle);
                Console.ReadKey();
            }
        }
    }
}
