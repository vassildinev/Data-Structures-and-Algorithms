namespace MaxSum.Searchers.Contracts
{
    using System.IO;

    using TreeComponents.Contracts;

    public interface ISearcher<T>
    {
        T GetResult(INode<T> startNode);

        void WriteResultOn(TextWriter writer);
    }
}
