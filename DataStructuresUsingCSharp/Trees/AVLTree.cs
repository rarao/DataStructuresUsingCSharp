using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.Trees
{
    public class AVLNode
    {
        public int data;
        public AVLNode left;
        public AVLNode right;
        public int height;  //height of the node
        public int bf;  //balancing factor of the node

        public AVLNode(int val)
        {
            this.data = val;
            this.height = 0;
            this.bf = 0;
            this.left = null;
            this.right = null;
        }
    }
    public class AVLTree
    {
        AVLNode root;
        public AVLTree(int data)
        {
            root = new AVLNode(data);
        }

        public AVLNode ROOT
        {
            get { return this.root; }
            set { this.root = value; }
        }

        //Iterative Version
        public void InsertNode(int val)
        {
            AVLNode temp = root;
            Stack<AVLNode> parentStack = new Stack<AVLNode>();

            while (temp != null)
            {
                parentStack.Push(temp);
                if (val < temp.data)
                    temp = temp.left;
                else if (val > temp.data)
                    temp = temp.right;
                else
                    return;
            }
            temp = new AVLNode(val);

            if (parentStack.Count != 0)
            {
                AVLNode temp1 = parentStack.Pop();
                if (val < temp1.data)
                    temp1.left = temp;
                else
                    temp1.right = temp;
                Update(temp1);

                while (parentStack.Count != 0 && (temp1.bf != -2 && temp1.bf != 2))
                {
                    temp1 = parentStack.Pop();
                    Update(temp1);
                }

                if (parentStack.Count != 0)
                {
                    temp = parentStack.Pop();
                    if (temp.data > val)
                        temp.left = Balance(temp1);
                    else
                        temp.right = Balance(temp1);
                }
                else
                {
                    root = Balance(temp1);
                }
            }
            else
                root = new AVLNode(val);

        }

        //Recursive version
        public AVLNode DeleteNode(AVLNode rootnode, int val)
        {
            if (rootnode != null)
            {
                if (rootnode.data == val)
                {
                    if (rootnode.left == null || rootnode.right == null)
                    {
                        if (rootnode.left != null)
                            rootnode = rootnode.left;
                        else
                            rootnode = rootnode.right;
                    }
                    else
                    {
                        AVLNode temp = FindMax(rootnode.left);
                        rootnode.data = temp.data;
                        rootnode.left = DeleteNode(rootnode.left, temp.data);
                    }
                }
                else if (rootnode.data > val)
                    rootnode.left = DeleteNode(rootnode.left, val);
                else
                    rootnode.right = DeleteNode(rootnode.right, val);

                if (rootnode != null)
                {
                    Update(rootnode);
                    rootnode = Balance(rootnode);
                }
            }
            return rootnode;
        }

        private AVLNode FindMax(AVLNode rootnode)
        {
            if (rootnode != null)
            {
                while (rootnode.right != null)
                {
                    rootnode = rootnode.right;
                }
            }
            return rootnode;
        }

        private void Update(AVLNode node)
        {
            int leftSubTreeHeight = (node.left == null) ? -1 : node.left.height;
            int rightSubTreeHeight = (node.right == null) ? -1 : node.right.height;

            node.bf = leftSubTreeHeight - rightSubTreeHeight;
            node.height = 1 + Math.Max(leftSubTreeHeight, rightSubTreeHeight);
        }

        private AVLNode Balance(AVLNode temp1)
        {
            if (temp1.bf == -2)
            {
                if (temp1.right.bf <= 0)
                    temp1 = RightRightCase(temp1);
                else
                    temp1 = RightLeftCase(temp1);
            }
            else if (temp1.bf == 2)
            {
                if (temp1.left.bf >= 0)
                    temp1 = LeftLeftCase(temp1);
                else
                    temp1 = LeftRightCase(temp1);
            }

            return temp1;
        }

        private AVLNode RightRightCase(AVLNode node)
        {
            return LeftRotation(node);
        }
        private AVLNode RightLeftCase(AVLNode node)
        {
            node.right = RightRotation(node.right);
            return LeftRotation(node);
        }
        private AVLNode LeftLeftCase(AVLNode node)
        {
            return RightRotation(node);
        }
        private AVLNode LeftRightCase(AVLNode node)
        {
            node.left = LeftRotation(node.left);
            return RightRotation(node);
        }

        private AVLNode LeftRotation(AVLNode node)
        {
            AVLNode temp = node.right;

            node.right = temp.left;
            temp.left = node;
            Update(node);
            Update(temp);

            return temp;
        }
        private AVLNode RightRotation(AVLNode node)
        {
            AVLNode temp = node.left;

            node.left = temp.right;
            temp.right = node;

            Update(node);
            Update(temp);
            return temp;
        }
        public void LevelOrderTraversal()
        {
            Queue<AVLNode> myQueue = new Queue<AVLNode>();
            myQueue.Enqueue(root);

            while (myQueue.Count > 0)
            {
                AVLNode temp = myQueue.Dequeue();
                Console.Write(temp.data + " ");

                if (temp.left != null)
                    myQueue.Enqueue(temp.left);
                if (temp.right != null)
                    myQueue.Enqueue(temp.right);
            }
        }
    }
}
