using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    interface IBase
    {
        void DoWork();//visibility cannot be defined
    }

    interface Ichild : IBase
    {
        void PerformTask();
    }
    class InterfaceImplementation : IBase, Ichild
    {
        public void DoWork()
        {
            Console.WriteLine("InterfaceIMplementation.DOWork() called.");
        }
        public void PerformTask()
        {
            Console.WriteLine("InterfaceImplementation.performTask() called");
        }
    }
    class interfaces
    {
        internal static void Test()
        {
            InterfaceImplementation ii = new InterfaceImplementation();
            //ii.DoWork();
            //IBase ib = ii;//Interface pointer "ib" ,objects can be assigned to interface pointers
            //ib.DoWork();
            //Ichild ic = ii;
            //ic.PerformTask();
            //ic.DoWork();
            AllStatics.Test();

        }
    }
}