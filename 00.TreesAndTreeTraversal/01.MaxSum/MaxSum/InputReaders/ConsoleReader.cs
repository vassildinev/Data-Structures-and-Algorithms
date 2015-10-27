namespace MaxSum.InputReaders
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using System.Linq;

    public class ConsoleReader : IReader
    {
        public IEnumerable<KeyValuePair<int, int>> GetData()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());

            var result = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                string line = Console.ReadLine();
                List<int> commandComponents = line
                    .Split(new char[] { '(', '<', '-', ')' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToList();

                result.Add(new KeyValuePair<int, int>(commandComponents[0], commandComponents[1]));
            }

            return result;
        }
    }
}
