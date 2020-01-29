using Converter.IsoCodeHelpers.Implements;
using Converter.IsoCodeHelpers.Interfaces;
using NUnit.Framework;

namespace ConverterTest
{
    public class IsoCodeHelperTests
    {
        private IIsoCodeHelper _isoCodeHelper;

        [SetUp]
        public void Setup()
        {
            _isoCodeHelper = new IsoCodeHelper();
        }

        [TestCase("USD", 840)]
        [TestCase("EUR", 978)]
        [TestCase("UAH", 980)]
        [TestCase("RUB", 0)]
        public void GetIsoCodeTest(string currency, int expectedurrencyCode)
        {
            // When
            var actualCurrencyCode = _isoCodeHelper.GetIsoCode(currency);

            // Then
            Assert.AreEqual(expectedurrencyCode, actualCurrencyCode);
        }
    }
}