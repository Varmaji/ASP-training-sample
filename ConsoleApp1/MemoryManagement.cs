using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MemoryManagement :IDisposable
    {
        private int counter;
        private readonly int size=10000;//1 lakh
        private string[] cities;

        public MemoryManagement(int counter)//change size to counter
        {
            this.counter = counter;
            cities = new string[size];
            for (int i = 0; i < size; i++)
            {
                //some code which quickly fills up the memoty
                cities[i] = "This is some long string to fill up the memory" + i.ToString();
            }
            Console.WriteLine($"===================>>> OBJECT{counter} CREATED<<<<<<<===");
        }
        ~MemoryManagement()//type tilde followed by the tab
        {
            cities = null;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\t0x0x0x0x0x0x Object {counter} DESTROYED xoxoxoxoxoxoxo");
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public void Dispose()//Idisposable which is uniform Naming convention for the disposing
        {
            cities = null;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\t0x0x0x0x0x0x Object {counter} DISPOSED xoxoxoxoxoxoxo");
            Console.ForegroundColor = ConsoleColor.Blue;
            GC.SuppressFinalize(this);//removes the entry from Finalizer list
        }


        internal static void Test()
        {
            
            MemoryManagement mm;
            for (int i = 0; i < 100; i++)
            {
                mm = new MemoryManagement(i);
                if (i>25 && i<75)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Generation of 'mm' before 1st collection is {GC.GetGeneration(mm)}");
                    GC.Collect();//First collection attempt
                    Console.WriteLine($"Generation of 'mm' after 1st collection is {GC.GetGeneration(mm)}");
                    if (i > 40 && i < 51)
                    {
                        GC.Collect();
                        Console.WriteLine($"Generation of 'mm' after 2nd collection is {GC.GetGeneration(mm)}");
                    }
                 
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                if (i > 80 && i < 91)
                {
                    mm.Dispose();
                }

            }
            //any object in the "using " block should implement Idisposable interface
            using (MemoryManagement mm2 = new MemoryManagement(9999))//will automatically call the Dispose method
            { 
                Console.WriteLine("Hello World .\n \t created Object \n\t 999999\n\n");
            }
                Console.WriteLine("Press a key to terminate");
            Console.ReadKey();
        }
    }
}
