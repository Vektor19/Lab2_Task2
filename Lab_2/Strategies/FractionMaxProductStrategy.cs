using Fractions;
using System;

namespace Lab_2.Strategies
{
    internal class FractionMaxProductStrategy : IMaxProductStrategy<Fraction>
    {
        public Fraction CalculateMaxProduct(Fraction[] numbers)
        {
            if (numbers == null || numbers.Length < 2)
            {
                throw new ArgumentException("Array should contain at least 2 numbers.");
            }

            Fraction maxProduct = Fraction.Zero;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    Fraction product = numbers[i] * numbers[j];
                    if (product > maxProduct)
                    {
                        maxProduct = product;
                    }
                }
            }
            return maxProduct;

        }
    }
}
