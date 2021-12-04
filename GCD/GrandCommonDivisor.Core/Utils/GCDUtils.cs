using System;

namespace GrandCommonDivisor.Core
{
    public static class GCDUtils
    {
        public static int CheckInput(this string number)
        {
            int num;
            if (!int.TryParse(number, out num))
            {
                throw new ArgumentException("Please try number again!");
            }

            if (num == 0)
            {
                throw new ArgumentException("You can't use '0'!");
            }

            return num;
        }

        public static int CalculateGCD(int first, int second)
        {
            while (first != 0)
            {               
                int modulo = first % second;
                if (modulo == 0)
                {
                    break;  
                }

                first = second;
                second = modulo;               
            }

            return Math.Abs(second);
        }
    }
}
