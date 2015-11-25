using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tribonacci
{
    class Program
    {
        static void Main()
        {
            string[] fstn = Console.ReadLine().Split(' ');
            long first = int.Parse(fstn[0]);
            long second = int.Parse(fstn[1]);
            long third = int.Parse(fstn[2]);
            int n = int.Parse(fstn[3]);

            if (n == 1)
            {
                Console.WriteLine(first);
                return;
            }

            if (n == 2)
            {
                Console.WriteLine(second);
                return;
            }

            for (int i = 0; i < n - 3; i++)
            {
                long temp = third;
                third += (first + second);
                first = second;
                second = temp;
            }

            Console.WriteLine(third);
        }
    }
}
