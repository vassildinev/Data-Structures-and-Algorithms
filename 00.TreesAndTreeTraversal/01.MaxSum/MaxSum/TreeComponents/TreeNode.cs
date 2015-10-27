namespace MaxSum.TreeComponents
{
    using System.Collections.Generic;

    using Contracts;

    public class TreeNode<T> : INode<T>
    {
        private T value;
        private IList<INode<T>> children;

        public TreeNode(T value)
        {
            this.Value = value;
            this.HasParent = false;
            this.Children = new List<INode<T>>();
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public IList<INode<T>> Children
        {
            get { return this.children; }
            private set { this.children = value; }
        }

        public int ChildrenCount
        {
            get { return this.children.Count; }
        }

        public bool HasParent { get; set; }

        public void AddChild(INode<T> node)
        {
            node.HasParent = true;
            this.children.Add(node);
        }

        public INode<T> GetChildAt(int index)
        {
            return this.children[index];
        }
    }
}
