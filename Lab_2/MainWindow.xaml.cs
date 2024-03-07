using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Fractions;
using System.Numerics;
using Lab_2.Strategies;
namespace Lab_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    
    public class MaxProductCalculator<T>
    {
        private IMaxProductStrategy<T> _strategy;

        public MaxProductCalculator(IMaxProductStrategy<T> strategy)
        {
            _strategy = strategy;
        }

        public T CalculateMaxProduct(T[] numbers)
        {
            return _strategy.CalculateMaxProduct(numbers);
        }
    }

    public class NumbersParser<T>
    {
        private INumbersParsingStrategy<T> _strategy;

        public NumbersParser(INumbersParsingStrategy<T> strategy)
        {
            _strategy = strategy;
        }

        public T[] ParseNumbers(string input)
        {
            return _strategy.ParseNumbers(input);
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MaxProductBtn_Click(object sender, RoutedEventArgs e)
        {
            string selectedDataType = (DataTypeComboBox.SelectedItem as ComboBoxItem)?.Tag?.ToString();
            try
            {
                if (selectedDataType == "doubles")
                {
                    NumbersParser<double> numbersParsing = new NumbersParser<double>(new DoubleNumbersParsingStrategy());
                    double[] numbers = numbersParsing.ParseNumbers(numberInputTextBox.Text);
                    MaxProductCalculator<double> calculator = new MaxProductCalculator<double>(new DoubleMaxProductStrategy());
                    double result = calculator.CalculateMaxProduct(numbers);
                    MessageBox.Show(result.ToString());
                }
                else if (selectedDataType == "fractions")
                {
                    NumbersParser<Fraction> numbersParsing = new NumbersParser<Fraction>(new FractionNumbersParsingStrategy());
                    Fraction[] numbers = numbersParsing.ParseNumbers(numberInputTextBox.Text);
                    MaxProductCalculator<Fraction> calculator = new MaxProductCalculator<Fraction>(new FractionMaxProductStrategy());
                    Fraction result = calculator.CalculateMaxProduct(numbers);
                    MessageBox.Show(result.ToString());
                }
                else if (selectedDataType == "complex")
                {
                    NumbersParser<Complex> numbersParsing = new NumbersParser<Complex>(new ComplexNumbersParsingStrategy());
                    Complex[] numbers = numbersParsing.ParseNumbers(numberInputTextBox.Text);
                    MaxProductCalculator<Complex> calculator = new MaxProductCalculator<Complex>(new ComplexMaxProductStrategy());
                    Complex result = calculator.CalculateMaxProduct(numbers);
                    string imaginaryPart = result.Imaginary >= 0 ? $"+ {result.Imaginary}" : $"- {-result.Imaginary}";
                    MessageBox.Show($"{result.Real} {imaginaryPart}i");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void WindowTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
