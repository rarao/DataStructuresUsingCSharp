using System;
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
            while(slow != fast)
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
    }
}
