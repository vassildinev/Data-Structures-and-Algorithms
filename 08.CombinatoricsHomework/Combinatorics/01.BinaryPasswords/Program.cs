namespace BinaryPasswords
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();
            int countOfMissingBits = inputLine
                .ToCharArray()
                .Where(x=> x == '*')
                .Count();
            if (inputLine == string.Empty)
            {
                Console.WriteLine(0);
                return;
            }

            Console.WriteLine(Math.Pow(2, countOfMissingBits));
        }
    }
}
