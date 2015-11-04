namespace HashedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using HashTable;

    public class HashedSet<T> :
        IEnumerable<T>
        where T : IComparable<T>
    {
        private readonly HashTable<T, T> values;

        public HashedSet()
        {
            this.values = new HashTable<T, T>();
        }

        public int Count
        {
            get { return this.values.Count; }
        }

        public void Add(T value)
        {
            if (!this.values.Contains(value))
            {
                this.values.Add(value, value);
            }
        }

        public void Remove(T value)
        {
            int valueHashCode = value.GetHashCode();
            int index = valueHashCode / this.values.Count;
            LinkedList<KeyValuePair<T, T>> result = this.values[index];
            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            this.values.Remove(value);
        }

        public T Find(T value)
        {
            return this.values.Find(value);
        }

        public void Clear()
        {
            this.values.Clear();
        }

        public IEnumerable<T> Union(HashedSet<T> values)
        {
            ICollection<T> result = new List<T>();
            foreach (var item in this)
            {
                result.Add(item);
            }

            foreach (var item in values)
            {
                if (!result.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public IEnumerable<T> Intersect(HashedSet<T> values)
        {
            ICollection<T> result = new List<T>();
            foreach (var item in this)
            {
                if (values.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public bool Contains(T value)
        {
            try
            {
                this.Find(value);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.values)
            {
                yield return item.First.Value.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
