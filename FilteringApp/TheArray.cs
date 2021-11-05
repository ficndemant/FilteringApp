using System;
using System.Collections.Generic;
using System.Text;

namespace FilteringApp
{
    class TheArray
    {
        public void RunTheProgram()
        {
            var userInput = ReadUserInput();
            var results = FilterOutResults(userInput);
            DisplayResults(results);
        }
        private UserInput ReadUserInput()
        {
            var userInput = new UserInput();
            Console.Clear();
            Console.WriteLine("Please provide numbers for the array, separated by commas (,).");
            userInput.UserValue = Console.ReadLine();
            Console.WriteLine("Please provide a value for filtering the array.");
            userInput.FilterValue = Console.ReadLine();
            return userInput;
        }
        private List<string> FilterOutResults(UserInput userInput)
        {
            var numbers = userInput.UserValue.Split(",");
            var result = new List<string>();
            Console.WriteLine("Array values filtered with filter value are: ");
            foreach (var userValue in numbers)
            {
                if (userValue.Contains(userInput.FilterValue))
                {
                    result.Add(userValue);
                }
            }
            return result;
        }
        private void DisplayResults(List<string> results)
        {
            foreach (var item in results)
            {
                Console.WriteLine("This is your set: " + item);
            }
        }

        //public void FilterTheString()
        //{
        //    //string userValues;
        //    //string filterValue;
        //    // READ USER INPUTS
        //    Console.Clear();
        //    Console.WriteLine("Please provide numbers for the array, separated by commas (,).");
        //    // There is a lack below, of controlling what user inputs.
        //    var userValues = Console.ReadLine();
        //    //Console.WriteLine("The array values red are: " + userValues.ToString());
        //    Console.WriteLine("Please provide a value for filtering the array.");
        //    var filterValue = Console.ReadLine().ToString();
        //    //Console.WriteLine("The filter value red is: " + filterValue.ToString());

        //    // INTO STRING ARRAY
        //    string[] numbers = userValues.Split(",");

        //    //FILTER OUT PROPER RESULTS
        //    Console.WriteLine("Array values filtered with filter value are: ");
        //    foreach (var userValue in numbers)
        //    {
        //        if (userValue.Contains(filterValue))
        //        {
        //            Console.WriteLine(userValue);
        //        }
        //    }
        //}
    }
}
