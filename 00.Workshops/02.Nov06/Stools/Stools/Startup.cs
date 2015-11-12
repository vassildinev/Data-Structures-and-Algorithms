namespace Stools
{
    using System;
    using System.Linq;

    public class Startup
    {
        private static Stool[] stools;
        private static int[,,] calculatedValues;
        private static int n;

        public static void Main()
        {
            n = int.Parse(Console.ReadLine());
            stools = new Stool[n];
            calculatedValues = new int[1 << n, 15, 3];
            for (int i = 0; i < n; i++)
            {
                int[] dimensions = Console
                    .ReadLine()
                    .Split(' ')
                    .Select(x => int.Parse(x))
                    .ToArray();

                stools[i] = new Stool(dimensions[0], dimensions[1], dimensions[2]);
            }

            int maxHeight = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    maxHeight = Math.Max(maxHeight, GetMaxHeight((1 << n) - 1, i, j));
                }
            }

            Console.WriteLine(maxHeight);
        }

        private static int GetMaxHeight(int stoolsToUse, int top, int side)
        {
            int result = calculatedValues[stoolsToUse, top, side];
            if (result != 0)
            {
                return result;
            }

            int onlyOneStoolLeftValue = 1 << top;
            Stool currentStool = stools[top];
            if (stoolsToUse == onlyOneStoolLeftValue)
            {
                if (side == 0)
                {
                    return currentStool.X;
                }
                else if (side == 1)
                {
                    return currentStool.Y;
                }
                else
                {
                    return currentStool.Z;
                }
            }

            int sideX = side == 0 ? currentStool.Y : currentStool.X;
            int sideY = side == 2 ? currentStool.Y : currentStool.Z;
            int height = currentStool.X + currentStool.Y + currentStool.Z - sideX - sideY;

            result = height;
            int remainingStools = stoolsToUse ^ (1 << top);
            for (int i = 0; i < n; i++)
            {
                if (((remainingStools >> i) & 1) == 1)
                {
                    Stool nextStool = stools[i];
                    if ((nextStool.Y <= sideX && nextStool.Z <= sideY) ||
                        (nextStool.Z <= sideX && nextStool.Y <= sideY))
                    {
                        result = Math.Max(result, GetMaxHeight(remainingStools, i, 0) + height);
                    }

                    if (nextStool.X == nextStool.Y && nextStool.Y == nextStool.Z)
                    {
                        continue;
                    }

                    if ((nextStool.X <= sideX && nextStool.Z <= sideY) ||
                        (nextStool.Z <= sideX && nextStool.X <= sideY))
                    {
                        result = Math.Max(result, GetMaxHeight(remainingStools, i, 1) + height);
                    }

                    if ((nextStool.X <= sideX && nextStool.Y <= sideY) ||
                        (nextStool.Y <= sideX && nextStool.X <= sideY))
                    {
                        result = Math.Max(result, GetMaxHeight(remainingStools, i, 2) + height);
                    }
                }
            }

            calculatedValues[stoolsToUse, top, side] = result;
            return result;
        }

        private class Stool
        {
            public Stool(int x, int y, int z)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }

            public int X { get; set; }

            public int Y { get; set; }

            public int Z { get; set; }
        }

    }
}
