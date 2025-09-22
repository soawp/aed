using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AD
{
    public partial class FirstChildNextSibling<T> : IFirstChildNextSibling<T>
    {
        public FirstChildNextSiblingNode<T> root;

        public IFirstChildNextSiblingNode<T> GetRoot()
        {
            return root;
        }

        public int Size()
        {
            return Size(root);
        }

        private int Size(FirstChildNextSiblingNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            int count = 1; // Count the current node
            count += Size(node.firstChild); // Add the size of the subtree rooted at the first child
            count += Size(node.nextSibling); // Add the size of the subtree rooted at the next sibling

            return count;
        }
        public void PrintPreOrder()
        {
            PrintPreOrder(root);
        }
        private void PrintPreOrder(FirstChildNextSiblingNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.data); // Visit the current node
            PrintPreOrder(node.firstChild); // Recurse on the first child
            PrintPreOrder(node.nextSibling); // Recurse on the next sibling
        }

        public override string ToString()
        {
            return ToString(this.root);
        }

        private string ToString(FirstChildNextSiblingNode<T> node)
        {
            if (node == null)
            {
                return "NIL";
            }

            string result = node.data.ToString();

            // If a node has a first child, append the FC part.
            // The first child's recursive call will handle its own children AND siblings.
            if (node.firstChild != null)
            {
                result += $",FC({ToString(node.firstChild)})";
            }

            // If a node has a next sibling, append the NS part.
            // The next sibling's recursive call will handle its own children AND siblings.
            if (node.nextSibling != null)
            {
                result += $",NS({ToString(node.nextSibling)})";
            }

            return result;
        }

    }
}