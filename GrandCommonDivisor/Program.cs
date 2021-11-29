using System;
using GrandCommonDivisor.Core;
using GrandCommonDivisor.Core.Models;

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
                
                // shitty control over user typing in FIRST = 0
                Console.WriteLine("You can't choose first number as a 0");          
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType());
                Console.WriteLine(ex.Message);
            }
            // Now is it OK to control the program depending on caught errors? 
            // And if yes - then how?
            // I could catch both types of exceptions here and do something when i catch it
        }

        private static int ReadUserInput(string text)
        {
            var isValid = false;
            NumberParseResult number = null;
            while (isValid == false)
            {
                    Console.WriteLine(text);
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
