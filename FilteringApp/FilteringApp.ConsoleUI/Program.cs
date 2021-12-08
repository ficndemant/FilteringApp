using FilteringApp.Core.Models;
using FilteringApp.Core.Utils;
using FilteringApp.Core.Other;
using System;
using System.Collections.Generic;


namespace FilteringApp.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            FilterTheArray();
            SumTheArray();
            ArrayGetMinMax();
            InstanceCountItself();              
        }

        static void FilterTheArray()
        {
            var userInput = ValidateUserInput();
            DisplayFilteringResults(userInput.FilterOutResults());
            Console.ReadLine();
        }

        static void SumTheArray()
        {
            int[] array = CycleArrayReading();
            DisplaySummingResults(array.AddArrayElements());
            Console.ReadLine();
        }

        static void ArrayGetMinMax()
        {
            int[] array = CycleArrayReading();
            DisplayMinMax(array.FindMinAndMax());
            Console.ReadLine();
        }

        static UserInput ValidateUserInput()
        {
            int[] array = CycleArrayReading();
            var intValue = CycleFilteringValueReading();
            var userInput = new UserInput(array, intValue);

            return userInput;
        }

        private static void InstanceCountItself()
        {
            CreateInstances();
            Console.WriteLine($"Number of living instances of SelfInstanceCount Class is:  { SelfInstanceCount.activeCount}");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.ReadLine();
        }

        private static void CreateInstances()
        {
            new SelfInstanceCount();
            new SelfInstanceCount();
        }

        public static int[] CycleArrayReading()
        {
            try
            {
                return ReadUserArray();
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

        public static int[] ReadUserArray()
        {
            Console.Clear();
            Console.WriteLine("Please provide INT numbers for the array, separated by commas (for example like 1,2,3,4,...,12321,21433).");
            var stringArray = Console.ReadLine().Split(',');

            return stringArray.CheckArray();
        }

        public static int ReadUserFilteringNumber()
        {
            Console.WriteLine("Please provide a SINGLE DIGIT INT value for filtering the array.");
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

        public static void DisplayMinMax((int min, int max) tuple)
        {
            Console.WriteLine($"The minimal element of the array is: {tuple.min}, the maximal element of the array is: {tuple.max}.");
        }  
    }
}
