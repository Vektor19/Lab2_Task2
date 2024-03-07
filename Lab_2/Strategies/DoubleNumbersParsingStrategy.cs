namespace Lab_2.Strategies
{
    internal class DoubleNumbersParsingStrategy : INumbersParsingStrategy<double>
    {
        public double[] ParseNumbers(string input)
        {
            string[] numberStrings = input.Split(' ');
            double[] numbers = new double[numberStrings.Length];
            for (int i = 0; i < numberStrings.Length; i++)
            {
                numbers[i] = double.Parse(numberStrings[i]);
            }
            return numbers;
        }
    }
}
