using GrandCommonDivisor.Core.models;
using System;

namespace GrandCommonDivisor.Core
{
    public static class GCDUtils
    {
        public static int CalculateGCD(int first, int second)
        {
            if (second == 0)
            {
                return first;
            }

            int modulo = first % second;

            return CalculateGCD(second, modulo);
        }

        public static NumberParseResult CheckNumber(string number)
        {

            if (!int.TryParse(number, out var num))
            {
                var error = "Please try typing in again!";
                return new NumberParseResult(error);
            }
            
            return new NumberParseResult(num);
        }
    }
}
