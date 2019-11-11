using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //Event Data class
    public class CustomEventArgs : System.EventArgs
    {

        //Properties
        public int Number { get; set; }//prop tab+tab
        public string Message { get; set; }
    }

    //Delegate declaratiin in .NET pattern
    public delegate void CustomDelegate(object sender, CustomEventArgs e);

    //publisher class --Raises the notifications or Invokes the delegate
    public class Publisher
    {
        //Instantitation of the Delegate (part)
        public CustomDelegate MyEvent;//only declaration part is done here.No Initialization
        //Method which raises the notification based on certain actions

        public void RaiseNotification()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 5 || i == 6)
                {
                    CustomEventArgs e = new CustomEventArgs { Number = i, Message = "Threshold reached." };
                    OnMyEvent(e);
                }
            }
        }

    


    //Provide a mothod which invokes the delegate.This is part of .NET pattern
    protected void OnMyEvent(CustomEventArgs e)
    {
        if (MyEvent != null)//has been initialized
            MyEvent(this, e);
        //MyEvent?.Invoke(this,e);
    }
}

        //Subscriber class--hence the notifications,or consumes the notification

        public class Subscriber {
            //Function which matches the delegate signature

            public void HandleNotification(object sender,CustomEventArgs e)
            {
                Console.WriteLine($" SUBSCRIBER SAYS :[Number :{e.Number},Message :{e.Message}");
            }

        }

        //Mapper class used to map publisher with subscriber and perform other houskeeping tasks
        class DelegateExample2
        {

        internal static void Test()
        {
            Publisher pub = new Publisher();
            Subscriber sub = new Subscriber();
            //delegate Instantiation (Completed here)
            //Maps the publisshers MyEvent variable to the subscribers Handle Notification method
            pub.MyEvent += new CustomDelegate(sub.HandleNotification);

            //Anonymous Methods-Unnamed Methods
            //inline functions and can access the other variables
            pub.MyEvent += delegate (object sender, CustomEventArgs e)
              {
                  Console.WriteLine($"ANON SAYS :[Number :{e.Number},Message:{e.Message}]");
              };

            pub.MyEvent += (s, e) => Console.WriteLine($"LAMBDA SAYS :[NUmber:{e.Number},Message:{e.Message}]");
           /* {
                Console.WriteLine($"LAMBDA SAYS :[NUmber:{e.Number},Message:{e.Message}]");
            }*/ //multiple line in the lambsda expresssions can be written like this

            //()=>{}
            //s=>statement
            //(s,e)=>{}
            //Like anonymous mehtods,can acces local variables








            //call the function which raises the notification
            pub.RaiseNotification();
            Console.WriteLine( "press any key to continue");
            Console.ReadKey();
        }
        }
    }

