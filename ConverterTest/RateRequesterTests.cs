using Converter;
using NUnit.Framework;

namespace ConverterTest
{
    public class RateRequesterTests
    {
        private RateRequester _rateRequester;

        private const int EurCode = 978;
        private const int UsdCode = 840;
        private const int UahCode = 980;

        [SetUp]
        public void Setup()
        {
            _rateRequester = new RateRequester();
        }

        [TestCase(UsdCode, EurCode, 0.91)]
        [TestCase(EurCode, UsdCode, 1.099)]
        [TestCase(UsdCode, UahCode, 24.42)]
        [TestCase(UahCode, EurCode, 0.037)]
        [TestCase(EurCode, UahCode, 26.93)]
        public void GetRateTest(int fromCur, int toCur, decimal expectedRate)
        {
            // When
            var actualRate = _rateRequester.GetRate(fromCur, toCur).Result;

            // Then
            Assert.AreEqual(expectedRate, actualRate);
        }

        [TestCase(UsdCode, -1)]
        public void GetRateUsdToUnknownTest(int UsdCode, int toCur)
        {
            // When
            var actualRate = 0M;

            // Then
            Assert.Throws<RateNotFoundException>(
            () =>
            {
                actualRate = _rateRequester.GetRate(UsdCode, toCur).Result;
            });
        }
    }
}