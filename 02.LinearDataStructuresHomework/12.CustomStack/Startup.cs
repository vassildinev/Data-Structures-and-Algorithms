namespace CustomStack
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var myStack = new Stack<int>();
            for (int i = 0; i < 50; i++)
            {
                myStack.Push(i);
            }

            Console.WriteLine(myStack.Count);
            Console.WriteLine(myStack.Capacity);

            while (myStack.Count > 0)
            {
                myStack.Pop();
            }
            
            Console.WriteLine(myStack.Count);
        }
    }
}
