using GrandCommonDivisor.Core.Models;
using System;

namespace GrandCommonDivisor.Core
{
    public static class GCDUtils
    {
        public static NumberParseResult CheckInput(string number)
        {
            try
            {
                return new NumberParseResult(int.Parse(number));
            }
            catch (FormatException ex)
            {
                throw;
            }
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

                first = second;
                second = modulo;               
            }

            return second;
        }
    }
}
