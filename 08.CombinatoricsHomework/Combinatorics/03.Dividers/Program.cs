namespace Dividers
{
    using System;

    public class Program
    {
        private static int n;
        private static int k;
        private static int number;
        private static int divisorsCount = int.MaxValue;
        private static int[] arr;
        private static bool[] used;
        private static int[] digits;

        public static void Main()
        {
            n = int.Parse(Console.ReadLine());
            k = n;
            digits = new int[n];
            arr = new int[k];
            used = new bool[n];
            for (int i = 0; i < n; i++)
            {
                digits[i]= int.Parse(Console.ReadLine());
            }

            GenerateVariationsNoRepetitions(0);
            Console.WriteLine(number);
        }

        private static void GenerateVariationsNoRepetitions(int index)
        {
            if (index >= k)
            {
                int currentNumber = int.Parse(string.Join(string.Empty, arr));
                int currentNumberOfDivisors = GetFactorCount(currentNumber);
                if (currentNumberOfDivisors < divisorsCount)
                {
                    divisorsCount = currentNumberOfDivisors;
                    number = currentNumber;
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = digits[i];
                        GenerateVariationsNoRepetitions(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static int GetFactorCount(int numberToCheck)
        {
            int factorCount = 0;
            var sqrt = (int)Math.Ceiling(Math.Sqrt(numberToCheck));
            
            for (int i = 1; i < sqrt; i++)
            {
                if (numberToCheck % i == 0)
                {
                    factorCount += 2;
                }
            }
            
            if (sqrt * sqrt == numberToCheck)
            {
                factorCount++;
            }

            return factorCount;
        }
    }
}
