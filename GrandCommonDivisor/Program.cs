using System;
using GrandCommonDivisor.Core;
using GrandCommonDivisor.Core.models;

namespace GrandCommonDivisor.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = CheckNumber("Hello User!, Please provide the first number.");
            var second = CheckNumber("Please provide the second number.");
            Console.WriteLine($"Here are your numbers: first: {first}, second: {second} .");
            var result = GCDUtils.CalculateGCD(first, second);
            Console.WriteLine($"The GCD for {first} and {second} is {result}");
        }

        private static int CheckNumber(string text)
        {
            var isValid = false;
            NumberParseResult number = null;
            while (isValid == false)
            {
                Console.WriteLine($"{text}");
                number = GCDUtils.CheckInput(Console.ReadLine());
                if (number.IsValid == false)
                {
                    Console.WriteLine(number.Error);
                }
                
                isValid = true;               
            }

            return number.Number;            
        }
    }
}
