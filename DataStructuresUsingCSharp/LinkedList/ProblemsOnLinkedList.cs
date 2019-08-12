using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.LinkedList
{
    public static class ProblemsOnLinkedList<T>
    {
        //Returns the nth node from the end of a linked list
        public static Node<T> ReturnNthNodeFromEnd(Node<T> Head, int n)
        {
            Node<T> curr = Head;
            int length = 0;

            while (curr != null)
            {
                length++;
                curr = curr.next;
            }

            curr = Head;
            for (int i = 0; i < length - n; i++)
                curr = curr.next;

            return curr;
        }

        // Determine whether a linked list contains a loop or not
        public static bool IsLoopPresent(Node<T> Head)
        {
            Node<T> slow = Head;
            Node<T> fast = Head;

            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
                if (fast != null)
                    fast = fast.next;
                if (fast == slow)
                    return true;
            }

            return false;
        }

        //Assuming that there is a loop in the list, find the loop length
        public static bool GetLoopLength(Node<T> Head)
        {
            Node<T> slow = Head;
            Node<T> fast = Head;

            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
                if (fast != null)
                    fast = fast.next;
                if (fast == slow)
                    break;
            }

            fast = fast.next;
            int length = 1;
            while (slow != fast)
            {
                fast = fast.next;
                length++;
            }

            return false;
        }

        //Assuming that there is a loop in the list, find the node where the loop begins
        public static Node<T> GetLoopStartNode(Node<T> Head)
        {
            Node<T> slow = Head;
            Node<T> fast = Head;

            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
                if (fast != null)
                    fast = fast.next;
                if (fast == slow)
                {
                    slow = Head;
                    break;
                }
            }
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return slow;
        }

        //Reverse a linked list
        public static Node<T> ReverseList(Node<T> Head)
        {
            if (Head != null)
            {
                Node<T> curr = Head;
                Node<T> nextNode = Head.next;

                while (nextNode != null)
                {
                    Node<T> temp = new Node<T>();
                    temp.data = nextNode.data;
                    temp.next = curr;
                    curr = temp;
                    nextNode = nextNode.next;
                }
                Head.next = null;
                Head = curr;
            }
            return Head;
        }

        //Check if a linked list is palindrome or not
        public static bool IsPalindrome(Node<T> Head)
        {
            bool result = true;

            if (Head != null)
            {
                if (Head.next != null)
                {
                    Node<T> slow = Head;
                    Node<T> fast = Head.next.next;

                    while (fast != null)
                    {
                        slow = slow.next;
                        fast = fast.next;

                        if (fast != null)
                            fast = fast.next;
                    }

                    fast = ReverseList(slow.next);
                    slow = Head;

                    while (fast != null)
                    {
                        if (!slow.data.Equals(fast.data))
                        {
                            result = false;
                            break;
                        }
                        fast = fast.next;
                        slow = slow.next;
                    }
                }
            }
            return result;
        }

        //Reverse Linked List in chunks of k
        public static Node<T> ReverseInChunks(Node<T> Head, int k)
        {
            if (Head != null)
            {
                Node<T> curr = Head;
                Node<T> startNode, nextNode;
                Node<T> prevNode = null;

                while (curr != null)
                {
                    startNode = curr;
                    for (int i = 1; i < k; i++)
                    {
                        curr = curr.next;
                        if (curr == null)
                        {
                            return Head;
                        }
                    }
                    nextNode = curr.next;
                    curr.next = null;

                    if (prevNode == null)
                        Head = ReverseList(startNode);
                    else
                        prevNode.next = ReverseList(startNode);

                    startNode.next = nextNode;
                    prevNode = startNode;
                    curr = nextNode;
                }
            }
            return Head;
        }

        //Clone a linked list with Random Ptr
        public static RNode<T> CloneRandomPtrList(RNode<T> Head)
        {
            if (Head != null)
            {
                RNode<T> curr = Head;

                while (curr != null)
                {
                    RNode<T> temp = new RNode<T>();
                    temp.data = curr.data;
                    temp.next = curr.next;
                    curr.next = temp;

                    curr = curr = temp.next;

                }

                curr = Head;

                while (curr != null)
                {
                    curr.next.rand = curr.rand.next;
                    curr = curr.next.next;
                }

                curr = Head;
                RNode<T> copy = Head.next;
                RNode<T> temp1 = copy;
                while (curr != null)
                {
                    if (curr.next != null)
                        curr.next = curr.next.next;
                    if (temp1.next != null)
                        temp1.next = temp1.next.next;

                    curr = curr.next;
                    temp1 = temp1.next;
                }
                return copy;
            }
            return null;
        }

        public static void CSharpInBuiltDataStructures()
        {
            //Generics
            LinkedList<T> linkedList = new LinkedList<T>();
            Stack<T> stack = new Stack<T>();
            Queue<T> queue = new Queue<T>();

            List<int> ls = new List<int>();   //Array
            SortedSet<T> sortedSet = new SortedSet<T>();    //RB Tree
            HashSet<int> hashSet = new HashSet<int>();          //Hashtable  
            Dictionary<int, int> dic = new Dictionary<int, int>();  //Hashtable
            SortedDictionary<int, int> sDic = new SortedDictionary<int, int>();    //RBTree
            SortedList<int, int> sortedList = new SortedList<int, int>();     //Array  (Memory efficient than SortedDictionary but slow in retrieval,insertion and deletion)

            KeyValuePair<int, int> kvp = new KeyValuePair<int, int>();


            //Non Generics
            Stack st = new Stack();
            Queue q = new Queue();            

            ArrayList aL = new ArrayList();
            Hashtable hT = new Hashtable();
            SortedList sL = new SortedList();

            DictionaryEntry dENtry = new DictionaryEntry();
            
            //**********************
            

            
        }
    }
}
