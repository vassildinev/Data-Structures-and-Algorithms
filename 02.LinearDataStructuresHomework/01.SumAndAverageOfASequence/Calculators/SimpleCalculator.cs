namespace SumAndAverageOfASequence.Calculators
{
    using System.Collections.Generic;

    using CalculationResults;
    using CalculationResults.Contracts;
    using Contracts;

    public class SimpleCalculator : ICalculator
    {
        private decimal? sum = null;
        private decimal? count = null;

        public IResult GetSum(params object[] parameters)
        {
            IEnumerable<int> input = parameters[0] as List<int>;

            long sum = 0;
            this.count = 0;
            foreach (var item in input)
            {
                sum += item;
                this.count += 1;
            }

            this.sum = sum;

            return new CalculationResult(sum);
        }

        public IResult GetAverage(params object[] parameters)
        {
            decimal result;
            if (this.sum == null)
            {
                this.GetSum();
            }

            result = (this.sum / this.count).Value;
            return new CalculationResult(result);
        }
    }
}
