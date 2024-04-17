using System.Text;
using static _2024LeetCode.Helpers.ListHelpers;

namespace _2024LeetCode
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }

        public TreeNode(int val)
        {
            Value = val;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree
    {
        public TreeNode Root { get; set; }

        public BinaryTree(TreeNode root)
        {
            Root = root;
        }

        public void Insert(int value)
        {
            Root = InsertRecursive(Root, value);
        }

        private TreeNode InsertRecursive(TreeNode node, int value)
        {
            if (node == null) return new TreeNode(value);
            

            if (value < node.Value)            
                node.Left = InsertRecursive(node.Left, value);            
            else            
                node.Right = InsertRecursive(node.Right, value);            

            return node;
        }

        public void TraverseRecursive(TreeNode node, List<int> currentPath, List<List<int>> allPaths)
        {
            if (node == null) return;

            currentPath.Add(node.Value);

            if (node.Left == null && node.Right == null)
                allPaths.Add(new List<int>(currentPath));

            TraverseRecursive(node.Left, currentPath, allPaths);
            TraverseRecursive(node.Right, currentPath, allPaths);

            currentPath.RemoveAt(currentPath.Count - 1);
        }

        public string PrintTree()
        {
            StringBuilder sb = new();
            PrintTreeRecursive(Root, sb, 0);
            return sb.ToString();
        }

        private void PrintTreeRecursive(TreeNode node, StringBuilder sb, int depth)
        {
            if (node == null) return;            

            PrintTreeRecursive(node.Right, sb, depth + 1);

            sb.Append(new string(' ', depth * 4));
            sb.AppendLine(node.Value.ToString());

            PrintTreeRecursive(node.Left, sb, depth + 1);
        }
    }
    
    internal class BinaryTreeRootToLeafPaths
    {
        
        public static void TestGetAllRootToLeafPaths()
        {
            BinaryTree tree = new(new TreeNode(5));
            tree.Root.Left = new TreeNode(3);
            tree.Root.Right = new TreeNode(7);
            tree.Root.Left.Left = new TreeNode(1);
            tree.Root.Left.Right = new TreeNode(4);
            tree.Root.Left.Left.Right = new TreeNode(2);
            tree.Root.Right.Left = new TreeNode(6);
            tree.Root.Right.Right = new TreeNode(8);
            tree.Root.Right.Right.Right = new TreeNode(9);

            List<List<int>> allRoutes = new();
            List<int> route1 = new() { 5, 3, 1, 2 };
            List<int> route2 = new() { 5, 3, 4 };
            List<int> route3 = new() { 5, 7, 6 };
            List<int> route4 = new() { 5, 7, 8, 9 };

            allRoutes.Add(route1);
            allRoutes.Add(route2);
            allRoutes.Add(route3);
            allRoutes.Add(route4);

            TestGetAllRootToLeafPaths(tree, allRoutes);
        }
        private static void TestGetAllRootToLeafPaths(BinaryTree input, List<List<int>> expected)
        {
            List<List<int>> actual = GetAllRootToLeafPaths(input);
            if (AreListListIntEqual(actual, expected))
            {
                Console.WriteLine($"LongestPalindrome Pass! Tree to traverse:\n{input.PrintTree()}\nExpected: {ListListIntToString(expected)}\nActual: {ListListIntToString(actual)}");
                return;
            }
            Console.WriteLine($"LongestPalindrome Fail! Tree to traverse:\n{input.PrintTree()}\nExpected: {ListListIntToString(expected)}\nActual: {ListListIntToString(actual)}");
        }

        private static List<List<int>> GetAllRootToLeafPaths(BinaryTree tree)
        {
            List<List<int>> allPaths = new();
            List<int> currentPath = new();
            tree.TraverseRecursive(tree.Root, currentPath, allPaths);
            return allPaths;            
        }
    }
}
