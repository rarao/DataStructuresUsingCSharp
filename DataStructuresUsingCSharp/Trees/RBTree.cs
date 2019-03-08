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

        public RBNode DeleteNode(RBNode rootnode, int val)
        {
            bool doubleBlackExists = false;
            RBNode parent = null;
            if (rootnode != null)
            {
                if (rootnode.data == val)
                {
                    if (rootnode.left == null || rootnode.right == null)
                    {
                        bool isLeft = true;
                        parent = rootnode.parent;
                        if (parent != null)
                        {
                            if (parent.right == rootnode)
                                isLeft = false;
                        }

                        if (rootnode.color == 1)
                            doubleBlackExists = true;

                        if (rootnode.left != null)
                        {
                            rootnode = rootnode.left;
                            rootnode.parent = parent;
                        }
                        else if (rootnode.right != null)
                        {
                            rootnode = rootnode.right;
                            rootnode.parent = parent;
                        }
                        else
                        {
                            rootnode = null;
                        }
                        if (parent != null)
                        {
                            if (isLeft)
                                parent.left = rootnode;
                            else
                                parent.right = rootnode;
                        }
                    }
                    else
                    {
                        RBNode temp = FindMax(rootnode.left);
                        rootnode.data = temp.data;

                        rootnode = DeleteNode(rootnode.left, temp.data);
                    }
                }
                else if (rootnode.data > val)
                    rootnode = DeleteNode(rootnode.left, val);
                else
                    rootnode = DeleteNode(rootnode.right, val);

                if (doubleBlackExists)
                    rootnode = RemoveDoubleBlack(rootnode, parent);

                if (rootnode == null)
                    rootnode = parent;
                while (rootnode.parent != null)
                {
                    rootnode = rootnode.parent;
                }
            }

            return rootnode;
        }

        private static bool IsBlack(RBNode node)
        {
            return (node == null || node.color == 1);
        }
        private static bool IsRed(RBNode node)
        {
            return (node != null && node.color == 0);
        }

        private RBNode RemoveDoubleBlack(RBNode db, RBNode parent)
        {
            bool dbExist = false;
            if (parent == null)
            {
                return db;
            }
            if (parent.left == db)
            {
                if (parent.right == null)
                {
                    if (parent.color == 0)
                        parent.color = 1;
                    else
                        dbExist = true;
                    db = parent;
                }
                else if (parent.right.color == 0)
                {
                    SwapColors(parent, parent.right);
                    LeftRotation(parent);
                    return RemoveDoubleBlack(db, parent);
                }
                else if ((parent.right.color == 1 && IsBlack(parent.right.right) && IsBlack(parent.right.left)))
                {
                    if (parent.color == 0)
                        parent.color = 1;
                    else
                        dbExist = true;
                    parent.right.color = 0;
                    db = parent;
                }
                else if ((parent.right.color == 1 && IsBlack(parent.right.right) && IsRed(parent.right.left)))
                {
                    SwapColors(parent.right, parent.right.left);
                    RightRotation(parent.right);
                }
                if ((parent.right.color == 1 && IsRed(parent.right.right)))
                {
                    SwapColors(parent, parent.right);
                    LeftRotation(parent);
                    if (parent.color == 0)
                        parent.color = 1;
                    else
                        dbExist = true;
                    parent.right.right.color = 1;
                    db = parent;
                }
            }
            else
            {
                if (parent.left == null)
                {
                    if (parent.color == 0)
                        parent.color = 1;
                    else
                        dbExist = true;
                    db = parent;
                }
                else if (parent.left.color == 0)
                {
                    SwapColors(parent, parent.left);
                    RightRotation(parent);
                    return RemoveDoubleBlack(db, parent);
                }
                else if ((parent.left.color == 1 && IsBlack(parent.left.left) && IsBlack(parent.left.right)))
                {
                    if (parent.color == 0)
                        parent.color = 1;
                    else
                        dbExist = true;
                    parent.left.color = 0;
                    db = parent;
                }
                else if ((parent.left.color == 1 && IsBlack(parent.left.left) && IsRed(parent.left.right)))
                {
                    SwapColors(parent.left, parent.left.right);
                    LeftRotation(parent.left);
                }
                if ((parent.left.color == 1 && IsRed(parent.left.left)))
                {
                    SwapColors(parent, parent.left);
                    RightRotation(parent);
                    if (parent.color == 0)
                        parent.color = 1;
                    else
                        dbExist = true;
                    parent.left.left.color = 1;
                    db = parent;
                }
            }
            if (dbExist)
                return RemoveDoubleBlack(db.parent, db.parent.parent);
            else
            {
                while (db.parent != null)
                {
                    db = db.parent;
                }
                return db;
            }
        }

        private void SwapColors(RBNode a, RBNode b)
        {
            int temp = a.color;
            a.color = b.color;
            b.color = temp;
        }

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
            if (temp.parent != null)
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
