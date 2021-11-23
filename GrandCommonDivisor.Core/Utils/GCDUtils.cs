using GrandCommonDivisor.Core.models;
using System;

namespace GrandCommonDivisor.Core
{
    public static class GCDUtils
    {
        public static NumberParseResult CheckNumber(string number)
        {

            if (!int.TryParse(number, out var num))
            {
                var error = "Please try typing in again!";
                return new NumberParseResult(error);
            }
            
            return new NumberParseResult(num);
        }

        public static int CalculateGCD(int first, int second)
        {
            while (first >= 1)
            {               
                int modulo = first % second;
                if (modulo == 0)
                {
                    break;  
                }
                else
                {
                    first = second;
                    second = modulo;
                }
            }

            return second;
        }
    }
}
