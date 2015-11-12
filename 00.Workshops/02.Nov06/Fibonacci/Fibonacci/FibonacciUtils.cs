namespace Fibonacci
{
    public static class FibonacciUtils
    {
        public static FibonacciMatrix Power(FibonacciMatrix matrix, long power)
        {
            if (power == 0)
            {
                return new FibonacciMatrix();
            }

            if (power % 2 == 0)
            {
                return Power(matrix * matrix, power / 2);
            }
            else
            {
                return matrix * Power(matrix, power - 1);
            }
        }
    }
}
