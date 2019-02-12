using DataStructuresUsingCSharp.LinkedList;
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

            obj.HEAD = ProblemsOnLinkedList<int>.ReverseList(obj.HEAD);

            obj.ReadAll();

            Console.WriteLine("The nth node is : " + ProblemsOnLinkedList<int>.ReturnNthNodeFromEnd(obj.HEAD, 2).data);

            Console.ReadLine();
        }
    }
}
