using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Converter.Adapters.Interfaces;
using Converter.Interacts.Implements;

namespace Converter.Adapters.Implements
{
    public class RateAdapter : IAdapter
    {
        private IInteractor _interactor;

        private string _currencyPattern;

        public RateAdapter(IInteractor interactor)
        {
            _interactor = interactor;

            _currencyPattern = @"[0-9]{1,6}(\.[0-9]{1,3})?";
        }

        public Task<string> GetRate(string curFrom, string curTo, string input)
        {
            var rate = _interactor.GetRate(curFrom, curTo, input).Result;

            string result = Regex.Match($"{rate}", _currencyPattern).Value;

            if (string.IsNullOrEmpty(result))
                return Task.FromResult("0");

            return Task.FromResult(result);
        }
    }
}