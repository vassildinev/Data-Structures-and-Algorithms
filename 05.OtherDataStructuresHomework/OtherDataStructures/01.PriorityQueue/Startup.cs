namespace PriorityQueue
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var queue = new PriorityQueue<string>();
            for (int i = 0; i < 26; i++)
            {
                string name = "Name " + (char)(i + 'a');
                queue.Enqueue(name);
            }

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
