using Converter.IsoCodeHelpers.Interfaces;
using System.Threading.Tasks;

namespace Converter.Interacts.Implements
{
    public class RateInteractor : IInteractor
    {
        private IIsoCodeHelper _isoCodeHelper;
        private IRequester _requester;

        public RateInteractor(IIsoCodeHelper isoCodeHelper, IRequester requester) //Mock
        {
            _isoCodeHelper = isoCodeHelper;
            _requester = requester;
        }

        public Task<decimal> GetRate(string curFrom, string curTo, string input)
        {
            var curFromCode = _isoCodeHelper.GetIsoCode(curFrom);
            var curToCode = _isoCodeHelper.GetIsoCode(curTo);

            var coefficient = _requester.GetRate(curFromCode, curToCode).Result;

            var result = Calculate(decimal.Parse(input), coefficient);

            return Task.FromResult(result);
        }

        private decimal Calculate(decimal currencyValue, decimal coefficient)
        {
            decimal result = 0;

            if (coefficient == 0)
                result = currencyValue;
            else
                result = currencyValue * coefficient;

            return result;
        }
    }
}