namespace Sequence
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var sequence = new Queue<long>();
            var numbers = new List<long>();

            int start = int.Parse(Console.ReadLine());
            int order = int.Parse(Console.ReadLine()); // e.g 50

            sequence.Enqueue(start);
            numbers.Add(start);
            while(numbers.Count < order)
            {
                long currentNumber = sequence.Dequeue();

                long nextNumber = currentNumber + 1;
                long secondNextNumber = currentNumber * 2 + 1;
                long thirdNextNumber = currentNumber + 2;

                sequence.Enqueue(nextNumber);
                sequence.Enqueue(secondNextNumber);
                sequence.Enqueue(thirdNextNumber);

                numbers.Add(nextNumber);
                numbers.Add(secondNextNumber);
                numbers.Add(thirdNextNumber);
            }

            Console.WriteLine(string.Join(separator: ", ", values: numbers));
        }
    }
}
