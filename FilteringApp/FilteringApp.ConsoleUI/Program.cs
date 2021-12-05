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
            int[] array = (int[])CycleArrayReading();
            var intValue = (int)CycleFilteringValueReading();
            var userInput = new UserInput(array, intValue);
            DisplayFilteringResults(userInput.FilterOutResults());
            DisplaySummingResults(array.AddArrayElements());
            //DisplayMergeSortResults(array.DoMergeSort());
            //DisplayMergeSortResults(array.DoMergeSort(3,9));
            DisplayMinMax(array.FindMinAndMax());
        }

        public static Array CycleArrayReading()
        {
            try
            {
                return (int[])ReadUserArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return CycleArrayReading();
            }
        }

        public static int CycleFilteringValueReading()
        {
            try
            {
                return ReadUserFilteringNumber();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return CycleFilteringValueReading();
            }
        }

        public static Array ReadUserArray()
        {
            Console.Clear();
            Console.WriteLine("Please provide INT numbers for the array, separated by commas (for example like 1,2,3,4,...,12321,21433).");
            var stringArray = Console.ReadLine().Split(',');

            return stringArray.CheckArray();
        }

        public static int ReadUserFilteringNumber()
        {
            Console.WriteLine("Please provide a SINGLE DIGIT INT value for filtering the array.");
            // ! Need to find another better way to handle more than one digit, eg. search for "12" or "123"
            var value = Console.ReadLine();

            return value.CheckFilteringValue();
        }

        public static void DisplayFilteringResults(List<int> result)
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

        public static void DisplayMergeSortResults(Array array)
        {
            Console.WriteLine("Sorted array looks like this: ");
            foreach (var number in array)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
        }

        public static void DisplayMinMax(Tuple<int,int> tuple)
        {
            Console.WriteLine($"The minimal element of the array is: {tuple.Item1}, the maximal element of the array is: {tuple.Item2}.");
        }

            

            
        
    }
}
