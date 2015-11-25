using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumEditDistance
{
    public class Program
    {
        private static double[,] matrix;

        private const double ReplaceLetterCosts = 1;
        private const double DeleteLetterCosts = 0.9;
        private const double InsertLetterCosts = 0.8;

        internal static void Main()
        {
            string input = Console.ReadLine();
            string output = Console.ReadLine();

            matrix = new double[input.Length + 1, output.Length + 1];

            FillFirstRow();
            FillFirstColumn();
            FillMatrix(output, input);
            Console.WriteLine(matrix[matrix.GetLongLength(0) - 1, matrix.GetLongLength(1) - 1]);
        }

        private static void FillFirstRow()
        {
            for (int col = 1; col < matrix.GetLongLength(1); col++)
            {
                matrix[0, col] = matrix[0, col - 1] + DeleteLetterCosts;
            }
        }

        private static void FillFirstColumn()
        {
            for (int row = 1; row < matrix.GetLongLength(0); row++)
            {
                matrix[row, 0] = matrix[row - 1, 0] + DeleteLetterCosts;
            }
        }

        private static void FillMatrix(string output, string input)
        {
            for (int row = 1; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLongLength(1); col++)
                {
                    var replaceCosts = matrix[row - 1, col - 1];
                    if (output[col - 1] != input[row - 1])
                    {
                        replaceCosts += ReplaceLetterCosts;
                    }

                    var addCosts = matrix[row, col - 1] + InsertLetterCosts;
                    var removeCosts = matrix[row - 1, col] + DeleteLetterCosts;

                    var minCosts = GetMin(replaceCosts, removeCosts, addCosts);
                    matrix[row, col] = minCosts;
                }
            }
        }

        private static double GetMin(params double[] elements)
        {
            return elements.Min();
        }
    }
}
