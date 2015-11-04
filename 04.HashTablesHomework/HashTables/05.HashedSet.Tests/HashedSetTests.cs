namespace HashedSet.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class HashedSetTests
    {
        [TestMethod]
        public void InitializerShouldCreateEmptyHashedSet()
        {
            var set = new HashedSet<int>();
            int expected = 0;

            Assert.AreEqual(expected, set.Count);
        }

        [TestMethod]
        public void AddShouldNotResultInCountOfZero()
        {
            var set = new HashedSet<int>();

            int value = 5;
            set.Add(value);

            int expected = 1;
            Assert.AreEqual(expected, set.Count);
        }

        [TestMethod]
        public void AddShouldResultInKeysContainingAddedKey()
        {
            var set = new HashedSet<int>();

            int value = 5;
            set.Add(value);

            bool expected = true;
            Assert.AreEqual(expected, set.Contains(value));
        }

        [TestMethod]
        public void RemoveExistingKeyShouldResultInCountOfZero()
        {
            var set = new HashedSet<int>();

            int value = 5;
            set.Add(value);
            set.Remove(value);

            int expected = 0;
            Assert.AreEqual(expected, set.Count);
        }

        [TestMethod]
        public void RemoveExistingKeyShouldResultInKeysCountOfZero()
        {
            var set = new HashedSet<int>();

            int value = 5;
            set.Add(value);
            set.Remove(value);

            bool expected = true;
            Assert.AreEqual(expected, !set.Contains(value));
        }

        [TestMethod]
        public void FindShouldReturnValue()
        {
            var set = new HashedSet<int>();

            int value = 5;
            set.Add(value);

            int actual = set.Find(value);
            Assert.AreEqual(value, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void FindShouldThrowIfKeyNotExists()
        {
            var set = new HashedSet<int>();

            int value = 5;
            set.Add(value);

            int actual = set.Find(value + 1);
            Assert.AreEqual(value, actual);
        }

        [TestMethod]
        public void ClearShouldResultInKeysCountOfZeroAndCountOfZero()
        {
            var set = new HashedSet<int>();

            int value = 5;
            set.Add(value);
            set.Clear();

            bool expected = true;
            Assert.AreEqual(expected, set.Count == 0);
        }
    }
}
