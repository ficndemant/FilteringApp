using FilteringApp.Core.Models;
using System;
using System.Collections.Generic;


namespace FilteringApp.Core.Utils
{
    public class TheArray
    {
        public List<int> FilterOutResults(UserInput userInput)
        {
            var numbers = userInput.UserArray;
            var number = userInput.IntValue;
            var result = new List<int>();

            for (var i = 0; i < numbers.Length; i++)
            {
                var checkedNumber = numbers[i];
                //would be nice to get how many times a digit appeared in the number. ( level hardcore??? :D )
                //var numberOfExlusions = 0;
                var @break = false;

                var n = checkedNumber;

                while (n > 0 && @break == false)
                {
                    if (n % 10 == number)
                    {
                        //numberOfExlusions++;
                        @break = true;
                        result.Add(numbers[i]);
                    }
                    else
                    {
                        n = n / 10;
                    }
                }
            }

            return result;
        }

        public void DisplayResults(List<int> result)
        {
            Console.WriteLine("This is your set: ");
            foreach (var item in result)
            {
                Console.Write(" " + item + " ");
            }
        }

    }
}
