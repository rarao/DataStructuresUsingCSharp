using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.Stacks
{

    // Dynamic array stack where the array grows automatically to double it's size whenever there is an Add(Push) operation.
    // It also resizes to half when items in the list are less than half

    public class ArrayStack<T>
    {
        List<T> array;
        int top = -1;
        
        public ArrayStack()
        {
            array = new List<T>();
        }
        public int TOP
        {
            get { return top; }
            set { top = value; }
        }

        public void Push(T item)
        {
            array.Add(item);
            top++;
        }
        public T Pop()
        {
            if (top > -1)
            {
                T item = array[top];
                array.RemoveAt(top--);
                return item;
            }
            throw new Exception("Stack underflow");
        }

        public T Peep()
        {
            if(top > -1)
            {
                return array[top];
            }
            throw new Exception("Empty stack");
        }
    }
}
