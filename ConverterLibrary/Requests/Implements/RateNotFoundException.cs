using System;

namespace Converter
{
    public class RateNotFoundException : Exception
    {
        public RateNotFoundException(int fromCur, int toCur)
            : base($"Rate was not found for '{fromCur}'=>'{toCur}'") { }
    }
}