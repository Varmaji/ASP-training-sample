using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //interface Repository<TEntity,TIdentity>
    //{
    //    List<TEntity> GetEntities();
    //    TEntity GetDetails(TIdentity identity);
    //}

    //class EmployeeRepository:IRepository<Employee,int>
    //{
    //    public Employee GetDetails(int Identity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public List GetDetails(int Identity)
    //    {
    //        throw new NotImplementedException();
    //    }


    //}

    class Collections
    {
        internal static void Test3()
        {
            GenericCollection<int> intcoll = new GenericCollection<int>();
            intcoll.Add(100);
            GenericCollection<string> strColl = new GenericCollection<string>();
            strColl.Add("string1");
            GenericCollection<Employee> empcoll = new GenericCollection<Employee>();
            empcoll.Add(new Employee { EmployeeId = 1, EmployeeName = "" });
            int x = intcoll.GetAt(0);
            string s = strColl[0];
            var empList = empcoll.GetAll();
            int a = 10, b = 20;
            double d1 = 10.0, d2 = 50.0;
            String s1 = "Hello", s2 = "World";
            Console.WriteLine($"Before Swap,\n\t a={a},a={a},b={b},\n\td1={d1},d2={d2}\n\ts1={s1},s2={s2}");
            Swap<int>(ref a, ref b);
            Swap<double>(ref d1, ref d2);
            Swap<string>(ref s1, ref s2);
            Console.WriteLine($"After Swap,\n\t a={a},a={a},b={b},\n\td1={d1},d2={d2}\n\ts1={s1},s2={s2}");
        }

        static void Swap<T>(ref T item1,ref T item2)
        {
                        
            T temp = item1;
            item1 = item2;
            item2 = temp;
        }
        internal static void Test2()
        {
            Employee e1 = new Employee();
            e1.EmployeeId = 10;
            e1.EmployeeName = "sample";
            EmployeeCollections ec = new EmployeeCollections();
            ec.Add(e1);
            Employee e2 = new Employee()//Object initializer
            {
                EmployeeName = "Sample",
            EmployeeId = 101
            };
            ec.Add(e2);
            Console.WriteLine("Fetching the second Element");
            var emp = ec.GetAt(1);
            Console.WriteLine($"Element Details:\n{emp.EmployeeId},"+$"{emp.EmployeeName}");

            Console.WriteLine("\nFetching all details");
            var list = ec.GetAll();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.EmployeeId}," + $"{item.EmployeeName}");
            }
            Console.WriteLine();
            emp = ec[0];
        }

        internal static void Test()
        {

            //-----------------------------------------ArrayList----------------------------------
            ArrayList list = new ArrayList();
            list.Add("One");
            list.Add(100);
            list.Add(DateTime.Now);
            int counter = 65;
            Console.WriteLine($"{Convert.ToChar(counter)}.Working with Arraylists");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i+1}.{list[i]}");
            }

            Console.WriteLine("".PadLeft(45,'-'));
            counter++;
            //------------------------------------------HashTable--------------------------
            //Rs.4,599 =>Four thousand five hundred ninety nine only
            //0-10000000
            Hashtable ht = new Hashtable();
            ht.Add("1", "One");
            ht.Add("2", "two");
            ht.Add("3", "three");
            Console.WriteLine($"{Convert.ToChar(counter)}.Working with Hashtable");
            foreach (var item in ht.Keys)
            {
                Console.WriteLine($"{item}-{ht[item]}");

            }
            Console.WriteLine("".PadLeft(45, '-'));
            counter++;

            //------------------------------------------SortedList--------------------------
            SortedList sorted = new SortedList();
            sorted.Add(2, "two");
            sorted.Add(1, "One");
            sorted.Add(5, "Five");
            sorted.Add(4, "Four");
            Console.WriteLine($"{Convert.ToChar(counter)}.Working with SortedList");
            foreach (var item in sorted.Keys)
            {
                Console.WriteLine($"{item}-{sorted[item]}");

            }
            Console.WriteLine("".PadLeft(45, '-'));
            counter++;

            //------------------------------------------Stacks-----------------------------
            Stack stk = new Stack();
            stk.Push("One");
            stk.Push(100);
            stk.Push(DateTime.Now);
            Console.WriteLine($"{Convert.ToChar(counter)}.Working with Satck");
            int length=stk.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"{i + 1}.{stk.Pop()}");
            }

            Console.WriteLine("".PadLeft(45, '-'));
            counter++;

            //------------------------------------------Queue-------------------------------
            Queue q = new Queue();
            q.Enqueue("One");
            q.Enqueue(100);
            q.Enqueue(DateTime.Now);
            length = q.Count;
            Console.WriteLine($"{Convert.ToChar(counter)}.Working with Queue");
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"{i + 1}.{q.Dequeue()}");
            }

            Console.WriteLine("".PadLeft(45, '-'));
            counter++;

        }
    }
}
