namespace Variations
{
    using System;

    public class Startup
    {
        private static int n;
        private static int k;
        private static string[] objects;
        private static string[] arr;

        static void Main()
        {
            k = int.Parse(Console.ReadLine());
            arr = new string[k];
            objects = new string[]
            {
                "hi", "a", "b"
            };

            n = objects.Length;

            GenerateVariationsWithRepetitions(0);
        }

        static void GenerateVariationsWithRepetitions(int index)
        {
            if (index >= k)
            {
                PrintVariations();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    arr[index] = objects[i];
                    GenerateVariationsWithRepetitions(index + 1);
                }
            }
        }

        static void PrintVariations()
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
