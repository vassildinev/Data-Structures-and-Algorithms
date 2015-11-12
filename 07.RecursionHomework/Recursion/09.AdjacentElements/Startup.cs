namespace AdjacentElements
{
    using System;

    public static class Startup
    {
        public static void Main()
        {
            int[,] matrix = new int[,]
            {
                    {1,3,2,2,2,4},
                    {1,3,2,2,2,4},
                    {1,3,2,2,2,4},
                    {1,3,2,2,2,4},
                    {1,3,2,2,2,4},
            };

            Console.WriteLine(DepthFirstSearch.CheckMatrix(matrix, matrix.GetLength(1), matrix.GetLength(0)));
        }
    }
}