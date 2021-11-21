using FilteringApp.Core.Models;
using FilteringApp.Core.Utils;
using System;
using System.Collections.Generic;

namespace FilteringApp.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int[] array = new int[0];
            var isArrayValid = false;
            var arrayPackage = new ArrayParseResult(array);
            while (isArrayValid == false)
            {
                Console.WriteLine("Please provide INT numbers for the array, separated by commas (for example like 1,2,3,4,...,12321,21433).");
                var stringArray = Console.ReadLine().Split(',');
                arrayPackage = ArrayUtils.CheckArray(stringArray);
                if (arrayPackage.IsValid == false)
                {
                    Console.WriteLine(arrayPackage.Error);
                }
                else
                {
                    isArrayValid = arrayPackage.IsValid;
                }
            }
            var intValue = 0;
            var isFilteringValueValid = false;
            var userValueParseResults = new UserValueParseResult(intValue);
            while (isFilteringValueValid == false)
            {
                Console.WriteLine("Please provide an INT value for filtering the array.");
                var value = Console.ReadLine();
                var intValueObject = ArrayUtils.CheckFilteringValue(value);

                if (intValueObject.IsValid == false)
                {
                    Console.WriteLine(userValueParseResults.Error);
                }
                else
                {
                    intValue = intValueObject.Value;
                    isFilteringValueValid = true;
                }
            }
            var userInput = new UserInput(arrayPackage.Array, intValue);
            var filteredValue = ArrayUtils.FilterOutResults(userInput);
            DispplayFilteringResults(filteredValue);
            DisplaySummingResults(ArrayUtils.AddArrayElements(arrayPackage.Array));
        }

        public static void DispplayFilteringResults(List<int> result)
        {
            Console.WriteLine("This is your filtered set: ");
            foreach (var item in result)
            {
                Console.WriteLine($"{item} ");
            }
        }

        public static void DisplaySummingResults(int theSum)
        {
            Console.WriteLine($"This is the sum of array elements: {theSum}");
        }
    }
}
