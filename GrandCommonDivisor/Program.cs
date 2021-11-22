using System;
using GrandCommonDivisor.Core;
using GrandCommonDivisor.Core.models;

namespace GrandCommonDivisor.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            var isFirstValid = false;
            var first = new NumberParseResult();


            while (isFirstValid == false)
            {
                Console.WriteLine("Hello User!, Please provide first number.");
                first = GCDUtils.CheckNumber(Console.ReadLine());
                if (first.IsValid == false)
                {
                    Console.WriteLine(first.Error);
                }
                else
                {
                    isFirstValid = true;
                }
                    
            }

            var isSecondValid = false;
            var second = new NumberParseResult();

            while (isSecondValid == false)
            {
                Console.WriteLine("Hello User!, Please provide second number.");
                second = GCDUtils.CheckNumber(Console.ReadLine());
                if (second.IsValid == false)
                {
                    Console.WriteLine(second.Error);
                }
                else
                {
                    isSecondValid = true;
                }

            }

            Console.WriteLine($"Here are the numbers: first - {first.Number}, second - {second.Number} .");
            var p = GCDUtils.CalculateGCD(first.Number, second.Number);
            Console.WriteLine($"The GCD for {first.Number} and {second.Number} is {p}");
        }
    }
}
