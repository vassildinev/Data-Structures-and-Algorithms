namespace Fibonacci
{
    public class FibonacciMatrix
    {
        private const long Modulo = 1000000007;
        private readonly long[,] values;

        public FibonacciMatrix()
        {
            this.values = new long[2, 2];
            this.values[0, 0] = 1;
            this.values[0, 1] = 1;
            this.values[1, 0] = 1;
            this.values[1, 1] = 0;
        }

        public long BaseValue
        {
            get { return this[0, 1]; }
        }

        public FibonacciMatrix(long a, long b, long c, long d)
        {
            this.values = new long[2, 2];
            this.values[0, 0] = a;
            this.values[0, 1] = b;
            this.values[1, 0] = c;
            this.values[1, 1] = d;
        }

        public long this[int row, int col]
        {
            get { return this.values[row, col]; }
            set { this.values[row, col] = value; }
        }

        public static FibonacciMatrix operator *(FibonacciMatrix first, FibonacciMatrix second)
        {
            long a = (first[0, 0] * second[0, 0] + first[0, 1] * second[1, 0]) % Modulo;
            long b = (first[0, 0] * second[0, 1] + first[0, 1] * second[1, 1]) % Modulo;
            long c = (first[1, 0] * second[0, 0] + first[1, 1] * second[1, 0]) % Modulo;
            long d = (first[1, 0] * second[0, 1] + first[1, 1] * second[1, 1]) % Modulo;

            return new FibonacciMatrix(a, b, c, d);
        }
    }
}
