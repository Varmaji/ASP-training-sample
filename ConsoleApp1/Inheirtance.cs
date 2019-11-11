using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Baseclass
    {
        private int privInt=999;
        protected int procInt=888;
        internal int interInt=777;
        public int pubInt=666;

       public Baseclass()
        {
            Console.WriteLine("Baseclass.ctor() called");
        }

        public Baseclass(int value) //Overloaded constructor in the base class
        {
            Console.WriteLine("BaseClass.ctor() called");
            privInt = procInt = interInt = pubInt = value;
        }
        public virtual void Show()
        {
            Console.WriteLine("Baseclass.show() called.====>");
            Console.WriteLine($"\tprivate Field:{privInt}");
            Console.WriteLine($"\tProtected Field:{procInt}");
            Console.WriteLine($"\tInternal Field:{interInt}");
            Console.WriteLine($"\tPublic Field:{pubInt}");
            Console.WriteLine("".PadLeft(45,'='));//end field
        }
    }

    class DerivedClass : Baseclass
    {
        public DerivedClass()
        {
            Console.WriteLine("Derivedclass.ctor() called");
        }
        public DerivedClass(int value) :base(value)//Overloaded constructor in the Derived class
        {
            Console.WriteLine("Derivedclass.ctor() called");
            
        }
         public override void Show()//Base class implementation is hidden by using the new keyword
        {
            Console.WriteLine("Derived.show() called.====>");
            //Console.WriteLine($"\tprivate Field:{privInt}");  //Private fields of base class
            Console.WriteLine($"\tProtected Field:{procInt}");
            Console.WriteLine($"\tInternal Field:{interInt}");
            Console.WriteLine($"\tPublic Field:{pubInt}");
            Console.WriteLine("".PadLeft(45, '='));//end field
        }
    }
    class Inheritance
    {
        internal static void Test()
        {
           // Baseclass bc = new Baseclass();
           // bc.Show();
           // DerivedClass dc = new DerivedClass();
           //dc.Show();



            Baseclass bc1 = new Baseclass(444);
            bc1.Show();
            DerivedClass dc1 = new DerivedClass(666);//by default this will call parameterless constructor
            dc1.Show();

            bc1 = dc1;//No error becz,the child object can be assigned to parent(Widening conversion)
            //child class has an implicit "base pointer"
            //bc object is pointing to the dc.base
            bc1.Show();

        }
    }
}
