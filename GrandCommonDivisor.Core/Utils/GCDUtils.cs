using GrandCommonDivisor.Core.models;
using System;

namespace GrandCommonDivisor.Core
{
    public static class GCDUtils
    {
        public static int CalculateGCD(int firstN, int secondN)
        {
            if (secondN == 0)
            {
                return firstN;
            }
            int modulo = firstN % secondN;

            return CalculateGCD(secondN, modulo);
        }

        public static NumberParseResult CheckNumber(string number)
        {
            int num;

            if (!int.TryParse(number, out num))
            {
                var error = "Please try typing in again!";
                return new NumberParseResult(error);
            }
            
            return new NumberParseResult(num);
        }
    }



    
}
