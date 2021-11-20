using FilteringApp.Core.Models;
using System;
using System.Collections.Generic;


namespace FilteringApp.Core.Utils
{
    public static class ArrayUtils
    {
        // do not change input parameter values, like NEVER!!!
        public static List<int> FilterOutResults(UserInput input)
        {
            var result = new List<int>();

            foreach (int v in input.UserArray)
            {
                // and not changing is here below! IMPORTANT!
                var current = v;
                while (current > 0)
                {
                    if (current % 10 == input.IntValue)
                    {
                        result.Add(current);
                        break;
                    }
                    else
                    {
                        current /= 10;
                    }
                }
            }

            return result;
        }
        public static int AddArrayElements(int[] array)
        {
            var theSum = 0;
            foreach (int item in array)
            {
                theSum += item; 
            }
            return theSum;
        }



        public static ArrayParseResult CheckArray(string[] stringArray)
        {
            var array = new int[stringArray.Length];
            var isValid = false;
            var error = "";

            var arrayParseResults = new ArrayParseResult(isValid,array,error);
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (!int.TryParse(stringArray[i], out var value) || stringArray[i] == "")
                {
                    arrayParseResults.Error = $"Wrong Input in array: {stringArray[i]} Postion :{i + 1}";
                    arrayParseResults.IsValid = false;
                }
                else
                {
                    arrayParseResults.Array[i] = value;
                    arrayParseResults.IsValid = true;
                }
            }
            return arrayParseResults;
        }

        public static UserValueParseResult CheckFilteringValue(string value)
        {
            
            var userInput = value;
            var intValue = 0;
            var error = "";

            var userValueParseResults = new UserValueParseResult(intValue);

            if (!int.TryParse((string)userInput, out var val))
            {
                error = $"Wrong Input of filtering value: {userInput}";
                //userValueParseResults.IsValid = false;
                return new UserValueParseResult(error);
            }
            else
            {
                //userValueParseResults.Value = val;
                //userValueParseResults.IsValid = true;
                return new UserValueParseResult(val);

            }
            return userValueParseResults;
        }

    }
}
