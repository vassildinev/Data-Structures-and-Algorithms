namespace PriorityQueue
{
    using System;

    public class PriorityQueue<T>
        where T : IComparable<T>
    {
        private readonly MaxBinaryHeap<T> heap;

        public PriorityQueue()
        {
            this.heap = new MaxBinaryHeap<T>();
        }

        public int Count
        {
            get { return this.heap.Size; }
        }

        public void Enqueue(T item)
        {
            this.heap.Insert(item);
        }

        public T Dequeue()
        {
            return this.heap.Pop();
        }

        public T Peek()
        {
            return this.heap.Peek();
        }
    }
}
