using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    struct Marks
    {
        public int RollNo;
        public string Name;
        public double English;
        public double Kannada;
        public double maths;
        public double Social;
        public double Science;



        public double TotalMarks
        {
            get { return English + Kannada + maths + Social + Science; }
        }

        public void ShowDetails()
        {
            Console.WriteLine($"RollNo:{RollNo}\n Name:{Name}");
            Console.WriteLine($"English\t: {English}");
            Console.WriteLine($"Kannada\t: { Kannada}");
            Console.WriteLine($"maths\t: { maths}");
            Console.WriteLine($"Social\t:{ Social}");
            Console.WriteLine($"Science\t: { Science}");
            Console.WriteLine($"Total\t:{ TotalMarks}");
        }


    }

    enum StudentStatus
    {
        None,  /*=0*/
        Enrolled,/*None+1*/
        Persuing,
        Complted,
        Dismissed,
        Suspended=Unknown,
        Missing = 20,
        Discontinued,
        Unknown=Missing
    }
    class StructExample
    {
        internal static void Test()
        {
            //Using the Enums 
            StudentStatus status = (StudentStatus.Missing);
            Console.WriteLine(status.ToString());
            foreach(var item in Enum.GetNames(typeof(StudentStatus)))
            {
                Console.WriteLine(item);
            }

            Marks m1 = new Marks();
            m1.ShowDetails();
            Marks m2;
            m2.RollNo = 1234;
            m2.Name = "Ravivarma";
            m2.Kannada = 98;
            m2.English = 98;
            m2.Social = 88;
            m2.Science = 78;
            m2.maths = 69;
            m2.ShowDetails();
        
            
        }
    }
}
