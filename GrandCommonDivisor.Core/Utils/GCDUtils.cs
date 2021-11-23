using GrandCommonDivisor.Core.models;

namespace GrandCommonDivisor.Core
{
    public static class GCDUtils
    {
        public static NumberParseResult CheckInput(string number)
        {
            if (!int.TryParse(number, out var num))
            {
                var error = "Please try number again!";
                return new NumberParseResult(error);
            }
            
            if (num == 0)
            {
                var error = "You can't use '0'!";
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

                first = second;
                second = modulo;               
            }

            return second;
        }
    }
}
