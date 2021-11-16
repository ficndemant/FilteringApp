using FilteringApp.Core.Models;
using System;
using System.Collections.Generic;


namespace FilteringApp.Core.Utils
{
    public class TheArray
    {
        

        //public void RunTheProgram()
        //{
        //    var userInput = ReadUserInput();
        //    var results = FilterOutResults(userInput);
        //    DisplayResults(results);
        //}

        //private UserInput ReadUserInput() { 


        //    var userInput = new UserInput();
        //    var dupa = new ConsoleUI();


        //    //Console.Clear();
        //    //Console.WriteLine("Please provide numbers for the array, separated by commas (,).");
        //    userInput.UserValue = Console.ReadLine();
        //    //userInput.UserValue = Console.ReadLine();
        //    //Console.WriteLine("Please provide a value for filtering the array.");
        //    userInput.FilterValue = Console.ReadLine();
        //    return userInput;
        //}

        //// Move to Core project
        //// Static class DigitFilter
        public List<string> FilterOutResults(UserInput userInput)
        {
            var numbers = userInput.UserArray;
            var number = userInput.IntValue;
            var result = new List<string>();

            for (var i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("FOR: i fora wynosi: " + i);

                var checkedNumber = numbers[i];
                var numberOfExlusions = 0;
                var digitWasFound = false;

                var n = checkedNumber;

                while ((checkedNumber > 0) && ( digitWasFound == false ))
                {
                    if (checkedNumber % 10 == number)
                    {
                        numberOfExlusions++;
                        digitWasFound = true;
                        Console.WriteLine("I have got the digit in the number alright!");
                        result.Add(numbers[i].ToString());
                        Console.WriteLine("Appended the number to the string");
                        n = n / 10;

                    }
                }

            }
            
            return result;
        }



        public void DisplayResults(List<string> result)
        {
            Console.WriteLine("This is your set: ");
            foreach (var item in result)
            {
                Console.WriteLine(" " + item + ",");
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
