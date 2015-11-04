namespace Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static int maxDepth = 0;
        private static IList<Node<int>> longestPath;
        private static IList<Node<int>> currentPath = new List<Node<int>>();

        public static void Main()
        {
            IDictionary<int, Node<int>> nodes = new Dictionary<int, Node<int>>();

            int nodesCount = int.Parse(Console.ReadLine());
            int connectionsCount = nodesCount - 1;

            for (int i = 0; i < connectionsCount; i++)
            {
                string nodesPair = Console.ReadLine();
                int[] nodesValues = nodesPair
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();

                int parentValue = nodesValues[0];
                int childValue = nodesValues[1];
                if (!nodes.ContainsKey(parentValue))
                {
                    nodes[parentValue] = new Node<int>(parentValue);
                }

                if (!nodes.ContainsKey(childValue))
                {
                    nodes[childValue] = new Node<int>(childValue);
                }

                nodes[parentValue].AddChild(nodes[childValue]);
            }

            Node<int> root = GetRootNode(nodes);
            GetLeafNodes(nodes);
            GetMiddleNodes(nodes);
            GetMaxDepth(root, 0);

            Console.WriteLine($"Max path depth: {maxDepth}");
            PrintPath(longestPath);

            int targetSum = 9;
            int startSum = 0;
            Console.WriteLine($"Paths with sum {targetSum}:");
            currentPath = new List<Node<int>>();
            GetPathsWithSum(root, targetSum, startSum);
        }

        private static void PrintPath<T>(IList<Node<T>> nodes)
            where T : IComparable<T>
        {
            Console.WriteLine(string.Join(" -> ", nodes.Select(n => n.Value)));
        }

        private static void GetPathsWithSum(Node<int> root, int sum, int currentSum)
        {
            if (root.ChildrenCount == 0)
            {
                currentPath.Add(root);
                if (currentSum + root.Value == sum)
                {
                    PrintPath(currentPath);
                }

                currentPath.Remove(root);
                return;
            }

            currentPath.Add(root);
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                GetPathsWithSum(root.Children[i], sum, currentSum + root.Value);
            }

            currentPath.Remove(root);
        }

        private static void GetMaxDepth(Node<int> root, int depth)
        {
            if (root.ChildrenCount == 0)
            {
                currentPath.Add(root);
                if (depth > maxDepth)
                {
                    maxDepth = depth;
                    longestPath = new List<Node<int>>(currentPath);
                    return;
                }

                currentPath.Remove(root);
            }

            if (depth > maxDepth)
            {
                maxDepth = depth;
            }

            currentPath.Add(root);
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                GetMaxDepth(root.Children[i], depth + 1);
            }

            currentPath.Remove(root);
        }

        private static void GetMiddleNodes(IDictionary<int, Node<int>> nodes)
        {
            ICollection<Node<int>> middleNodes = nodes
                            .Where(n => n.Value.ChildrenCount != 0 && n.Value.Parent != null)
                            .Select(n => n.Value)
                            .ToList();

            Console.Write(value: "Middle nodes:");
            foreach (Node<int> middleNode in middleNodes)
            {
                Console.Write(" " + middleNode.Value);
            }

            Console.WriteLine();
        }

        private static void GetLeafNodes(IDictionary<int, Node<int>> nodes)
        {
            ICollection<Node<int>> leafNodes = nodes
                            .Where(n => n.Value.ChildrenCount == 0)
                            .Select(n => n.Value)
                            .ToList();

            Console.Write(value: "Leaf values:");
            foreach (Node<int> leafNode in leafNodes)
            {
                Console.Write(" " + leafNode.Value);
            }

            Console.WriteLine();
        }

        private static Node<int> GetRootNode(IDictionary<int, Node<int>> nodes)
        {
            Node<int> root = nodes
                            .Where(n => n.Value.Parent == null)
                            .Select(n => n.Value)
                            .FirstOrDefault();

            Console.WriteLine($"Root value: {root.Value}");
            return root;
        }
    }
}
