namespace HashTable.Tests
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void InitializerShouldSetCountToZero()
        {
            var hashTable = new HashTable<int, string>();
            int expected = 0;
            Assert.AreEqual(expected, hashTable.Count);
        }

        [TestMethod]
        public void InitializerShouldReturnKeysCountOfZero()
        {
            var hashTable = new HashTable<int, string>();
            int expected = 0;
            Assert.AreEqual(expected, hashTable.Keys.Count());
        }

        [TestMethod]
        public void AddShouldNotResultInCountOfZero()
        {
            var hashTable = new HashTable<int, string>();

            int key = 5;
            string value = "master";
            hashTable.Add(key, value);

            int expected = 1;
            Assert.AreEqual(expected, hashTable.Count);
        }

        [TestMethod]
        public void AddShouldResultInKeysContainingAddedKey()
        {
            var hashTable = new HashTable<int, string>();

            int key = 5;
            string value = "master";
            hashTable.Add(key, value);

            bool expected = true;
            Assert.AreEqual(expected, hashTable.Keys.Contains(key));
        }

        [TestMethod]
        public void RemoveExistingKeyShouldResultInCountOfZero()
        {
            var hashTable = new HashTable<int, string>();

            int key = 5;
            string value = "master";
            hashTable.Add(key, value);
            hashTable.Remove(key);

            int expected = 0;
            Assert.AreEqual(expected, hashTable.Count);
        }

        [TestMethod]
        public void RemoveExistingKeyShouldResultInKeysCountOfZero()
        {
            var hashTable = new HashTable<int, string>();

            int key = 5;
            string value = "master";
            hashTable.Add(key, value);
            hashTable.Remove(key);

            bool expected = true;
            Assert.AreEqual(expected, !hashTable.Keys.Contains(key));
        }

        [TestMethod]
        public void FindShouldReturnValue()
        {
            var hashTable = new HashTable<int, string>();

            int key = 5;
            string value = "master";
            hashTable.Add(key, value);

            string actual = hashTable.Find(key);
            Assert.AreEqual(value, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void FindShouldThrowIfKeyNotExists()
        {
            var hashTable = new HashTable<int, string>();

            int key = 5;
            string value = "master";
            hashTable.Add(key, value);

            string actual = hashTable.Find(key + 1);
            Assert.AreEqual(value, actual);
        }

        [TestMethod]
        public void ClearShouldResultInKeysCountOfZeroAndCountOfZero()
        {
            var hashTable = new HashTable<int, string>();

            int key = 5;
            string value = "master";
            hashTable.Add(key, value);
            hashTable.Clear();

            bool expected = true;
            Assert.AreEqual(expected, hashTable.Keys.Count() == 0);
            Assert.AreEqual(expected, hashTable.Count == 0);
        }
    }
}
