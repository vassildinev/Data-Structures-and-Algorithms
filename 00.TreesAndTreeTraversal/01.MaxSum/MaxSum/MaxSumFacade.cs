namespace MaxSum
{
    using System.Collections.Generic;

    using InputReaders;
    using Searchers;
    using TreeComponents.Contracts;
    using TreeComponents;
    using System.Linq;
    using System;

    public class MaxSumFacade
    {
        private static MaxSumFacade instance;

        private MaxSumFacade()
        {
        }

        public static MaxSumFacade Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MaxSumFacade();
                }

                return instance;
            }
        }

        public void Run()
        {
            var reader = new ConsoleReader();
            var searcher = new DfsSearcher<long>();
            IEnumerable<KeyValuePair<int, int>> data = reader.GetData();

            var addedNodes = new Dictionary<int, INode<long>>();
            foreach (var item in data)
            {
                if (!addedNodes.ContainsKey(item.Key))
                {
                    addedNodes.Add(item.Key, new TreeNode<long>(item.Key) { });
                }

                INode<long> parentNode = addedNodes[item.Key];

                if (!addedNodes.ContainsKey(item.Value))
                {
                    addedNodes.Add(item.Value, new TreeNode<long>(item.Value) { });
                }

                INode<long> childNode = addedNodes[item.Value];

                parentNode.AddChild(childNode);
                childNode.AddChild(parentNode);
            }

            var processedNodes = addedNodes
                .Select(kvp => kvp.Value)
                .Where(n => n.ChildrenCount == 1)
                .ToList();

            foreach (var item in processedNodes)
            {
                searcher.GetResult(item);
            }

            searcher.WriteResultOn(Console.Out);
        }
    }
}
