namespace PriorityQueue
{
    using System;

    public class MaxBinaryHeap<T>
        where T : IComparable<T>
    {
        private const int InitialSize = 16;

        private T[] data;
        private int size = 0;
        private readonly Comparison<T> comparison;

        public MaxBinaryHeap()
        {
            this.data = new T[InitialSize];
            this.comparison = new Comparison<T>(this.ReturnMax);
        }

        public MaxBinaryHeap(int capacity)
            : this()
        {
            this.data = new T[capacity];
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        public void Insert(T item)
        {
            if (this.size == this.data.Length)
            {
                this.Resize();
            }

            this.data[this.size] = item;
            this.HeapifyUp(this.size);
            this.size += 1;
        }

        public T Peek()
        {
            return this.data[0];
        }

        public T Pop()
        {
            T item = this.data[0];
            this.size -= 1;
            this.data[0] = this.data[this.size];
            this.HeapifyDown(parentIndex: 0);
            return item;
        }

        private void Resize()
        {
            var resizedData = new T[this.data.Length * 2];
            Array.Copy(this.data, 0, resizedData, 0, this.data.Length);
            this.data = resizedData;
        }

        private void HeapifyUp(int childIndex)
        {
            if (childIndex > 0)
            {
                int parentIdx = (childIndex - 1) / 2;
                if (comparison.Invoke(data[childIndex], data[parentIdx]) > 0)
                {
                    T t = this.data[parentIdx];
                    this.data[parentIdx] = this.data[childIndex];
                    this.data[childIndex] = t;
                    this.HeapifyUp(parentIdx);
                }
            }
        }

        private void HeapifyDown(int parentIndex)
        {
            int leftChildIdx = 2 * parentIndex + 1;
            int rightChildIdx = leftChildIdx + 1;
            int largestChildIdx = parentIndex;
            if (leftChildIdx < this.size && comparison.Invoke(this.data[leftChildIdx], this.data[largestChildIdx]) > 0)
            {
                largestChildIdx = leftChildIdx;
            }

            if (rightChildIdx < this.size && comparison.Invoke(this.data[rightChildIdx], this.data[largestChildIdx]) > 0)
            {
                largestChildIdx = rightChildIdx;
            }

            if (largestChildIdx != parentIndex)
            {
                T t = this.data[parentIndex];
                this.data[parentIndex] = this.data[largestChildIdx];
                this.data[largestChildIdx] = t;
                this.HeapifyDown(largestChildIdx);
            }
        }

        private int ReturnMax(T left, T right)
        {
            return left.CompareTo(right);
        }
    }
}
