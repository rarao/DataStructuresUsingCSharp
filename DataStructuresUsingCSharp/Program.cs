﻿using DataStructuresUsingCSharp.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomPtrLinkedList<int> obj3 = new RandomPtrLinkedList<int>();
            obj3.AddEnd(1);
            obj3.AddEnd(2);
            obj3.AddEnd(3);
            obj3.AddEnd(4);
            obj3.AddEnd(5);
            obj3.AddEnd(6);
            obj3.AddEnd(7);
            obj3.AddEnd(8);
            obj3.AddEnd(9);

            obj3.SetRandomNodes();
            obj3.ReadAll();

            RandomPtrLinkedList<int> obj3Clone = new RandomPtrLinkedList<int>();
            obj3Clone.HEAD = ProblemsOnLinkedList<int>.CloneRandomPtrList(obj3.HEAD);

            Console.WriteLine("Old List : ");
            obj3.ReadAll();
            Console.WriteLine("Cloned List : ");
            obj3Clone.ReadAll();

            GenericLinkedList<int> obj = new GenericLinkedList<int>();
            obj.AddStart(78);
            obj.AddStart(89);
            obj.AddEnd(100);
            obj.AddStart(3);
            obj.AddStart(123);
            obj.RemoveEnd();
            obj.AddEnd(800);
            obj.RemoveStart();


            obj.ReadAll();

            GenericLinkedList<int> obj2 = new GenericLinkedList<int>();
            obj2.AddEnd(1);
            obj2.AddEnd(2);
            obj2.AddEnd(3);
            obj2.AddEnd(4);
            obj2.AddEnd(5);
            obj2.AddEnd(6);
            obj2.AddEnd(7);
            obj2.AddEnd(8);
            obj2.AddEnd(9);

            obj2.ReadAll();

            obj2.HEAD = ProblemsOnLinkedList<int>.ReverseInChunks(obj2.HEAD, 5);

            obj2.ReadAll();

            GenericLinkedList<char> obj1 = new GenericLinkedList<char>();
            obj1.AddStart('n');
            obj1.AddStart('n');
            obj1.AddEnd('i');
            obj1.AddEnd('t');
            obj1.AddEnd('t');
            obj1.AddEnd('i');
            obj1.AddEnd('n');
            obj1.AddEnd('n');

            obj1.ReadAll();
            
            if (ProblemsOnLinkedList<char>.IsPalindrome(obj1.HEAD))
                Console.WriteLine("Palindrome ");
            else
                Console.WriteLine("Not Palindrome ");

            obj1.ReadAll();

            obj.HEAD = ProblemsOnLinkedList<int>.ReverseList(obj.HEAD);

            obj.ReadAll();

            Console.WriteLine("The nth node is : " + ProblemsOnLinkedList<int>.ReturnNthNodeFromEnd(obj.HEAD, 2).data);

            Console.ReadLine();
        }
    }
}
