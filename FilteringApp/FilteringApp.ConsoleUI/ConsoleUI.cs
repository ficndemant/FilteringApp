using System;
using System.Collections.Generic;
using System.Text;
using FilteringApp.Core.Models;
using FilteringApp.Core.Utils;


namespace FilteringApp.ConsoleUI
{
    public class ConsoleUI
    {
          private void CalculateResult(UserInput userInput)
        {
            var theArray = new TheArray();
            Console.WriteLine("Array values filtered with filter value are: ");
            theArray.DisplayResults(theArray.FilterOutResults(userInput));
        }

        //public ConsoleUI()
        //{

        //}


    }
}
