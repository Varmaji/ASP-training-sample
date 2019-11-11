using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ProductManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            //    int length = 10;
            //    Console.WriteLine("Hello World");
            //    NewMethod(length);

            //Employee e1 = new Employee();
            //e1.EmployeeId = 10;
            //e1.EmployeeName = "Varma";
            //e1.Show();
            ////AnotherSample.Test();
            ///
            //StructExample.Test();
            //MemoryManagement.Test();
            //Inheritance.Test();
            // interfaces.Test();
            //DelegatesExample1.Test();
            //DelegateExample2.Test();
            // ExceptionHandling.Test();
            // Collections.Test2();
            // Collections.Test3();
            //Collections.Test();
           // DbOperation1.Test();
          //  DbOperation2.Test();
            ProductUI.Test();
           //DisconnectedExample2.Test();

            //Queue q = new Queue();
            //q.Enqueue("Order1");
            //q.Enqueue("Order2");
            //q.Enqueue("Order3");
            //q.Dequeue();
            //Console.WriteLine(q.Peek());

            
        }

        private static void NewMethod(int length)
        {
            for (int index = 0; index < length; index++)
            {
                Console.WriteLine(index);
            }
        }
    }
}
