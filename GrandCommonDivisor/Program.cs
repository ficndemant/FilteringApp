using System;
using GrandCommonDivisor.Core;

namespace GrandCommonDivisor.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {   
                var first = ReadUserInput("Hello User!, Please provide the first number.");
                var second = ReadUserInput("Please provide the second number.");
                Console.WriteLine($"Here are your numbers: first: {first}, second: {second} .");
                if (first != 0)
                {
                    var result = GCDUtils.CalculateGCD(first, second);                   
                    Console.WriteLine($"The GCD for {first} and {second} is {result}");
                }      
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static int ReadUserInput(string text)
        {
            try
            {
                Console.WriteLine(text);
                return Console.ReadLine().CheckInput();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ReadUserInput(text);            
            }
        }
    }
}
