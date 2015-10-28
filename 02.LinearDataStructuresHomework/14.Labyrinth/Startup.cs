using System;

namespace Labyrinth
{
    public class Startup
    {
        public static void Main()
        {
            //  0 : start position
            // -2 : full cell
            // -1 : empty cell

            var labyrinth = new int[,]
            {
                 { -1, -1, -1, -2, -1, -2 },
                 { -1, -2, -1, -2, -1, -2 },
                 { -1, 0, -2, -1, -2, -1 },
                 { -1, -2, -1, -1, -1, -1 },
                 { -1, -1, -1, -2, -2, -1 },
                 { -1, -1, -1, -2, -1, -2 }
            };

            var test = new int[,]
            {
                { -1, -1, -1, -1, -1 },
                { -1, -1, -1, -1, -1 },
                { -1, -1, 0, -1, -1 },
                { -1, -1, -1, -1, -1 },
                { -1, -1, -1, -1, -1 },
            };

            var labOperator = new LabyrinthOperator();
            int[,] result = labOperator.PerformOperations(labyrinth, new int[] { 2, 1 });
            labOperator.PrintMatrix(result);
        }
    }
}
