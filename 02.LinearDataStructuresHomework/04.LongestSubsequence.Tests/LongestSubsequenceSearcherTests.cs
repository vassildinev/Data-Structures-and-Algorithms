namespace LongestSubsequence.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LongestSubsequenceSearcherTests
    {
        [TestMethod]
        public void RunShouldReturnCorrectResultNormalCase()
        {
            var searcher = new LongestSubsequenceSearcher();
            var numbers = new List<int>
            {
                4, 5, 5, 7, 7, 2, 0, 0, 0, 9, 9, 9, 9
            };

            int expected = 4;
            int actual = searcher.Run(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RunShouldReturnCorrectResultSpecialCase()
        {
            var searcher = new LongestSubsequenceSearcher();
            var numbers = new List<int>
            {
                9, 9, 9
            };

            int expected = 3;
            int actual = searcher.Run(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RunShouldReturnCorrectResultNoSubsequences()
        {
            var searcher = new LongestSubsequenceSearcher();
            var numbers = new List<int>
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9
            };

            int expected = 1;
            int actual = searcher.Run(numbers);

            Assert.AreEqual(expected, actual);
        }
    }
}
