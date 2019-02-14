using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.Stacks
{

    // Stack implementation using linked list

    class LinkedListStack<T>
    {
        LinkedList<T> linkedList;

        public LinkedListStack()
        {
            linkedList = new LinkedList<T>();
        }

        public void Push(T item)
        {
            linkedList.AddFirst(new LinkedListNode<T>(item));
        }
        public T Pop()
        {
            if (linkedList.First != null)
            {
                T item = linkedList.First.Value;
                linkedList.RemoveFirst();
            }
            throw new Exception("Stack underflow");
        }

        public T Peep()
        {
            if(linkedList.First != null)
            {
                return linkedList.First.Value;
            }
            throw new Exception("Empty stack");
        }
    }
}
