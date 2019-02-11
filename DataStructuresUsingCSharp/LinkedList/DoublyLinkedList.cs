using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.LinkedList
{
    public class DoublyLinkedList<T>
    {
        private DNode<T> Head;
        private DNode<T> Tail;
        public DNode<T> HEAD
        {
            get
            {
                return this.Head;
            }
        }

        //Insert in the begining
        public void AddStart(T data)
        {
            DNode<T> newNode = new DNode<T>();
            newNode.data = data;

            newNode.next = Head;

            if (Head != null)
                Head.prev = newNode;

            Head = newNode;

            if (Tail == null)
                Tail = newNode;

        }

        public void AddEnd(T data)
        {
            DNode<T> newNode = new DNode<T>();
            newNode.data = data;

            if (Tail == null)
            {
                Head = newNode;
            }
            else
            {
                Tail.next = newNode;
                newNode.prev = Tail;
            }
            Tail = newNode;
        }
        public void ReadAll()
        {
            DNode<T> curr = Head;

            while (curr != null)
            {
                Console.WriteLine(curr.data);
                curr = curr.next;
            }
        }
        public void ReadAllFromEnd()
        {
            DNode<T> curr = Tail;

            while(curr != null)
            {
                Console.WriteLine(curr.data);
                curr = curr.prev;
            }
        }

        public void RemoveEnd()
        {
            if (Head != null)
            {
                if (Head == Tail)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Tail.prev.next = null;
                    Tail = Tail.prev;
                }
            }
        }

        public void RemoveStart()
        {
            if (Head != null)
            {
                if (Head == Tail)
                {
                    Tail = null;
                    Head = null;
                }
                else
                {
                    Head.next.prev = null;
                    Head = Head.next;
                }
            }
        }
    }
}
