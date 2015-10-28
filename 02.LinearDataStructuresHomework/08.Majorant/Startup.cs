namespace Majorant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = new int[]
            {
                2, 3, 4
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

            var result = numbersCount
                .Where(x => x.Value >= numbers.Length / 2 + 1)
                .ToList();
            if (result.Count == 0)
            {
                Console.WriteLine(value: "No majorant");
            }
            else
            {
                Console.WriteLine(result.FirstOrDefault().Key);
            }
        }
    }
}