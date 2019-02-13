using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.LinkedList
{
    public class Node
    {
        public object data = null;
        public Node next = null;
    }

    public class Node<T>
    {
        public T data;
        public Node<T> next = null;
    }
    public class RNode<T>
    {
        public T data;
        public RNode<T> next = null;
        public RNode<T> rand = null;
    }
    public class DNode<T>
    {
        public T data;
        public DNode<T> next = null;
        public DNode<T> prev = null;
    }
    public class MENode<T>
    {
        public T data;
        public MENode<T> ptrDiff = null;
    }
}
