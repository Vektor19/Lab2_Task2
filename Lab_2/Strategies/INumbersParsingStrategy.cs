namespace Lab_2.Strategies
{
    public interface INumbersParsingStrategy<T>
    {
        T[] ParseNumbers(string input);
    }
}
