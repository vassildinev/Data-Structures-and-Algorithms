namespace RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Startup
    {
        private const int NumbersCount = 10000000;

        public static void Main()
        {
            var numbers = new HashSet<int>();

            Console.WriteLine("Generating numbers...");
            for (int i = 0; i < NumbersCount; i++)
            {
                numbers.Add(-i);
            }

            Console.WriteLine("Removing negative numbers...");
            var sw = new Stopwatch();

            sw.Start();
            numbers.RemoveWhere(x => x < 0);
            sw.Stop();

            Console.WriteLine($"Removal elapsed time: {(int)sw.Elapsed.TotalMilliseconds}ms");
            Console.WriteLine(value: "Much faster than a list");
        }
    }
}
