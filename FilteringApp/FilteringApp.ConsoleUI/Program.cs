using FilteringApp.Core.Models;
using FilteringApp.Core.Utils;
using System;

namespace FilteringApp.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //var theArray = new TheArray();
            //theArray.RunTheProgram();

            //var consoleUI = new ConsoleUI();
            //consoleUI.ReadUserArrayAndSearchValue();

            Console.Clear();
            Console.WriteLine("Please provide INT numbers for the array, separated by commas (,).");
            string[] stringArray = Console.ReadLine().Split(',');
            int len = stringArray.Length;
            int[] array = new int[len];

            for (int i = 0; i < len; i++)
            {
                array[i] = Convert.ToInt32(stringArray[i]);
            }
            var userInput = new UserInput();
            userInput.UserArray = array;

            Console.WriteLine("Please provide an INT value for filtering the array.");
            int value = Convert.ToInt32(Console.ReadLine());
            userInput.IntValue = value;

            var theArray = new TheArray();
            Console.WriteLine("Array values filtered with filter value are: ");
            theArray.DisplayResults(theArray.FilterOutResults(userInput));
        }
    }
}
