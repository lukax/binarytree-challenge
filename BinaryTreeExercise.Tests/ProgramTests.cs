using System;
using System.Text.RegularExpressions;
using BinaryTreeExercise.Core;
using FluentAssertions;
using Xunit;

namespace BinaryTreeExercise.Tests
{
    public class ProgramTests
    {
        private string RemoveWhitespace(string str)
        {
            return Regex.Replace(str, @"\s+", string.Empty);
        }

        [Fact]
        public void Example1()
        {
            var example1 = new (string value1, string value2)[]
            {
                ("A", "B"),
                ("A", "C"),
                ("B", "G"),
                ("C", "H"),
                ("E", "F"),
                ("B", "D"),
                ("C", "E"),
            };

            var root = new TreeNode("A");
            root.Left = new TreeNode("B");
            root.Right = new TreeNode("C");
            root.Left.Left = new TreeNode("G");
            root.Left.Right = new TreeNode("D");
            root.Right.Left = new TreeNode("E");
            root.Right.Right = new TreeNode("H");
            root.Right.Left.Right = new TreeNode("F");

            var treeBuilder = new BinaryTreeBuilder();
            treeBuilder.GenerateTree(example1);

            var result = treeBuilder.PrintTree(root);
            RemoveWhitespace(result).Should().Be(RemoveWhitespace(@"
            A[
               [B[G][D]]
               [C[E[F]][H]]
            ]"));
        }

        [Fact]
        public void Example2()
        {
            var example2 = new (string value1, string value2)[]
            {
                ("B", "D"),
                ("D", "E"),
                ("A", "B"),
                ("C", "F"),
                ("E", "G"),
                ("A", "C"),
            };

            var root = new TreeNode("A");
            root.Left = new TreeNode("B");
            root.Right = new TreeNode("C");
            root.Right.Left = new TreeNode("F");
            root.Left.Left = new TreeNode("D");
            root.Left.Left.Left = new TreeNode("E");
            root.Left.Left.Left.Left = new TreeNode("G");

            var treeBuilder = new BinaryTreeBuilder();

            var result = treeBuilder.PrintTree(root);
            RemoveWhitespace(result).Should().Be(RemoveWhitespace(@"
            A[
               [B[D[E[G]]]]
               [C[F]]
            ]"));
        }

        [Fact]
        public void Example3()
        {
            var example3 = new (string value1, string value2)[]
            {
                ("A", "B"),
                ("A", "C"),
                ("B", "D"),
                ("D", "C"),
            };

            var treeBuilder = new BinaryTreeBuilder();

            Func<string> printFunc = () => treeBuilder.PrintTree(treeBuilder.GenerateTree(example3));
            printFunc.Should()
                .Throw<ArgumentException>()
                .Where(x=> x.Message == "Exceção E3");
        }
    }
}
