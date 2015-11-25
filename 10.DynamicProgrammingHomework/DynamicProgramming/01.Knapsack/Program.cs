using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Knapsack
{
    public struct Product
    {
        public Product(string name, int weight, int cost)
            : this()
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = cost;
        }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int Cost { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - weight={1}, cost={2}", this.Name, this.Weight, this.Cost);
        }
    }

    public static class Utility
    {
        /// <summary>
        /// Parse input using Regular Expressions - Regex.Matches() method
        /// </summary>
        public static void ParseInput(out Product[] products, out int maximalWeight)
        {
            maximalWeight = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            products = new Product[N];

            for (int i = 0; i < N; i++)
            {
                var line = Console.ReadLine();
                var productName = Regex.Matches(line, @"(\w+).-")
                                       .Cast<Match>()
                                       .First()
                                       .Groups[1].Value;

                var productCharacteristics = Regex.Matches(line, @"(\w+=)+(\d+)")
                                                  .Cast<Match>()
                                                  .Select(a => int.Parse(a.Groups[2].Value))
                                                  .ToArray();

                products[i] = new Product(productName, productCharacteristics[0], productCharacteristics[1]);
            }
        }

        public static void PrintAllProducts(Product[] products)
        {
            Console.WriteLine("------- All products: -------");

            foreach (var product in products)
            {
                Console.WriteLine("- {0}", product);
            }

            Console.WriteLine("-----------------------------\n");
        }

        public static void PrintOptimalSolutions(ICollection<Product>[] solutions)
        {
            Console.WriteLine("Optimal solution(s): ");

            if (solutions.First().Count() == 0)
            {
                Console.WriteLine("- No solution!\n");
                return;
            }

            foreach (var solution in solutions)
            {
                Console.WriteLine("- {0} -> Total Weight: {1} | Total Cost: {2}",
                    string.Join(" | ", solution.Select(p => p.Name)),
                    solution.Sum(p => p.Weight),
                    solution.Sum(p => p.Cost));
            }

            Console.WriteLine();
        }
    }

    class Program
    {
        private static Product[] products;
        private static int[,] matrix;

        internal static void Main()
        {

            int maximalWeight;
            Utility.ParseInput(out products, out maximalWeight);
            matrix = new int[products.Length + 1, maximalWeight + 1];

            FillMatrix();

            int maxValueColIndex = FindMaxValueIndexInLastRow();
            var maxValueInLastRow = matrix[products.Length, maxValueColIndex];

            Console.WriteLine("Optimal solution: {0}\n", maxValueInLastRow);
            PrintChosenFoods(maxValueInLastRow, maxValueColIndex);
            Console.WriteLine();
        }

        private static void FillMatrix()
        {
            for (int row = 1; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLongLength(1); col++)
                {
                    int upperValue = matrix[row - 1, col], leftValue = 0;
                    int colIndex = col - products[row - 1].Weight;
                    if (colIndex >= 0)
                    {
                        leftValue = matrix[row - 1, colIndex] + products[row - 1].Cost;
                    }

                    matrix[row, col] = Math.Max(upperValue, leftValue);
                }
            }
        }

        private static int FindMaxValueIndexInLastRow()
        {
            int maxValue = int.MinValue, indexOfMaxValue = 0;
            for (int col = 0; col < matrix.GetLongLength(1); col++)
            {
                var cellValue = matrix[matrix.GetLongLength(0) - 1, col];
                if (cellValue > maxValue)
                {
                    maxValue = cellValue;
                    indexOfMaxValue = col;
                }
            }

            return indexOfMaxValue;
        }

        private static void PrintChosenFoods(int maxValue, int maxValueColIndex)
        {
            int currentRow = (int)(matrix.GetLongLength(0) - 1), currentCol = maxValueColIndex;
            int currentValue = maxValue, upperValue = 0;

            while (currentRow > 0 && currentCol > 0)
            {
                upperValue = matrix[currentRow - 1, currentCol];

                if (upperValue != currentValue)
                {
                    Console.WriteLine(products[currentRow - 1]); // The chosen food
                    currentCol -= products[currentRow - 1].Weight;
                }

                currentValue = matrix[--currentRow, currentCol];
            }
        }
    }
}
