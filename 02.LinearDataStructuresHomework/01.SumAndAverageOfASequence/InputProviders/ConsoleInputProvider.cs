namespace SumAndAverageOfASequence.InputProviders
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        public IEnumerable<int> ReadData()
        {
            ICollection<int> result = new List<int>();

            string line = Console.ReadLine();
            while (line != string.Empty)
            {
                int number = int.Parse(line);
                result.Add(number);
                line = Console.ReadLine();
            }

            return result;
        }
    }
}
