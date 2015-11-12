namespace Sudoku
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public class Startup
    {
        private const int BoardSize = 9;

        public static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var board = new StringBuilder[BoardSize];
            for (int i = 0; i < BoardSize; i++)
            {
                board[i] = new StringBuilder(Console.ReadLine());
            }

            SolveSudoku(board, 0, 0);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        private static void SolveSudoku(StringBuilder[] board, int row, int col)
        {
            if (row >= BoardSize)
            {
                //PrintBoard(board);
                return;
            }

            if (board[row][col] == '-')
            {
                for (int k = 1; k <= BoardSize; k++)
                {
                    char charToAdd = k.ToString()[0];
                    if (IsAvailableRowValue(board, row, charToAdd) &&
                        IsAvailableColValue(board, col, charToAdd) &&
                        IsAvailableSubsquareValue(board, row, col, charToAdd))
                    {
                        board[row][col] = charToAdd;
                        if (col + 1 >= BoardSize)
                        {
                            SolveSudoku(board, row + 1, 0);
                        }
                        else
                        {
                            SolveSudoku(board, row, col + 1);
                        }

                        board[row][col] = '-';
                    }
                }
            }
            else
            {
                if (col + 1 >= BoardSize)
                {
                    SolveSudoku(board, row + 1, 0);
                }
                else
                {
                    SolveSudoku(board, row, col + 1);
                }
            }
        }

        private static bool IsAvailableRowValue(StringBuilder[] board, int row, char value)
        {
            StringBuilder currentRow = board[row];
            for (int i = 0; i < BoardSize; i++)
            {
                if (currentRow[i] == value)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsAvailableColValue(StringBuilder[] board, int col, char value)
        {
            for (int i = 0; i < BoardSize; i++)
            {
                if (board[i][col] == value)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsAvailableSubsquareValue(StringBuilder[] board, int row, int col, char value)
        {
            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;

            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    if (board[i][j] == value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void PrintBoard(StringBuilder[] board)
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Console.Write(board[i][j]);
                }

                Console.WriteLine();
            }
        }
    }
}
