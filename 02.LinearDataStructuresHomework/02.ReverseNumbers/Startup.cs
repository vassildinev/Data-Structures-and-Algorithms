namespace ReverseNumbers
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            var numbers = new Stack<int>();
            while(line != string.Empty)
            {
                int currentNumber= int.Parse(line);
                numbers.Push(currentNumber);
                line = Console.ReadLine();
            }

            while (numbers.Count > 0)
            {
                int currentNumber = numbers.Pop();
                Console.WriteLine(currentNumber);
            }
        }
    }
}
