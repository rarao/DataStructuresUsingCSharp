﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.LinkedList
{
    // Increasing the performance of a simple linked list using Tail node
    public class TailLinkedList
    {
        private Node Head;
        private Node Tail;

        //Insert in the begining
        public void AddStart(object data)
        {
            Node newNode = new Node();
            newNode.data = data;

            newNode.next = Head;
            Head = newNode;

            if (Tail == null)
                Tail = newNode;
        }

        public void AddEnd(object data)
        {
            Node newNode = new Node();
            newNode.data = data;

            if (Tail == null)
            {
                Head = newNode;
            }
            else
            {
                Tail.next = newNode;
            }
            Tail = newNode;
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
                if (Head == Tail)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Node curr = Head;
                    while (curr.next != Tail)
                    {
                        curr = curr.next;
                    }
                    curr.next = null;
                    Tail = curr;
                }
            }
        }

        public void RemoveStart()
        {
            if (Head != null)
            {
                if (Head == Tail)
                    Tail = null;
                Head = Head.next;
            }
        }
    }
}
