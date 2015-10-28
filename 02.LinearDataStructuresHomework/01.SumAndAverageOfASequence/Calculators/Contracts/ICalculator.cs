namespace SumAndAverageOfASequence.Calculators.Contracts
{
    using CalculationResults.Contracts;

    public interface ICalculator
    {
        IResult GetSum(params object[] parameters);

        IResult GetAverage(params object[] parameters);
    }
}
