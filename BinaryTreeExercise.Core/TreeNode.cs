namespace BinaryTreeExercise.Core
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
}