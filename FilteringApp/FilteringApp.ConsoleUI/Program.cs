using FilteringApp.Core.Models;
using FilteringApp.Core.Utils;
using CheckUserInput.Core;
using System;

namespace FilteringApp.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayNumberOK = true;
            var userValueOK = true;
            var userInput = new UserInput();
            //string[] stringArray = new String[0] { };
            //int len = stringArray.Length;
            //int[] array = new int[len];
            int[] array2 = new int[0] { };
            Console.Clear();
            do
            {
                Console.WriteLine("Please provide INT numbers for the array, separated by commas (,).");
                string[] stringArray = Console.ReadLine().Split(',');
                int len = stringArray.Length;
                int[] array = new int[len];

                for (int i = 0; i < len; i++)
                {
                    //array[i] = Convert.ToInt32(stringArray[i]);
                    string v = stringArray[i];
                    var ov = 0;
                    if (!int.TryParse(v, out ov))
                    {
                        Console.WriteLine("Wrong Input in array: " + v + " Postion :" + (i + 1));
                        arrayNumberOK = false;
                    }
                    else
                    {
                        array[i] = Convert.ToInt32(stringArray[i]);
                        arrayNumberOK = true;
                    }
                }
                array2 = array;

                //var userInput = new UserInput();
                userInput.UserArray = array;

                Console.WriteLine("Please provide an INT value for filtering the array.");
                //int value = Convert.ToInt32(Console.ReadLine());
                var value = Console.ReadLine();
                var ovalue = 0;
                var value2 = 0;
                if (!int.TryParse(value, out ovalue))
                {
                    userValueOK = false;
                    Console.WriteLine("Wrong Input of filtering value: " + value);
                }
                else
                {
                    value2 = Convert.ToInt32(ovalue);
                    userValueOK = true;
                }
                userInput.IntValue = value2;
            } while (arrayNumberOK==false && userValueOK==false);

                var theArray = new TheArray();
                //Console.WriteLine("Array values filtered with filter value are: ");
                theArray.DisplayResults(theArray.FilterOutResults(userInput));

                // here i call addition
                var p2funcs = new P2funcs();
            //theArray.DisplayResults(p2funcs.AddArrayElements());
            theArray.DisplaySummingResults(p2funcs.AddArrayElements(array2));
            
        }
    }
}
