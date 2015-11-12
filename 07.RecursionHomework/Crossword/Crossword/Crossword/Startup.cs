namespace Crossword
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private static List<string> words = new List<string>();
        private static Stack<string> result = new Stack<string>();
        private static HashSet<string> usedWords = new HashSet<string>();

        public static void Main()
        {
            int crosswordSize = int.Parse(Console.ReadLine());
            for (int i = 0; i < crosswordSize * 2; i++)
            {
                words.Add(Console.ReadLine());
            }

            SolveCrossword(0);
        }

        private static void SolveCrossword(int index)
        {
            for (int i = 0; i < words.Count; i++)
            {
                result[index] = 
            }
        }
    }
}
