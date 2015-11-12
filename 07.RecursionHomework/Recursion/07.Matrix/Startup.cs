namespace Matrix
{
    using System;

    public class Startup
    {
        // -1 -> unpassable
        //  0 -> passable

        private static int[,] matrix =
        {
            {0,0,0,0,0,0},
            {0,-1,-1,0,-1,0},
            {0,-1,0,0,-1,0},
            {0,-1,0,0,-1,0},
            {0,-1,-1,0,0,0},
            {0,0,0,0,0,0},
        };

        private static int count = 0;

        public static void Main()
        {
            int startRow = 2;
            int startCol = 2;
            int endRow = 5;
            int endCol = 5;

            SetCounter(startRow, startCol, endRow, endCol);
            Console.WriteLine(count);
        }

        private static void SetCounter(int startRow, int startCol, int endRow, int endCol)
        {
            if (matrix[endRow, endCol] == -1)
            {
                return;
            }

            if (startRow == endRow && startCol == endCol)
            {
                count += 1;
            }

            matrix[startRow, startCol] = 1;
            if (IsValidCell(startRow - 1, startCol))
            {
                SetCounter(startRow - 1, startCol, endRow, endCol);
            }

            if (IsValidCell(startRow + 1, startCol))
            {
                SetCounter(startRow + 1, startCol, endRow, endCol);
            }

            if (IsValidCell(startRow, startCol - 1))
            {
                SetCounter(startRow, startCol - 1, endRow, endCol);
            }

            if (IsValidCell(startRow, startCol + 1))
            {
                SetCounter(startRow, startCol + 1, endRow, endCol);
            }

            matrix[startRow, startCol] = 0;
        }

        private static bool IsValidCell(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(1))
            {
                return false;
            }

            if (col < 0 || col >= matrix.GetLength(0))
            {
                return false;
            }

            if (matrix[row, col] == -1)
            {
                return false;
            }

            if (matrix[row, col] == 1)
            {
                return false;
            }

            return true;
        }
    }
}
