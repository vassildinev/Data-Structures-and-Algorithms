namespace SumAndAverageOfASequence.CalculationResults
{
    using Contracts;

    public class CalculationResult : IResult
    {
        public CalculationResult(decimal value)
        {
            this.Value = value;
        }

        public decimal Value { get; private set; }
    }
}
