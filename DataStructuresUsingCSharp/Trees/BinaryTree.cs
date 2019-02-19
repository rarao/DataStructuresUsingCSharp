using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.Trees
{
    public class BTNode<T>
    {
        public T data;
        public BTNode<T> left = null;
        public BTNode<T> right = null;

        public BTNode(T data)
        {
            this.data = data;
        }
    }
    // A tree having atmost 2 children for any node
    public class BinaryTree<T>
    {
        BTNode<T> root;

        public BTNode<T> ROOT
        {
            get { return this.root; }
        }
        public BinaryTree(T data)
        {
            root = new BTNode<T>(data);
        }

        // nodeNum represents the node number as per level order traversal assuming every node has exactly 2 children
        // it is not that every node will have exactly 2 children, it is just that nodeNum represent a position of the node to 
        // be inserted and that position is as per a tree having 2 children for each node
        public void AddNode(BTNode<T> rt, int nodeNum, T val)
        {
            if (rt != null)
            {
                int addNodeAtLevel = (int)Math.Floor(Math.Log(nodeNum, 2));

                if ((int)Math.Floor(nodeNum/(Math.Pow(2, addNodeAtLevel - 1) * 3)) == 0)
                {
                    if (addNodeAtLevel == 1)
                    {
                        if (rt.left != null && !rt.left.data.Equals(val))
                        {
                            rt.left.data = val;
                        }
                        else
                        {
                            rt.left = new BTNode<T>(val);
                        }
                        return;
                    }
                    AddNode(rt.left, nodeNum - (int)Math.Pow(2, addNodeAtLevel - 1), val);
                }
                else
                {
                    if (addNodeAtLevel == 1)
                    {
                        if (rt.right != null && !rt.right.data.Equals(val))
                        {
                            rt.right.data = val;
                        }
                        else
                        {
                            rt.right = new BTNode<T>(val);
                        }
                        return;
                    }
                    AddNode(rt.right, nodeNum - (int)Math.Pow(2, addNodeAtLevel), val);
                }
            }
            else
            {
                throw new Exception("Invalid position for node to be added");
            }
        }

        public void LevelOrderTraversal()
        {
            Queue<BTNode<T>> myQueue = new Queue<BTNode<T>>();
            myQueue.Enqueue(root);

            while (myQueue.Count > 0)
            {
                BTNode<T> temp = myQueue.Dequeue();
                Console.Write(temp.data + " ");

                if (temp.left != null)
                    myQueue.Enqueue(temp.left);
                if (temp.right != null)
                    myQueue.Enqueue(temp.right);
            }
        }
    }
}
