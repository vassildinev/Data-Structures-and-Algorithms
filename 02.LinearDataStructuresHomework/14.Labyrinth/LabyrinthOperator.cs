namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LabyrinthOperator
    {
        private const int CharacterPadValue = 2;

        private List<int[]> processedCells = new List<int[]>();

        public LabyrinthOperator()
        {
        }

        public int[,] PerformOperations(int[,] input, int[] startPosition)
        {
            int firstDimensionLength = input.GetLength(dimension: 0);
            int secondDimensionLength = input.GetLength(dimension: 1);
            var result = new int[firstDimensionLength, secondDimensionLength];
            this.CopyMatrix(input, result);

            int startPositionRow = startPosition[0];
            int startPositionCol = startPosition[1];
            this.GenerateCellPaths(startPositionRow, startPositionCol, result);

            return result;
        }

        public void PrintMatrix(int[,] input)
        {
            int firstDimensionLength = input.GetLength(dimension: 0);
            int secondDimensionLength = input.GetLength(dimension: 1);

            for (int row = 0; row < secondDimensionLength; row++)
            {
                for (int col = 0; col < firstDimensionLength; col++)
                {
                    string character = string.Empty;
                    switch (input[row, col])
                    {
                        case 0:
                            character = "*";
                            break;
                        case -2:
                            character = "X";
                            break;
                        case -1:
                            character = "u";
                            break;
                        default:
                            character = input[row, col].ToString();
                            break;
                    }

                    Console.Write($"| {character.PadRight(CharacterPadValue).PadLeft(CharacterPadValue)}");
                }

                Console.WriteLine();
            }
        }

        private void GenerateCellPaths(int row, int col, int[,] input)
        {
            int firstDimensionLength = input.GetLength(dimension: 0);
            int secondDimensionLength = input.GetLength(dimension: 1);

            if (this.processedCells.Any(x => x[0] == row && x[1] == col))
            {
                return;
            }

            this.processedCells.Add(new int[] { row, col });

            // top cell
            if (row - 1 >= 0)
            {
                if (input[row - 1, col] != -2)
                {
                    if (!this.processedCells.Any(x => x[0] == row - 1 && x[1] == col) ||
                        this.GetMinNonZeroSurroundingValue(row - 1, col, input) < input[row - 1, col])
                    {
                        input[row - 1, col] = this.GetMinNonZeroSurroundingValue(row - 1, col, input) + 1;
                        this.GenerateCellPaths(row - 1, col, input);
                    }
                }
            }

            // left cell
            if (col - 1 >= 0)
            {
                if (input[row, col - 1] != -2)
                {
                    if (!this.processedCells.Any(x => x[0] == row && x[1] == col - 1) ||
                        this.GetMinNonZeroSurroundingValue(row, col - 1, input) < input[row, col - 1])
                    {
                        input[row, col - 1] = this.GetMinNonZeroSurroundingValue(row, col - 1, input) + 1;
                        this.GenerateCellPaths(row, col - 1, input);
                    }
                }
            }

            // bottom cell
            if (row + 1 < firstDimensionLength)
            {
                if (input[row + 1, col] != -2)
                {
                    if (!this.processedCells.Any(x => x[0] == row + 1 && x[1] == col) ||
                        this.GetMinNonZeroSurroundingValue(row + 1, col, input) + 1 < input[row + 1, col])
                    {
                        input[row + 1, col] = this.GetMinNonZeroSurroundingValue(row + 1, col, input) + 1;
                        this.GenerateCellPaths(row + 1, col, input);
                    }
                }
            }

            // right cell
            if (col + 1 < secondDimensionLength)
            {
                if (input[row, col + 1] != -2)
                {
                    if (!this.processedCells.Any(x => x[0] == row && x[1] == col + 1) ||
                        this.GetMinNonZeroSurroundingValue(row, col + 1, input) + 1 < input[row, col + 1])
                    {
                        input[row, col + 1] = this.GetMinNonZeroSurroundingValue(row, col + 1, input) + 1;
                        this.GenerateCellPaths(row, col + 1, input);
                    }
                }
            }
        }


        private void CopyMatrix(int[,] source, int[,] destination)
        {
            int firstDimensionLength = source.GetLength(dimension: 0);
            int secondDimensionLength = source.GetLength(dimension: 1);

            for (int row = 0; row < secondDimensionLength; row++)
            {
                for (int col = 0; col < firstDimensionLength; col++)
                {
                    destination[row, col] = source[row, col];
                }
            }
        }

        private int GetMinNonZeroSurroundingValue(int row, int col, int[,] input)
        {
            int topValue = int.MaxValue;
            int bottomValue = int.MaxValue;
            int rightValue = int.MaxValue;
            int leftValue = int.MaxValue;

            if (this.IsInsideMatrix(row - 1, col, input) && input[row - 1, col] >= 0)
            {
                topValue = input[row - 1, col];
            }

            if (this.IsInsideMatrix(row + 1, col, input) && input[row + 1, col] >= 0)
            {
                bottomValue = input[row + 1, col];
            }

            if (this.IsInsideMatrix(row, col - 1, input) && input[row, col - 1] >= 0)
            {
                leftValue = input[row, col - 1];
            }

            if (this.IsInsideMatrix(row, col + 1, input) && input[row, col + 1] >= 0)
            {
                rightValue = input[row, col + 1];
            }

            return Math.Min(Math.Min(topValue, bottomValue), Math.Min(leftValue, rightValue));
        }

        private bool IsInsideMatrix(int row, int col, int[,] input)
        {
            if (row < 0 || row >= input.GetLength(1))
            {
                return false;
            }

            if (col < 0 || col >= input.GetLength(0))
            {
                return false;
            }

            return true;
        }
    }
}