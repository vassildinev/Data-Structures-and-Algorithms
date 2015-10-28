namespace CustomStack
{
    using System.Collections.Generic;

    public class Stack<T>
    {
        private const int InitialSize = 4;
        private const double AcceptableCapacityUsed = 0.9;

        private T[] values = new T[InitialSize];
        private int lastIndex = 0;

        public int Capacity
        {
            get
            {
                return this.values.Length;
            }
        }

        public int Count
        {
            get
            {
                return this.lastIndex;
            }
        }

        public void Push(T value)
        {
            this.values[this.lastIndex] = value;
            this.lastIndex += 1;

            if (this.lastIndex > AcceptableCapacityUsed * this.values.Length)
            {
                this.Expand();
            }
        }

        public T Pop()
        {
            this.lastIndex -= 1;
            T value = this.values[this.lastIndex];
            this.values[this.lastIndex] = default(T);

            return value;
        }

        private void Expand()
        {
            var copy = new List<T>(this.values);
            int currentSize = this.values.Length;
            int newSize = currentSize * 2;

            this.values = new T[newSize];
            for (int i = 0; i < copy.Count; i++)
            {
                this.values[i] = copy[i];
            }
        }
    }
}
