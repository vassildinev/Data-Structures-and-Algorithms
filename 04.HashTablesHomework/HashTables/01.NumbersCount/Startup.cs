namespace NumbersCount
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var numbers = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            var numbersAndCounts = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                double number = numbers[i];

                if (!numbersAndCounts.ContainsKey(number))
                {
                    numbersAndCounts[number] = 0;
                }

                numbersAndCounts[number] += 1;
            }

            foreach (var item in numbersAndCounts)
            {
                Console.WriteLine($"{item.Key} -> {item.Value} times");
            }
        }
    }
}
