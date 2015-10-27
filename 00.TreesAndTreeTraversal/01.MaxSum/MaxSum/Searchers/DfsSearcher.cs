namespace MaxSum.Searchers
{
    using System.IO;
    using System.Collections.Generic;

    using Contracts;
    using TreeComponents.Contracts;

    public class DfsSearcher<T> : ISearcher<T>
    {
        private dynamic maxSum;
        private readonly ICollection<INode<T>> usedNodes;

        public DfsSearcher()
        {
            this.maxSum = 0;
            this.usedNodes = new List<INode<T>>();
        }

        public T GetResult(INode<T> startNode)
        {
            this.Dfs(node: startNode, currentSum: default(T));
            this.usedNodes.Clear();
            return maxSum;
        }

        public void WriteResultOn(TextWriter writer)
        {
            writer.WriteLine(maxSum);
        }

        private void Dfs(INode<T> node, T currentSum)
        {
            if (this.usedNodes.Contains(node))
            {
                return;
            }
            
            this.usedNodes.Add(node);
            T localCurrentSum = (dynamic)currentSum + node.Value;
            for (int i = 0; i < node.ChildrenCount; i++)
            {
                this.Dfs(node.GetChildAt(i), localCurrentSum);
            }

            if (node.ChildrenCount == 1 && localCurrentSum > maxSum)
            {
                this.maxSum = localCurrentSum;
            }
        }
    }
}
