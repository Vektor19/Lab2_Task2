using System;
using System.Linq;
using System.Numerics;

namespace Lab_2.Strategies
{
    internal class ComplexNumbersParsingStrategy : INumbersParsingStrategy<Complex>
    {
        public Complex[] ParseNumbers(string input)
        {
            string[] numberStrings = input.Split(' ');
            Complex[] numbers = new Complex[numberStrings.Length];
            for (int i = 0; i < numberStrings.Length; i++)
            {
                string[] parts;
                if (numberStrings[i].Contains('+'))
                {
                    parts = numberStrings[i].Split('+');
                }
                else if (numberStrings[i].Contains('-'))
                {
                    parts = numberStrings[i].Split('-');
                }
                else
                {
                    throw new FormatException($"Invalid complex number format: {numberStrings[i]}");
                }

                if (parts.Length != 2)
                {
                    throw new FormatException($"Invalid complex number format: {numberStrings[i]}");
                }

                double realPart = double.Parse(parts[0]);
                double imaginaryPart = double.Parse(parts[1].TrimEnd('i'));
                if (numberStrings[i].Contains('-') && parts[1].Contains('i'))
                {
                    imaginaryPart = -imaginaryPart; // Додати від'ємний знак до уявної частини, якщо вона від'ємна
                }
                numbers[i] = new Complex(realPart, imaginaryPart);
            }
            return numbers;
        }
    }
}
