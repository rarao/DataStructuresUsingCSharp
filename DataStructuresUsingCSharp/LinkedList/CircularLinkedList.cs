using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.LinkedList
{
    public class CircularLinkedList<T>
    {
        private Node<T> Head;

        //Insert in the begining
        public void AddStart(T data)
        {
            Node<T> newNode = new Node<T>();
            newNode.data = data;

            if (Head == null)
            {
                newNode.next = newNode;
                Head = newNode;
            }
            else
            {
                Node<T> curr = Head;

                while (curr.next != Head)
                    curr = curr.next;

                curr.next = newNode;
                newNode.next = Head;
                Head = newNode;
            }
        }

        public void AddEnd(T data)
        {
            Node<T> newNode = new Node<T>();
            newNode.data = data;

            if (Head == null)
            {
                newNode.next = newNode;
                Head = newNode;
            }
            else
            {
                Node<T> curr = Head;

                while (curr.next != Head)
                    curr = curr.next;

                curr.next = newNode;
                newNode.next = Head;
            }
        }
        public void ReadAll()
        {
            Node<T> curr = Head;

            do
            {
                Console.WriteLine(curr.data);
                curr = curr.next;
            } while (curr != Head);
        }

        public void RemoveEnd()
        {
            if (Head != null)
            {
                if (Head.next == Head)
                {
                    Head = null;
                }
                else
                {
                    Node<T> curr = Head;
                    while (curr.next.next != Head)
                    {
                        curr = curr.next;
                    }
                    curr.next = Head;
                }
            }
        }

        public void RemoveStart()
        {
            if (Head != null)
            {
                if (Head.next == Head)
                {
                    Head = null;
                }
                else
                {
                    Node<T> curr = Head;
                    while (curr.next != Head)
                    {
                        curr = curr.next;
                    }
                    curr.next = Head.next;
                    Head = Head.next;
                }
            }
        }
    }
}
