using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.Queues
{
    public class LinkedListQueue<T>
    {
        private LinkedList<T> list;

        public LinkedListQueue()
        {
            list = new LinkedList<T>();
        }

        public int LENGTH
        {
            get { return list.Count; }
        }

        public void Enqueue(T data)
        {
            list.AddLast(data);
        }

        public T Dequeue()
        {
            if (list.Count == 0)
            {
                throw new Exception("Queue is empty");
            }
            else
            {
                T ele = list.First.Value;
                list.RemoveFirst();
                return ele;
            }
        }
        public void ReadAll()
        {
            foreach (T v in list)
            {
                Console.WriteLine(v.ToString());
            }
        }
    }
}
