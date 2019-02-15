using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.Queues
{
    public class ArrayQueue<T>
    {
        private List<T> list;

        public ArrayQueue()
        {
            list = new List<T>();
        }

        public int LENGTH
        {
            get { return list.Count; }
        }

        public void Enqueue(T data)
        {
            list.Add(data);
        }

        public T Dequeue()
        {
            if (list.Count == 0)
            {
                throw new Exception("Queue is empty");
            }
            else
            {
                T ele = list[0];
                list.RemoveAt(0);
                return ele;
            }
        }

        public void ReadAll()
        {
            foreach(T v in list)
            {
                Console.WriteLine(v.ToString());
            }
        }
    }
}
