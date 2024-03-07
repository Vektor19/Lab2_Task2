using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.Strategies
{
    internal class ComplexMaxProductStrategy : IMaxProductStrategy<Complex>
    {
        public Complex CalculateMaxProduct(Complex[] numbers)
        {
            if (numbers == null || numbers.Length < 2)
            {
                throw new ArgumentException("Array should contain at least 2 numbers.");
            }

            Complex maxProduct = new Complex(double.MinValue, double.MinValue);

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    Complex product = numbers[i] * numbers[j];
                    if (double.IsInfinity(maxProduct.Magnitude) || product.Magnitude > maxProduct.Magnitude)
                    {
                        maxProduct = product;
                    }
                }
            }

            return maxProduct;
        }
    }
}
