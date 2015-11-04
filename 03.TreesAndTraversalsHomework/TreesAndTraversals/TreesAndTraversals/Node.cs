namespace Nodes
{
    using System;
    using System.Collections.Generic;

    public class Node<T>
        where T : IComparable<T>
    {
        private readonly T value;
        private readonly ICollection<Node<T>> children;

        public Node(T value)
        {
            this.value = value;
            this.children = new List<Node<T>>();
        }

        public T Value
        {
            get { return this.value; }
        }

        public int ChildrenCount
        {
            get { return this.children.Count; }
        }

        public IList<Node<T>> Children
        {
            get { return new List<Node<T>>(this.children); }
        }

        public Node<T> Parent { get; set; }

        public void AddChild(Node<T> node)
        {
            this.children.Add(node);
            node.Parent = this;
        }
    }
}
