using System;

namespace GrandCommonDivisor.Core
{
    public static class GCDUtils
    {
        public static int CheckInput(this string number)
        {
            if (!int.TryParse(number, out var num))
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

        public static int CalculateGCD(params int[] args)
        {
            if (args.Length == 1)
            {
                return args[0];
            }

            var previous = CalculateGCD(args[0], args[1]);
            for (var i = 2; i < args.Length; i++)
            {
                previous = CalculateGCD(previous, args[i]);
            }

            return previous;
        }
    }
}
