namespace MaxSum.TreeComponents.Contracts
{
    using System.Collections.Generic;

    public interface INode<T>
    {
        T Value { get; }

        bool HasParent { get; set; }

        IList<INode<T>> Children { get; }

        int ChildrenCount { get; }

        void AddChild(INode<T> node);

        INode<T> GetChildAt(int index);
    }
}
