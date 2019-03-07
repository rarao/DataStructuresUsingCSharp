using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.Trees
{
    public class RBNode
    {
        public int data;
        public RBNode left;
        public RBNode right;
        public int color;  //0 is RED and 1 is Black
        public RBNode parent;

        public RBNode(int val)
        {
            this.data = val;
            this.color = 0;
            this.left = null;
            this.right = null;
            this.parent = null;
        }
    }
    public class RBTree
    {
        RBNode root;
        public RBTree(int data)
        {
            root = new RBNode(data);
            root.color = 1;
        }

        public RBNode ROOT
        {
            get { return this.root; }
            set { this.root = value; }
        }

        public void InsertNode(int val)
        {
            RBNode temp = root;
            RBNode parent = root;
            while (temp != null)
            {
                parent = temp;
                if (temp.data > val)
                    temp = temp.left;
                else if (temp.data < val)
                    temp = temp.right;
                else
                    return;
            }
            RBNode z = new RBNode(val);
            z.parent = parent;
            if (parent != null)
            {
                if (parent.data > val)
                    parent.left = z;
                else
                    parent.right = z;
            }
            else
            {
                root = z;
                root.color = 1;
            }

            while ((z.parent != null) && (z.color != 1) && (z.parent.color == 0))
            {
                if (z.parent.parent.right == z.parent)
                {
                    if (z.parent.parent.left != null && z.parent.parent.left.color == 0)
                    {
                        z.parent.color = 1 - z.parent.color;
                        z.parent.parent.color = 1 - z.parent.parent.color;
                        z.parent.parent.left.color = 1 - z.parent.parent.left.color;

                        z = z.parent.parent;
                    }
                    else if (z.parent.parent.left == null || z.parent.parent.left.color == 1)
                    {
                        if (z.parent.left == z)
                        {
                            z.parent.parent.right = RightRotation(z.parent);
                        }
                        z.parent.color = 1 - z.parent.color;
                        z.parent.parent.color = 1 - z.parent.parent.color;

                        z = LeftRotation(z.parent.parent);
                    }
                }
                else
                {
                    if (z.parent.parent.right != null && z.parent.parent.right.color == 0)
                    {
                        z.parent.color = 1 - z.parent.color;
                        z.parent.parent.color = 1 - z.parent.parent.color;
                        z.parent.parent.right.color = 1 - z.parent.parent.right.color;

                        z = z.parent.parent;
                    }
                    else if (z.parent.parent.right == null || z.parent.parent.right.color == 1)
                    {
                        if (z.parent.right == z)
                        {
                            z.parent.parent.left = LeftRotation(z.parent);
                        }
                        z.parent.color = 1 - z.parent.color;
                        z.parent.parent.color = 1 - z.parent.parent.color;
                        z = RightRotation(z.parent.parent);
                    }
                }
            }
            while (z.parent != null)
            {
                z = z.parent;
            }
            root = z;
            root.color = 1;
        }

        //public RBNode DeleteNode(RBNode rootnode, int val)
        //{
        //    if (rootnode != null)
        //    {
        //        if (rootnode.data == val)
        //        {
        //            if (rootnode.left == null || rootnode.right == null)
        //            {
        //                if (rootnode.left != null)
        //                    rootnode = rootnode.left;
        //                else
        //                    rootnode = rootnode.right;
        //            }
        //            else
        //            {
        //                RBNode temp = FindMax(rootnode.left);
        //                rootnode.data = temp.data;
        //                rootnode.left = DeleteNode(rootnode.left, temp.data);
        //            }
        //        }
        //        else if (rootnode.data > val)
        //            rootnode.left = DeleteNode(rootnode.left, val);
        //        else
        //            rootnode.right = DeleteNode(rootnode.right, val);

        //        if (rootnode != null)
        //        {
        //            Update(rootnode);
        //            rootnode = Balance(rootnode);
        //        }
        //    }
        //    return rootnode;
        //}

        private RBNode FindMax(RBNode rootnode)
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

        private RBNode LeftRotation(RBNode node)
        {
            RBNode temp = node.right;

            node.right = temp.left;
            temp.left = node;

            temp.parent = node.parent;
            node.parent = temp;
            
            if (node.right != null)
                node.right.parent = node;
            if(temp.parent!=null)
                temp.parent.right = temp;

            return temp;
        }
        private RBNode RightRotation(RBNode node)
        {
            RBNode temp = node.left;

            node.left = temp.right;
            temp.right = node;

            temp.parent = node.parent;
            node.parent = temp;
            if (node.left != null)
                node.left.parent = node;
            if (temp.parent != null)
                temp.parent.left = temp;

            return temp;
        }
        public void LevelOrderTraversal()
        {
            Queue<RBNode> myQueue = new Queue<RBNode>();
            myQueue.Enqueue(root);

            while (myQueue.Count > 0)
            {
                RBNode temp = myQueue.Dequeue();
                Console.Write(temp.data + " ");

                if (temp.left != null)
                    myQueue.Enqueue(temp.left);
                if (temp.right != null)
                    myQueue.Enqueue(temp.right);
            }
        }
    }
}
