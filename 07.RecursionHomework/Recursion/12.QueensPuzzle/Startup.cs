namespace QueensPuzzle
{
    using System;

    public class Startup
    {
        private static int[,] chessTable = new int[8, 8];
        private static int[,] availableCells = new int[8, 8];

        public static void Main()
        {
            SolveQueen(0);
            PrintMatrix(chessTable);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i,j] == 1)
                    {
                        Console.Write("  V  ");
                    }
                    else
                    {
                        Console.Write("  -  ");
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static void SolveQueen(int col)
        {
            if (col == 8)
            {
                PrintMatrix(chessTable);
                Environment.Exit(0);
            }

            for (int i = 0; i < 8; i++)
            {
                if (availableCells[i, col] == 0)
                {
                    chessTable[i, col] = 1;
                    MarkUnavailableCells(i, col);
                    SolveQueen(col + 1);
                    chessTable[i, col] = 0;
                    UnmarkUnavailableCells(i, col);
                }
            }
        }

        private static void UnmarkUnavailableCells(int row, int col)
        {
            for (int j = 0; j < 8; j++)
            {
                availableCells[row, j] -= 1;
                availableCells[j, col] -= 1;
                if (row - j >= 0 && col - j >= 0) availableCells[row - j, col - j] -= 1;
                if (row + j < 8 && col + j < 8) availableCells[row + j, col + j] -= 1;
                if (row + j < 8 && col - j >= 0) availableCells[row + j, col - j] -= 1;
                if (row - j >= 0 && col + j < 8) availableCells[row - j, col + j] -= 1;

            }

            availableCells[row, col] += 5;
        }

        private static void MarkUnavailableCells(int row, int col)
        {
            for (int j = 0; j < 8; j++)
            {
                availableCells[row, j] += 1;
                availableCells[j, col] += 1;
                if (row - j >= 0 && col - j >= 0) availableCells[row - j, col - j] += 1;
                if (row + j < 8 && col + j < 8) availableCells[row + j, col + j] += 1;
                if (row + j < 8 && col - j >= 0) availableCells[row + j, col - j] += 1;
                if (row - j >= 0 && col + j < 8) availableCells[row - j, col + j] += 1;

            }

            availableCells[row, col] -= 5;
        }
    }
}
