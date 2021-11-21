using FilteringApp.Core.Models;
using System.Collections.Generic;

namespace FilteringApp.Core.Utils
{
    public static class ArrayUtils
    {
        public static List<int> FilterOutResults(UserInput input)
        {
            var result = new List<int>();
            foreach (int v in input.UserArray)
            {
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
            var arrayParseResults = new ArrayParseResult(array);
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (!int.TryParse(stringArray[i], out var value) || string.IsNullOrWhiteSpace(stringArray[i]))
                {
                    var error = $"Wrong Input in array: {stringArray[i]} Postion :{i + 1}";
                    return new ArrayParseResult(error);
                }
                else
                {
                    arrayParseResults.Array[i] = value;
                }
            }
            return arrayParseResults;
        }
        public static UserValueParseResult CheckFilteringValue(string value)
        {
            var userInput = value;
            var intValue = 0;
            var userValueParseResults = new UserValueParseResult(intValue);

            if (!int.TryParse((string)userInput, out var val) || string.IsNullOrWhiteSpace(value))
            {
                var error = $"Wrong Input of filtering value: {userInput}";
                return new UserValueParseResult(error);
            }
            else
            {
                return new UserValueParseResult(val);
            }
        }
    }
}
