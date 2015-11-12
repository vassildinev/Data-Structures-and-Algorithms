namespace CombinationsWithRepetitions
{
    using System;

    public class Startup
    {
        private static int n;
        private static int k;
        static int[] arr;

        static void Main()
        {
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            k = int.Parse(Console.ReadLine());

            arr = new int[k];
            GenerateCombinationsNoRepetitions(0, 0);
        }

        static void GenerateCombinationsNoRepetitions(int index, int start)
        {
            if (index >= k)
            {
                PrintVariations();
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i + 1;
                    GenerateCombinationsNoRepetitions(index + 1, i);
                }
            }
        }

        static void PrintVariations()
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
