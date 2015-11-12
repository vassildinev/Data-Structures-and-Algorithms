namespace Fibonacci
{
    using System;

    public class FibonacciCalculator
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            long result = FibonacciUtils.Power(new FibonacciMatrix(), n - 1).BaseValue;
            Console.WriteLine(result);
        }
    }
}
