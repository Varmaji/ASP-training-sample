using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    [Serializable]
    public class CustomException : Exception
    {
        public CustomException() { }
        public CustomException(string message) : base(message) { }
        public CustomException(string message, Exception inner) : base(message, inner) { }
       
    }
    class ExceptionHandling
    {
        static void ThrowException()
        {
            int a=10, b=0;
            var k = a / b;//DivideByZero Exception
      
        }

        static void CallThrowException()
        {
            try {
                ThrowException();
            }catch(DivideByZeroException de)
            {
                Console.WriteLine($"Message:{de.Message}");
                Console.WriteLine($"StackTrace:{de.StackTrace}");
                throw ; //rethrow by preserving the original stack
              //  throw de;// rethrowing by creating a new stack trace
            }
            catch(ArithmeticException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch(Exception ex)//Generic Exception handling block
            {
                Console.WriteLine(ex.Message);
                //throw ex;
            }
            finally
            {
                Console.WriteLine("Finally Executed");
            }
   
            
        }

        static void AnotherLevelCallThrowException()
        {
            throw new CustomException("Oops!!! Something went wrong please try after some time");
            CallThrowException();
      
        }

        internal static void Test()
        {
            AnotherLevelCallThrowException();
        }
    }
}
