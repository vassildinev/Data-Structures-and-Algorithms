namespace SumAndAverageOfASequence.InputProviders.Contracts
{
    using System.Collections.Generic;

    public interface IInputProvider
    {
        IEnumerable<int> ReadData();
    }
}
