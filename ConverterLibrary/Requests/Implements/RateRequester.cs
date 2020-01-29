using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Converter
{
    public partial class RateRequester : IRequester
    {
        private List<Rate> _rates;

        public RateRequester()
        {
            InitRates();
        }

        private void InitRates()
        {
            _rates = new List<Rate>
            {
                new Rate(840, 978, 0.91M),
                new Rate(840, 980, 24.42M),
                new Rate(978, 980, 26.93M)
            };
        }

        public Task<decimal> GetRate(int fromCur, int toCur)
        {
            if (fromCur == toCur)
                return Task.FromResult(1M);

            var directRate = _rates.FirstOrDefault(x => x.From == fromCur && x.To == toCur);
            if (directRate != null)
                return Task.FromResult(directRate.Value);

            var backwardsRate = _rates.FirstOrDefault(x => x.From == toCur && x.To == fromCur);
            if (backwardsRate == null)
                throw new RateNotFoundException(fromCur, toCur);

            var result = Math.Round((1 / backwardsRate.Value), 3);

            return Task.FromResult(result);
        }
    }
}