namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<TKey, TValue> :
        IEnumerable<LinkedList<KeyValuePair<TKey, TValue>>>
        where TKey : IComparable<TKey>
    {
        private const int InitialSize = 16;
        private int capacity;
        private LinkedList<KeyValuePair<TKey, TValue>>[] values;

        public HashTable()
        {
            this.capacity = InitialSize;
            this.values = new LinkedList<KeyValuePair<TKey, TValue>>[InitialSize];
        }

        public int Count
        {
            get
            {
                return this.values
                .Where(x => x != null)
                .Where(x => x.Count != 0)
                .Count();
            }
        }

        public LinkedList<KeyValuePair<TKey, TValue>> this[int i]
        {
            get { return this.values[i]; }
            set { this.values[i] = value; }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                return this.values
                    .Where(x => x != null)
                    .Where(x => x.Count != 0)
                    .Select(x => x.First.Value.Key)
                    .ToList();
            }
        }

        public void Add(TKey key, TValue value)
        {
            int keyHashCode = key.GetHashCode();
            int index = keyHashCode % this.values.Length;
            if (this.values[index] == null)
            {
                this.values[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }

            this.values[index].AddLast(new KeyValuePair<TKey, TValue>(key, value));
            if (this.Count > 0.75 * this.capacity)
            {
                this.Resize();
            }
        }

        public TValue Find(TKey key)
        {
            int keyHashCode = key.GetHashCode();
            int index = keyHashCode % this.values.Length;
            LinkedList<KeyValuePair<TKey, TValue>> pair = this.values[index];

            if (pair == null)
            {
                throw new KeyNotFoundException();
            }

            return pair.First.Value.Value;
        }

        public void Remove(TKey key)
        {
            int keyHashCode = key.GetHashCode();
            int index = keyHashCode % this.values.Length;
            KeyValuePair<TKey, TValue> kvp = this.values[index]
                .Where(x => x.Key.CompareTo(key) == 0)
                .FirstOrDefault();
            if (kvp.Equals(default(KeyValuePair<TKey, TValue>)))
            {
                throw new KeyNotFoundException();
            }

            this.values[index].Remove(kvp);
        }

        public void Clear()
        {
            this.values = new LinkedList<KeyValuePair<TKey, TValue>>[InitialSize];
        }

        private void Resize()
        {
            LinkedList<KeyValuePair<TKey, TValue>>[] values = this.values;
            this.capacity *= 2;
            this.values = new LinkedList<KeyValuePair<TKey, TValue>>[this.capacity];
            for (int i = 0; i < values.Length; i++)
            {
                TKey key = values[i].First.Value.Key;
                int keyHashCode = key.GetHashCode();
                int index = keyHashCode % this.values.Length;
                this.values[index] = values[i];
            }
        }

        public bool Contains(TKey key)
        {
            try
            {
                this.Find(key);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public IEnumerator<LinkedList<KeyValuePair<TKey, TValue>>> GetEnumerator()
        {
            foreach (var item in this.values)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
