namespace Substrings
{
    using System;


    public class Startup
    {
        private static int n;
        private static int k;
        private static string[] arr;
        private static string[] objects;

        static void Main()
        {
            objects = new string[] { "a", "b", "c" };
            n = objects.Length;
            k = int.Parse(Console.ReadLine());
            arr = new string[k];

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
                    arr[index] = objects[i];
                    GenerateCombinationsNoRepetitions(index + 1, i + 1);
                }
            }
        }

        static void PrintVariations()
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
