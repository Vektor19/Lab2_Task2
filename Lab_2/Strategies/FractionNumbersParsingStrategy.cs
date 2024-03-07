using Fractions;
using System;

namespace Lab_2.Strategies
{
    internal class FractionNumbersParsingStrategy : INumbersParsingStrategy<Fraction>
    {
        public Fraction[] ParseNumbers(string input)
        {
            string[] numberStrings = input.Split(' ');
            Fraction[] numbers = new Fraction[numberStrings.Length];
            for (int i = 0; i < numberStrings.Length; i++)
            {
                string[] parts = numberStrings[i].Split('/');
                if (parts.Length != 2)
                {
                    throw new FormatException($"Invalid fraction format: {numberStrings[i]}");
                }

                if (!int.TryParse(parts[0], out int numerator) || !int.TryParse(parts[1], out int denominator))
                {
                    throw new FormatException($"Invalid fraction format: {numberStrings[i]}");
                }

                numbers[i] = new Fraction(numerator, denominator);
            }
            return numbers;
        }
    }
}
