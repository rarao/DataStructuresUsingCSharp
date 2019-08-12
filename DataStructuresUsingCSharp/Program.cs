using DataStructuresUsingCSharp.HeapAndPriorityQueue;
using DataStructuresUsingCSharp.LinkedList;
using DataStructuresUsingCSharp.Queues;
using DataStructuresUsingCSharp.Stacks;
using DataStructuresUsingCSharp.Trees;
using Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp
{
    class Program
    {
        public struct Circle
        {
            public int x;
            public int y;
            public int r;
        }
        public struct Rect
        {
            public int x1;
            public int y1;
            public int x2;
            public int y2;
        }
        public static double CalculateAreaInsideRect(List<Circle> circles, Rect rect)
        {
            double totalArea = 0;
            foreach (var cir in circles)
            {
                double excludeArea = 0;
                if (cir.x - cir.r < rect.x1)
                {
                    excludeArea += ExcludeArea(rect.x1 - (cir.x - cir.r), cir.r);
                }
                if (cir.x + cir.r > rect.x2)
                {
                    excludeArea += ExcludeArea((cir.x + cir.r) - rect.x2, cir.r);
                }
                if (cir.y - cir.r < rect.y1)
                {
                    excludeArea += ExcludeArea(rect.y1 - (cir.y - cir.r), cir.r);
                }
                if (cir.y + cir.r > rect.y2)
                {
                    excludeArea += ExcludeArea((cir.y + cir.r) - rect.y2, cir.r);
                }
                double area = 3.14 * cir.r * cir.r - excludeArea;
                totalArea += area;
            }
            return totalArea;
        }
        public static double ExcludeArea(double l, int r)
        {
            double h;
            double theta;
            if (l >= 2*r)
            {
                return 3.14 * r * r;
            }
            else if(l==r)
            {
                return 3.14 * r * r / 2;
            }

            h = Math.Abs(l - r);
            double segmentArea = r * r *(Math.Cosh(h / r)) - h * Math.Sqrt(r * r - h * h);

            if (l > r)
                segmentArea = 3.14 * r * r - segmentArea;

            return segmentArea;
        }
        static void Main(string[] args)
        {
        string line1 = Console.ReadLine();
            int N = Convert.ToInt32(line1.Split()[0]);
            int Q = Convert.ToInt32(line1.Split()[1]);

            List<Circle> circles = new List<Circle>();
            for (int i = 0; i < N; i++)
            {
                Circle c;
                string line2 = Console.ReadLine();
                c.x = Convert.ToInt32(line2.Split()[0]);
                c.y = Convert.ToInt32(line2.Split()[1]);
                c.r = Convert.ToInt32(line2.Split()[2]);
                circles.Add(c);
            }

            List<Rect> rectangles = new List<Rect>();
            for (int i = 0; i < Q; i++)
            {
                Rect r;
                string line3 = Console.ReadLine();
                r.x1 = Convert.ToInt32(line3.Split()[0]);
                r.y1 = Convert.ToInt32(line3.Split()[1]);
                r.x2 = Convert.ToInt32(line3.Split()[2]);
                r.y2 = Convert.ToInt32(line3.Split()[3]);
                rectangles.Add(r);
            }

            foreach (var rectangle in rectangles)
            {
                Console.WriteLine(CalculateAreaInsideRect(circles, rectangle));
            }
            int[] states = { 0, 1, 0, 0, 1, 0, 1, 0 };
            string binary1 = "";

            for (int i = 0; i < states.Length; i++)
            {
                binary1 += states[i].ToString();
            }
            int decimal1 = Convert.ToInt32(binary1, 2);
            string result = binary1;
            for (int k = 0; k < 2; k++)
            {
                int decimal2 = decimal1 << 2;

                int resultDecimal = decimal1 ^ decimal2;

                resultDecimal = resultDecimal >> 1;
                result = Convert.ToString(resultDecimal, 2);


                for (int i = 0; i < 8 - result.Length; i++)
                {
                    result = "0" + result;
                }

                result = result.Substring(result.Length - 8);
                decimal1 = Convert.ToInt32(result, 2);
            }

            int[] FinalStates = new int[8];
            for (int i = 0; i < result.Length; i++)
            {
                FinalStates[i] = Convert.ToInt32(result[i] - 48);
            }

            int []arr = new int[]{8,10,4,10,0,45,102,1,45,11,12,12,3,899,76,98,33};
            //SortingAlgorithm.MergeSort(arr,0,arr.Length-1);
            SortingAlgorithm.HeapSort(arr);

            for (int i=0;i<arr.Length;i++)
            {
                Console.WriteLine(arr[i]);
            }

            RBTree rbTree = new RBTree(1);
            rbTree.InsertNode(2);
            rbTree.InsertNode(3);
            rbTree.InsertNode(4);
            rbTree.InsertNode(5);
            rbTree.InsertNode(6);
            rbTree.InsertNode(7);
            rbTree.InsertNode(8);

            rbTree.LevelOrderTraversal();

            rbTree.ROOT = rbTree.DeleteNode(rbTree.ROOT, 1);
            rbTree.ROOT = rbTree.DeleteNode(rbTree.ROOT, 3);
            Console.WriteLine();
            rbTree.LevelOrderTraversal();
            rbTree.ROOT = rbTree.DeleteNode(rbTree.ROOT, 7);
            Console.WriteLine();
            rbTree.LevelOrderTraversal();

            AVLTree avlTree = new AVLTree(1);
            avlTree.InsertNode(2);
            avlTree.InsertNode(3);
            avlTree.InsertNode(4);
            avlTree.InsertNode(5);
            avlTree.InsertNode(6);
            avlTree.InsertNode(7);
            avlTree.InsertNode(8);

            avlTree.LevelOrderTraversal();

            avlTree.ROOT = avlTree.DeleteNode(avlTree.ROOT, 1);
            avlTree.ROOT = avlTree.DeleteNode(avlTree.ROOT, 3);
            Console.WriteLine();
            avlTree.LevelOrderTraversal();

            BinaryTree<int> bTree = new BinaryTree<int>(1);
            bTree.AddNode(bTree.ROOT, 2, 2);
            bTree.AddNode(bTree.ROOT, 3, 3);
            bTree.AddNode(bTree.ROOT, 5, 4);
            bTree.AddNode(bTree.ROOT, 7, 5);
            bTree.AddNode(bTree.ROOT, 11, 6);

            bTree.LevelOrderTraversal();

            CircularArrayQueue<int> objq = new CircularArrayQueue<int>();
            objq.Enqueue(1);
            objq.Enqueue(2);
            objq.Enqueue(3);
            objq.Enqueue(6);
            objq.Dequeue();
            objq.Enqueue(4);
            objq.Dequeue();
            objq.ReadAll();

            Console.WriteLine(ProblemsOnStacks.MaxSpan(new int[] { 100,60,80,90,70,75,11,120}));

            Console.WriteLine(ProblemsOnStacks.InfixToPostfix("a*b+c-(d+f)"));

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
