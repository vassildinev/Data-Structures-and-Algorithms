namespace LongestSubsequence
{
    using System.Collections.Generic;

    public class LongestSubsequenceSearcher
    {
        public int Run(IList<int> numbers)
        {
            int bestResult = 1;
            int result = 1;
            for (int i = 1; i < numbers.Count; i++)
            {
                int previousNumber = numbers[i - 1];
                int currentNumber = numbers[i];
                if (currentNumber == previousNumber)
                {
                    result++;
                }
                else
                {
                    if (result > bestResult)
                    {
                        bestResult = result;
                        result = 1;
                    }
                }
            }

            if (result > bestResult)
            {
                bestResult = result;
            }

            return bestResult;
        }
    }
}
