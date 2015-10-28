namespace NumberOfOccurrences
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var numbers = new int[]
            {
                3, 4, 4, 2, 3, 3, 4, 3, 2
            };

            var numbersCount = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                if (!numbersCount.ContainsKey(currentNumber))
                {
                    numbersCount[currentNumber] = 0;
                }

                numbersCount[currentNumber] += 1;
            }

            foreach (var item in numbersCount)
            {
                Console.WriteLine($"{item.Key} -> {item.Value} times");
            }
        }
    }
}
