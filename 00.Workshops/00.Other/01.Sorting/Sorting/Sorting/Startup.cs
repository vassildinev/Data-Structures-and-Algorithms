namespace Sorting
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string[] numbersCountAndDivider = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            uint numbersCount = uint.Parse(numbersCountAndDivider[0]);
            uint divider = uint.Parse(numbersCountAndDivider[1]);
            var numbersByRemainders = new SortedDictionary<uint, List<uint>>();
            string[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < numbersCount; i++)
            {
                uint number = uint.Parse(numbers[i]);
                uint remainder = number % divider;
                if (!numbersByRemainders.ContainsKey(remainder))
                {
                    numbersByRemainders[remainder] = new List<uint>();
                }

                numbersByRemainders[remainder].Add(number);
            }
            
            foreach (var item in numbersByRemainders)
            {
                item.Value.Sort();
                Console.Write(string.Join(" ", item.Value) + " ");
            }
        }
    }
}
