using System;

namespace AD
{
    public partial class BinaryTree<T> : IBinaryTree<T>
    {
        public BinaryNode<T> root;

        //----------------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------------

        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree(T rootItem)
        {
            root = new BinaryNode<T>(rootItem, null, null);
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public BinaryNode<T> GetRoot()
        {
            return root;
        }

        public int Size()
        {
            return Size(root);
        }

        private int Size(BinaryNode<T> node)
        {
            if (node == null)
                return 0;
            return 1 + Size(node.left) + Size(node.right);
        }


        public int Height()
        {
            return Height(root);
        }

        private int Height(BinaryNode<T> node)
        {
            if (node == null)
                return -1; // Height of an empty tree is -1.
            return 1 + Math.Max(Height(node.left), Height(node.right));
        }

        public void MakeEmpty()
        {
            root = null;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2)
        {
            if (t1.root == t2.root && t1.root != null)
                throw new InvalidOperationException("Cannot merge a tree with itself.");

            root = new BinaryNode<T>(rootItem, t1.root, t2.root);

            // Avoid memory leaks by making the merged trees empty
            if (this != t1) t1.root = null;
            if (this != t2) t2.root = null;
        }


        /// <summary>
        /// Performs a pre-order (Node, Left, Right) traversal of the tree.
        /// </summary>
        // ---------- PREFIX ----------
        public string ToPrefixString()
        {
            return ToPrefixString(root).Trim();
        }

        private string ToPrefixString(BinaryNode<T> node)
        {
            if (node == null)
                return "NIL";

            string nodeString = node.data.ToString();
            string left = ToPrefixString(node.left);
            string right = ToPrefixString(node.right);

            // Node, Left, Right
            return $"[ {nodeString} {left} {right} ]";
        }

        // ---------- INFIX ----------
        public string ToInfixString()
        {
            return ToInfixString(root).Trim();
        }

        private string ToInfixString(BinaryNode<T> node)
        {
            if (node == null)
                return "NIL";

            string left = ToInfixString(node.left);
            string nodeString = node.data.ToString();
            string right = ToInfixString(node.right);

            // Left, Node, Right
            return $"[ {left} {nodeString} {right} ]";
        }

        // ---------- POSTFIX ----------
        public string ToPostfixString()
        {
            return ToPostfixString(root).Trim();
        }

        private string ToPostfixString(BinaryNode<T> node)
        {
            if (node == null)
                return "NIL";

            string left = ToPostfixString(node.left);
            string right = ToPostfixString(node.right);
            string nodeString = node.data.ToString();

            // Left, Right, Node
            return $"[ {left} {right} {nodeString} ]";
        }



        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public int NumberOfLeaves()
        {
            return NumberOfLeaves(root);
        }

        private int NumberOfLeaves(BinaryNode<T> node)
        {
            if (node == null)
                return 0;
            if (node.left == null && node.right == null)
                return 1;
            return NumberOfLeaves(node.left) + NumberOfLeaves(node.right);
        }

        public int NumberOfNodesWithOneChild()
        {
            return NumberOfNodesWithOneChild(root);
        }

        private int NumberOfNodesWithOneChild(BinaryNode<T> node)
        {
            if (node == null)
                return 0;

            int count = 0;
            if ((node.left != null && node.right == null) || (node.left == null && node.right != null))
            {
                count = 1;
            }

            return count + NumberOfNodesWithOneChild(node.left) + NumberOfNodesWithOneChild(node.right);
        }

        public int NumberOfNodesWithTwoChildren()
        {
            return NumberOfNodesWithTwoChildren(root);
        }

        private int NumberOfNodesWithTwoChildren(BinaryNode<T> node)
        {
            if (node == null)
                return 0;

            int count = 0;
            if (node.left != null && node.right != null)
            {
                count = 1;
            }

            return count + NumberOfNodesWithTwoChildren(node.left) + NumberOfNodesWithTwoChildren(node.right);
        }
    }
}