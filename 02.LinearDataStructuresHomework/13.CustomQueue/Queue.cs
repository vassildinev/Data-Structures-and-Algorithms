namespace CustomQueue
{
    using System.Collections.Generic;

    public class Queue<T>
    {
        private readonly LinkedList<T> values = new LinkedList<T>();

        public int Count
        {
            get
            {
                return this.values.Count;
            }
        }

        public void Enqueue(T item)
        {
            this.values.AddLast(item);
        }

        public T Dequeue()
        {
            T result = this.values.First.Value;
            this.values.RemoveFirst();

            return result;
        }
    }
}
