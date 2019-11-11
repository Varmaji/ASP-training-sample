using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //1.Declare a delegate
    public delegate int ArithmeticDelegate(int a, int b);
    class DelegatesExample1
    {

        //Methods which match the delegate signature
        public int Add(int x, int y) { return x + y; }

        public static int Minus(int x, int y) { return x - y; }

        public int Multiply(int x, int y) { return x * y; }

        public static int Divide(int a, int b) { return b > 0 ? a / b : 0; }

        internal static void Test()
        {
            DelegatesExample1 de = new DelegatesExample1();
            //2.Instantiation
            ArithmeticDelegate ad = new ArithmeticDelegate(de.Add);
         
            
            //3.Invocation(style 1)
            var result = ad(100, 200);
            Console.WriteLine($"1. ad(100,200)=>{result}");
            
            
            //3.Invocation(style 2)
             result = ad(444, 566);
            Console.WriteLine($"1. ad(444,566)=>{result}");
            

            //Multicasting 
            ad += new ArithmeticDelegate(Minus); //static method uses the class refernce
            ad += new ArithmeticDelegate(de.Multiply);
            ad += new ArithmeticDelegate(Divide);
            Console.WriteLine("Multicasted Successfully..Invoking");
            result = ad.Invoke(5000, 100);
            Console.WriteLine($"3.ad.Invoke(5000,100)=>{result}");
          
            
            //Iterate through the list 
            foreach(Delegate item in ad.GetInvocationList())
            {
                //if (item.Method.Name.StartsWith("M")) ///we can give condition for what we neeed particularly
                //{
                    object res = item.DynamicInvoke(3333, 11);
                    Console.WriteLine($"\t{item.Method.Name}returned {res}");
                //}
            }
            Console.WriteLine("press any key to terminate");

           
            Console.ReadKey();
        }

    }
}
