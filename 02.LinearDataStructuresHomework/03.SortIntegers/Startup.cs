namespace SortIntegers
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

            numbers.Sort();
        }
    }
}
