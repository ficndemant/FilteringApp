using FilteringApp.Core.Models;
using FilteringApp.Core.Utils;
using CheckUserInput.Core;
using System;
using System.Collections.Generic;

namespace FilteringApp.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayNumberOK = true;
            var userValueOK = true;
            Console.Clear();

            int[] array = new int[0];
            int intValue = 0;
            do
            {
                Console.WriteLine("Please provide INT numbers for the array, separated by commas (for example like 1,2,3,4,...,12321,21433).");
                var stringArray = Console.ReadLine().Split(',');
                array = new int[stringArray.Length];

                for (int i = 0; i < stringArray.Length; i++)
                {
                    // zmienic nazwe oovalue
                    if (!int.TryParse(stringArray[i], out var oovalue))
                    {
                        Console.WriteLine($"Wrong Input in array: {stringArray[i]} Postion :{i + 1}");
                        arrayNumberOK = false;
                    }
                    else
                    {
                        array[i] = oovalue;
                        arrayNumberOK = true;
                    }
                }

                Console.WriteLine("Please provide an INT value for filtering the array.");
                
                var value = Console.ReadLine();
                if (!int.TryParse(value, out intValue))
                {
                    userValueOK = false;
                    Console.WriteLine($"Wrong Input of filtering value: {value}");
                }
                else
                {
                    userValueOK = true;
                }

            } while (arrayNumberOK == false && userValueOK == false);

            var userInput = new UserInput(array, intValue);
            var filteredValue = ArrayUtils.FilterOutResults(userInput);

            // here i call addition
            //var p2funcs = new P2funcs();
            //P2funcs.AddArrayElements(array);

            DisplayResults(filteredValue);
        }


        public static void DisplayResults(List<int> result)
        {
            Console.WriteLine("This is your filtered set: ");
            foreach (var item in result)
            {
                Console.WriteLine($" {item} ");
            }
        }

        public void DisplaySummingResults(int theSum)
        {
            Console.WriteLine($"This is the sum of array elements: {theSum}");
        }
    }
}
