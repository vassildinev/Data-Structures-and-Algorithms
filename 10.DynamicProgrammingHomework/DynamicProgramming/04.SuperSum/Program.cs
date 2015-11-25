using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSum
{
    class Program
    {
        /*
        nk 0 1 2 3 
        1  1
        2  2
        3  3
        */
        static long[][] dp;
        static void Main()
        {
            string[] kn = Console.ReadLine().Split(' ');
            int K = int.Parse(kn[0]);
            int N = int.Parse(kn[1]);

            dp = new long[N + 1][];

            for (int n = 1; n <= N; n++)
            {
                dp[n] = new long[K + 1];
            }

            for (int k = 0; k <= K; k++)
            {
                for (int n = 1; n <= N; n++)
                {
                    if (k == 0)
                    {
                        dp[n][k] = n;
                        continue;
                    }

                    if (n == 1)
                    {
                        dp[n][k] = dp[n][k - 1];
                        continue;
                    }

                    dp[n][k] = dp[n - 1][k] + dp[n][k - 1];
                }
            }

            Console.WriteLine(dp[N][K]);
        }

        static long SuperSum(int k, int n)
        {
            if (k == 0)
            {
                return n;
            }

            long sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += SuperSum(k - 1, i);
            }

            return sum;
        }
    }
}
