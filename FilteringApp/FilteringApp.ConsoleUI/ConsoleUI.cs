using System;
using System.Collections.Generic;
using System.Text;
using FilteringApp.Core.Models;
using FilteringApp.Core.Utils;


namespace FilteringApp.ConsoleUI
{
    public class ConsoleUI
    {
        //private UserInput ReadUserArrayAndSearchValue()
        //{
            
            //Console.Clear();
            //Console.WriteLine("Please provide INT numbers for the array, separated by commas (,).");
            //string[] stringArray = Console.ReadLine().Split(',');
            //int len = stringArray.Length;
            //int[] array = new int[len];

            //for (int i = 0; i < len; i++)
            //{
            //    array[i] = Convert.ToInt32(stringArray[i]);
            //}
            //var userInput = new UserInput();
            //userInput.UserArray = array;

            //Console.WriteLine("Please provide an INT value for filtering the array.");
            //int value = Convert.ToInt32(Console.ReadLine());
            //userInput.IntValue = value;

            //return userInput;
        //}
        
        private void CalculateResult(UserInput userInput)
        {
            var theArray = new TheArray();
            Console.WriteLine("Array values filtered with filter value are: ");
            theArray.DisplayResults(theArray.FilterOutResults(userInput));
        }

        // OLD STORY SHORT:
        //private int[] ReadUserArray()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Please provide numbers for the array, separated by commas (,).");
        //    string[] stringArray = Console.ReadLine().Split(',');
        //    int len = stringArray.Length;
        //    int[] array = new int[len];

        //    for (int i = 0; i < len; i++)
        //    {
        //        array[i] = Convert.ToInt32(stringArray[i]);
        //    }
        //    return array;
        //}

        //private int ReadUserSearchValue()
        //{
        //    Console.WriteLine("Please provide a value for filtering the array.");
        //    int value = Convert.ToInt32(Console.ReadLine());
        //    return value;
        //}


        public ConsoleUI()
        {

        }


    }
}
