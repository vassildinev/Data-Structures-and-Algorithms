namespace SequenceOfStrings
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var words = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            var wordsAndCounts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!wordsAndCounts.ContainsKey(word))
                {
                    wordsAndCounts[word] = 0;
                }

                wordsAndCounts[word] += 1;
            }

            foreach (var item in wordsAndCounts)
            {
                if (item.Value % 2 == 1)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
