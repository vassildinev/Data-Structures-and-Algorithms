namespace RemoveNumbersOddCount
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var numbers = new List<int>
            {
                4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2
            };
            
            var numbersCount = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Count; i++)
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
                if (item.Value % 2 == 1)
                {
                    numbers.RemoveAll(x => x == item.Key);
                }
            }

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
