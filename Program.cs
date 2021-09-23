using System;
using System.Linq;

namespace provadevsenior
{
    public class TreeNode
    {
        public TreeNode(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class RunProject
    {
        public static void Main()
        {
            var root = new TreeNode("A");
            root.Left = new TreeNode("B");
            root.Right = new TreeNode("C");
            root.Left.Left = new TreeNode("G");
            root.Left.Right = new TreeNode("D");
            root.Right.Left = new TreeNode("E");
            root.Right.Right = new TreeNode("H");
            root.Right.Left.Right = new TreeNode("F");

            // var root = new TreeNode("1");
            // root.Left = new TreeNode("2");
            // root.Left.Left = new TreeNode("4");
            // root.Left.Right = new TreeNode("5");
            // root.Right = new TreeNode("3");

            // Console.WriteLine("In-order:");
            // printInorder(root);
            // Console.WriteLine("");
            Console.WriteLine("Pre-order");
            printPreorderRoot(root);
            Console.WriteLine("\n]");
            // Console.WriteLine("Post-order");
            // printPostorder(root);
            // Console.WriteLine("");
            // Console.WriteLine(ProcessTree(root));
        }

        /* Given a binary tree, print its nodes in preorder*/
        private static void printPreorderRoot(TreeNode node)
        {
            if (node == null)
                return;

            /* first print data of node */
            Console.Write(node.Name + "[ \n   ");

            /* then recur on left sutree */
            printPreorder(node.Left);

            Console.Write("\n   ");

            /* now recur on right subtree */
            printPreorder(node.Right);
        }

        /* Given a binary tree, print its nodes in preorder*/
        private static void printPreorder(TreeNode node)
        {
            if (node == null)
                return;

            Console.Write("[");

            /* first print data of node */
            Console.Write(node.Name);

            /* then recur on left sutree */
            printPreorder(node.Left);

            /* now recur on right subtree */
            printPreorder(node.Right);

            Console.Write("]");
        }

        private static void buildTree(TreeInsertTuple[] tuples)
        {
            var treeNodes = tuples.Select(x => new TreeNode(x.Root).)    
        }
        
        
    }

    public class TreeInsertTuple
    {
        public string Root { get; set; }
        public string Leaf { get; set; }
    }
}