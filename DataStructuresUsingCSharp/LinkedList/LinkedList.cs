using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.LinkedList
{
    public class SimpleLinkedList
    {
        private Node Head;

        //Insert in the begining
        public void AddStart(object data)
        {
            Node newNode = new Node();
            newNode.data = data;

            newNode.next = Head;
            Head = newNode;
        }

        public void AddEnd(object data)
        {
            Node newNode = new Node();
            newNode.data = data;

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node curr = Head;

                while (curr.next != null)
                {
                    curr = curr.next;
                }
                curr.next = newNode;
            }
        }
        public void ReadAll()
        {
            Node curr = Head;

            while (curr != null)
            {
                Console.WriteLine(curr.data);
                curr = curr.next;
            }
        }

        public void RemoveEnd()
        {
            if (Head != null)
            {
                Node curr = Head;

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
