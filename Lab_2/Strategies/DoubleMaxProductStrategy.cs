using System;

namespace Lab_2.Strategies
{
    internal class DoubleMaxProductStrategy : IMaxProductStrategy<double>
    {
        public double CalculateMaxProduct(double[] numbers)
        {
            if (numbers == null || numbers.Length < 2)
            {
                throw new ArgumentException("Array should contain at least 2 numbers.");
            }

            double maxProduct = double.MinValue;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    double product = numbers[i] * numbers[j];
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
