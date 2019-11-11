using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GenericCollection<T>
    {
        List<T> list = new List<T>();

        public void Add(T item)
        {
            list.Add(item);

        }

        public T GetAt(int position)
        {
            return list[position];
        }

        public T[] GetAll()
        {
            return list.ToArray();

        }

        public T this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }
    }
}
