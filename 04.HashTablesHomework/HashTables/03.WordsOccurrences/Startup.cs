namespace WordsOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var wordsAndCounts = new Dictionary<string, int>();
            string pathToWords = @"../../words.txt";
            string[] words = File
                .ReadAllText(pathToWords)
                .Split(
                    new char[] { ' ', '!', '?', '–', '.', ',' },
                    StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var word in words)
            {
                if (!wordsAndCounts.ContainsKey(word.ToLower()))
                {
                    wordsAndCounts[word.ToLower()] = 0;
                }

                wordsAndCounts[word.ToLower()] += 1;
            }

            List<KeyValuePair<string, int>> orderedWordsAndCounts = wordsAndCounts
                .OrderBy(kvp => kvp.Value)
                .ToList();

            foreach (var item in orderedWordsAndCounts)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
