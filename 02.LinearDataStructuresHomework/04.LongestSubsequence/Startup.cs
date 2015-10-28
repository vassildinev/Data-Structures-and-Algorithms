namespace LongestSubsequence
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            var numbers = new List<int>();
            while (line != string.Empty)
            {
                int currentNumber = int.Parse(line);
                numbers.Add(currentNumber);
                line = Console.ReadLine();
            }

            var searcher = new LongestSubsequenceSearcher();
            int bestResult = searcher.Run(numbers);
            Console.WriteLine(bestResult);
        }
    }
}
