using FilteringApp.Core.Models;
using FilteringApp.Core.Utils;
using FilteringApp.Core.Other;
using System;
using System.Collections.Generic;


namespace FilteringApp.ConsoleUI
{
    class Program
    {
        //class A
        //{
        //    public int B { get; set; }

        //    public override string ToString()
        //    {
        //        return B.ToString();
        //    }
        //}

        private static void Main(string[] args)
        {
            //var a = new A { B = 1 };
            //Console.WriteLine(a.ToString());
            FilterTheArray();
            SumTheArray();
            ArrayGetMinMax();
            //InstanceCountItself();
            //int[] array = CycleArrayReading();
            //DisplayMergeSortResults(ArrayMergeSort.DoMergeSort(array,0,9));
            //DoMergeSort();
        }

        private static void DoMergeSort()
        {
            int[] nums = { 12, 11, 13, 5, 6, 7 };
            int nums_size = (int)nums.Length;

            ArrayMergeSort.MergeSort(nums, 0, 5);
            for (int i = 0; i < nums_size; i++)
            {
                Console.WriteLine($"arr[i]={nums[i]} ,");
            }
        }

        private static void FilterTheArray()
        {
            var userInput = ValidateUserInput();
            DisplayFilteringResults(userInput.FilterOutResults());
            Console.ReadLine();
        }

        private static void SumTheArray()
        {
            var array = CycleArrayReading();
            DisplaySummingResults(array.AddArrayElements());
            Console.ReadLine();
        }

        private static void ArrayGetMinMax()
        {
            var array = CycleArrayReading();
            DisplayMinMax(array.FindMinAndMax());
            Console.ReadLine();
        }

        private static UserInput ValidateUserInput()
        {
            var array = CycleArrayReading();
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

        private static int[] CycleArrayReading()
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

        private static int CycleFilteringValueReading()
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

        private static int[] ReadUserArray()
        {
            Console.Clear();
            Console.WriteLine("Please provide INT numbers for the array, separated by commas (for example like 1,2,3,4,...,12321,21433).");
            var stringArray = Console.ReadLine().Split(',');

            return stringArray.CheckArray();
        }

        private static int ReadUserFilteringNumber()
        {
            Console.WriteLine("Please provide a SINGLE DIGIT INT value for filtering the array.");
            var value = Console.ReadLine();

            return value.CheckFilteringValue();
        }

        private static void DisplayFilteringResults(List<int> result)
        {
            Console.WriteLine("This is your filtered set: ");
            foreach (var item in result)
            {
                Console.WriteLine($"{item} ");
            }
        }

        private static void DisplaySummingResults(int theSum)
        {
            Console.WriteLine($"This is the sum of array elements: {theSum}");
        }

        private static void DisplayMergeSortResults(int[] array)
        {
            Console.WriteLine("Sorted array looks like this: ");
            foreach (var number in array)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
        }

        private static void DisplayMinMax((int min, int max) tuple)
        {
            Console.WriteLine($"The minimal element of the array is: {tuple.min}, the maximal element of the array is: {tuple.max}.");
        }  
    }
}
