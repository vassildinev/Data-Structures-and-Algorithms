namespace NestedLoops
{
    using System;
    using System.Text;

    public class Startup
    {
        private static int[] arr;
        private static bool[] used;
        private static StringBuilder result;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            arr = new int[n];
            used = new bool[n];
            result = new StringBuilder();

            GenerateVariationsNoRepetitions(0, n);
            Console.WriteLine(result);
        }

        static void GenerateVariationsNoRepetitions(int index, int n)
        {
            int k = n;
            if (index >= k)
            {
                PrintVariations();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        arr[index] = i + 1;
                        GenerateVariationsNoRepetitions(index + 1, n);
                    }
                }
            }
        }

        static void PrintVariations()
        {
            result.AppendLine(string.Join(" ", arr));
        }
    }
}
