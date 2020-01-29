namespace Converter
{
    public partial class RateRequester
    {
        public class Rate
        {
            public int From { get; }
            public int To { get; }
            public decimal Value { get; }

            public Rate(int from, int to, decimal value)
            {
                From = from;
                To = to;
                Value = value;
            }
        }
    }
}