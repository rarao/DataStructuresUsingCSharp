using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.Trees
{
    public class BSTNode
    {
        public int data;
        public BSTNode left = null;
        public BSTNode right = null;

        public BSTNode(int data)
        {
            this.data = data;
        }
    }

    public class BST
    {
        BSTNode root;

        public BSTNode ROOT
        {
            get { return this.root; }
        }
        public BST(int data)
        {
            root = new BSTNode(data);
        }

        public void AddNode(int val)
        {
            BSTNode temp = root;
            BSTNode parent = root;
            while (temp != null)
            {
                parent = temp;
                if (val < temp.data )
                    temp = temp.left;
                else if (val > temp.data)
                    temp = temp.right;
                else
                    return;
            }

            temp = new BSTNode(val);

            if (parent != null)
            {
                if (val < parent.data)
                    parent.left = temp;
                else
                    parent.right = temp;
            }
            else
                root = temp;
        }

        public BSTNode FindMax(BSTNode root)
        {
            if (root != null)
            {
                while (root.right != null)
                {
                    root = root.right;
                }
                return root;
            }
            else
                return null;
        }

        public void DeleteNode(BSTNode root,int data)
        {
            if(root != null)
            {
                if (data < root.data)
                    DeleteNode(root.left, data);
                else if (data > root.data)
                    DeleteNode(root.right, data);
                else
                {
                    if(root.left == null || root.right == null)
                    {
                        if (root.left != null)
                            root = root.left;
                        else
                            root = root.right;
                    }
                    else
                    {
                        BSTNode temp = FindMax(root.left);
                        root.data = temp.data;
                        DeleteNode(root.left, root.data);
                    }
                }
            }
        }

        // This will always get sorted data
        public void InOrderTraversal(BSTNode root)
        {
            if (root != null)
            {
                InOrderTraversal(root.left);
                Console.Write(root.data + " ");
                InOrderTraversal(root.right);
            }
        }
        public void LevelOrderTraversal()
        {
            Queue<BSTNode> myQueue = new Queue<BSTNode>();
            myQueue.Enqueue(root);

            while (myQueue.Count > 0)
            {
                BSTNode temp = myQueue.Dequeue();
                Console.Write(temp.data + " ");

                if (temp.left != null)
                    myQueue.Enqueue(temp.left);
                if (temp.right != null)
                    myQueue.Enqueue(temp.right);
            }
        }
    }
}
