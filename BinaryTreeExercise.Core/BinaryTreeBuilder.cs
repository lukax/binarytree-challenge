using System.Collections.Generic;
using System.Text;

namespace BinaryTreeExercise.Core
{
    public class BinaryTreeBuilder
    {
        public string PrintTree(TreeNode root)
        {
            var stringBuilder = new StringBuilder();
            PrintRoot(root, stringBuilder);
            return stringBuilder.ToString();
        }

        public TreeNode GenerateTree((string u, string v)[] tuples)
        {
            var children = new Dictionary<string, HashSet<string>>();
            var nodes = new HashSet<string>();

            foreach (var (u,v) in tuples)
            {
                if (!children.ContainsKey(u))
                {
                    children[u] = new HashSet<string>();
                }
                children[u].Add(v);
                nodes.Add(u);
                nodes.Add(v);
            }

            bool DFS(string start, string target)
            {
                if (start == target) return true;

                var result = false;
                if (children.ContainsKey(start))
                {
                    foreach (var next_node in children[start])
                    {
                        if (next_node != start)
                        {
                            result = result || DFS(next_node, target);
                        }
                    }
                }

                return result;
            }

            foreach (var node in nodes)
            {
                if (children.ContainsKey(node))
                {
                    foreach (var child in children[node])
                    {
                        var found = false;
                        foreach (var other_child in children[node])
                        {
                            if (other_child != child && DFS(other_child, child))
                            {
                                found = true;
                                break;
                            }
                        }

                        if (found)
                        {
                            children[node].Remove(child);
                        }
                    }
                }
            }

            return null;
            //var treeNodes = tuples.Select(x => new TreeNode(x.Root).)    
        }


        private void PrintRoot(TreeNode node, StringBuilder stringBuilder)
        {
            if (node == null)
                return;

            stringBuilder.Append(node.Name);

            if (!GetIsLeafNode(node))
            {
                stringBuilder.Append("[");
                stringBuilder.Append("\n");

                if (node.Left != null)
                {
                    stringBuilder.Append("[");
                    PrintSub(node.Left, stringBuilder);
                    stringBuilder.Append("]");
                }

                stringBuilder.Append("\n");

                if (node.Right != null)
                {
                    stringBuilder.Append("[");
                    PrintSub(node.Right, stringBuilder);
                    stringBuilder.Append("]");
                }

                stringBuilder.Append("\n");
                stringBuilder.Append("]");
            }
        }

        private void PrintSub(TreeNode node, StringBuilder stringBuilder)
        {
            if (node == null)
                return;

            var isLeaf = GetIsLeafNode(node);
            
            if (isLeaf)
            {
                stringBuilder.Append("[");
                stringBuilder.Append(node.Name);
                stringBuilder.Append("]");
            }
            else
            {
                stringBuilder.Append(node.Name);

                if (GetIsLeafNode(node.Left) && GetIsLeafNode(node.Right))
                {
                    PrintSub(node.Left, stringBuilder);
                    PrintSub(node.Right, stringBuilder);
                }
                else
                {
                    if (!GetIsLeafNode(node.Left))
                    {
                        stringBuilder.Append("[");
                    }
                    PrintSub(node.Left, stringBuilder);
                    if (!GetIsLeafNode(node.Left))
                    {
                        stringBuilder.Append("]");
                    }

                    if (!GetIsLeafNode(node.Right))
                    {
                        stringBuilder.Append("[");
                    }
                    PrintSub(node.Right, stringBuilder);
                    if (!GetIsLeafNode(node.Right))
                    {
                        stringBuilder.Append("]");
                    }
                }

            }


        }

        private bool GetIsLeafNode(TreeNode node)
        {
            return node?.Left == null && node?.Right == null;
        }
    }
}