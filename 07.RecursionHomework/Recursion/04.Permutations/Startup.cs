namespace Permutations
{
    using System;

    public class Startup
    {
        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            var arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = i + 1;
            }

            GeneratePermutations(arr, 0);
        }

        static void GeneratePermutations<T>(T[] arr, int k)
        {
            if (k >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void Print<T>(T[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
