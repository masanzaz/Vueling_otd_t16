using System;
using System.Collections.Generic;
using System.Text;

namespace vuelingDomain.Helper
{
    public static class RoundNumber
    {
        public static decimal RoundHalfToEven(decimal value)
        {
            return Math.Round(Math.Truncate(value * 1000) / 1000, 2, MidpointRounding.ToEven);
        }
    }
}
