namespace TextProcessing
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            var trie = new BoyerMoore("lorem");
            string text = File.ReadAllText("../../largeTextFile.txt");
            int count = 0;
            int nextIndex = 0;
            while (true)
            {
                nextIndex = trie.Search(text, nextIndex + 1);
                if (nextIndex == -1)
                {
                    break;
                }

                count += 1;
            }

            Console.WriteLine(count);
        }
    }
}