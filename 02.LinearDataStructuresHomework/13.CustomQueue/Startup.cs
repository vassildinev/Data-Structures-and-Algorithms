namespace CustomQueue
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var myQueue = new Queue<int>();
            for (int i = 0; i < 20; i++)
            {
                myQueue.Enqueue(i);
            }

            while (myQueue.Count > 0)
            {
                Console.WriteLine(myQueue.Dequeue());
            }
        }
    }
}
