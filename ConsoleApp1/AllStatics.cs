using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class staticClass
    {
        static int statctr = 1;
        int instctr = 1;


        static staticClass()
        {
            Console.WriteLine("StaticClass.cctor() called.");
            statctr++;

        }

        public staticClass()
        {
            Console.WriteLine("StaticClass.cctor() called.");
            statctr++;
            instctr++;
        }

        public static void staticShow()//instance fields cannot be accesed in static
        {
            Console.WriteLine($"Static Field{statctr},Instance field:N/A");
        }

        public void InstanceShow()
        {
            Console.WriteLine($"Static Field{statctr},Instance field:{instctr}");
        }
    }
    class AllStatics
    {
        internal static void Test()
        {
            //staticClass.staticShow();
            staticClass sc1 = new staticClass();
            sc1.InstanceShow();
            staticClass.staticShow();

        }
    }
}
