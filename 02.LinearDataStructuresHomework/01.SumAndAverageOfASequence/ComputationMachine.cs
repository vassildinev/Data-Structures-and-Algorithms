namespace SumAndAverageOfASequence
{
    using System;
    using System.Collections.Generic;

    using Calculators;
    using InputProviders;

    public class ComputationMachine
    {
        private static ComputationMachine instance;

        private ComputationMachine()
        {
        }

        public static ComputationMachine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ComputationMachine();
                }

                return instance;
            }
        }

        public void Run()
        {
            var inputProvider = new ConsoleInputProvider();
            var calculator = new SimpleCalculator();
            IEnumerable<int> data = inputProvider.ReadData();
            Console.WriteLine($"Sum: {calculator.GetSum(data).Value}");
            Console.WriteLine($"Average: {calculator.GetAverage(data).Value}");
        }
    }
}
