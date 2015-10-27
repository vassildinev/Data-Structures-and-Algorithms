namespace MaxSum.InputReaders.Contracts
{
    using System.Collections.Generic;

    public interface IReader
    {
        IEnumerable<KeyValuePair<int, int>> GetData();
    }
}
