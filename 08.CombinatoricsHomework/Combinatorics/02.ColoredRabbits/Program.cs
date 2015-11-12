namespace ColoredRabbits
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            IDictionary<int, int> responses = new Dictionary<int, int>();
            int responsesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < responsesCount; i++)
            {
                int response = int.Parse(Console.ReadLine());
                if (!responses.ContainsKey(response))
                {
                    responses[response] = 0;
                }

                responses[response] += 1;
            }

            decimal totalNumberOfRabbits = 0;
            foreach (var item in responses)
            {
                decimal result = Math.Ceiling((decimal)item.Value / (item.Key + 1));
                totalNumberOfRabbits += result * (item.Key + 1);
            }

            Console.WriteLine(totalNumberOfRabbits);
        }
    }
}
