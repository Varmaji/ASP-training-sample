using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class EmployeeCollections : CollectionBase
    {
        public void Add(Employee obj)
        {
            List.Add(obj);
        }
        public void Remove(Employee obj)
        {
            if(List.Contains(obj))List.Remove(obj);
        }
        
        public Employee GetAt(int position)
        {
            return List[position] as Employee;
        }

        public Employee[] GetAll()
        {
            Employee[] arr = new Employee[List.Count];
            List.CopyTo(arr, 0);
            return arr;
        }
        public Employee this[int index]
        {
            get { return List[index] as Employee; }
            set { List[index] = value; }
        }
     
    }
}
