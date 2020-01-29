using Converter.IsoCodeHelpers.Interfaces;

namespace Converter.IsoCodeHelpers.Implements
{
    public class IsoCodeHelper : IIsoCodeHelper
    {
        public int GetIsoCode(string currency)
        {
            var currencyIsoCode = 0;

            switch (currency)
            {
                case "USD":
                    currencyIsoCode = 840;
                    break;
                case "EUR":
                    currencyIsoCode = 978;
                    break;
                case "UAH":
                    currencyIsoCode = 980;
                    break;
            }

            return currencyIsoCode;
        }
    }
}