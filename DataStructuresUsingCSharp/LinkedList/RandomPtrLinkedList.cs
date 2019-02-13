using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.LinkedList
{
    // A linked list with a next pointer as well as pointer pointing to an arbitrary node in the list
    public class RandomPtrLinkedList<T>
    {
        private RNode<T> Head;

        public RNode<T> HEAD
        {
            get
            {
                return this.Head;
            }
            set
            {
                this.Head = value;
            }
        }
        private RNode<T> GetRandomNode()
        {
            int length = 0;
            RNode<T> curr = Head;
            while (curr != null)
            {
                curr = curr.next;
                length++;
            }

            Random obj = new Random();
            int randomNodeNumber = obj.Next(length);

            curr = Head;

            for (int i = 0; i < randomNodeNumber; i++)
            {
                curr = curr.next;
            }

            return curr;
        }
        //Insert in the begining
        public void AddStart(T data)
        {
            RNode<T> newNode = new RNode<T>();
            newNode.data = data;

            newNode.next = Head;
            Head = newNode;
            newNode.rand = GetRandomNode();
        }

        public void AddEnd(T data)
        {
            RNode<T> newNode = new RNode<T>();           
            newNode.data = data;

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                RNode<T> curr = Head;

                while (curr.next != null)
                {
                    curr = curr.next;
                }
                curr.next = newNode;
            }
            newNode.rand = GetRandomNode();
        }
        public void ReadAll()
        {
            RNode<T> curr = Head;

            while (curr != null)
            {
                Console.WriteLine(curr.data + " : " + curr.rand.data);
                curr = curr.next;
            }
        }

        public void SetRandomNodes()
        {
            RNode<T> curr = Head;

            while (curr != null)
            {
                curr.rand = GetRandomNode();
                curr = curr.next;
                Thread.Sleep(1000);
            }
        }

        public void RemoveEnd()
        {
            if (Head != null)
            {
                RNode<T> curr = Head;

                if (curr.next == null)
                {
                    Head = null;
                    return;
                }

                while (curr.next.next != null)
                {
                    curr = curr.next;
                }

                curr.next = null;
            }
        }

        public void RemoveStart()
        {
            if (Head != null)
            {
                Head = Head.next;
            }
        }
    }
}
