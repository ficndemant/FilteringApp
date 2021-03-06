using FilteringApp.Core.Models;
using System.Collections.Generic;
using System;

namespace FilteringApp.Core.Utils
{
    public static class ArrayUtils
    {
        public static List<int> FilterOutResults(this UserInput input)
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

        public static int AddArrayElements(this int[] array)
        {
            var theSum = 0;
            foreach (int item in array)
            {
                theSum += item;
            }

            return theSum;
        }

        public static int[] CheckArray(this string[] stringArray)
        {
            var array = new int[stringArray.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (!int.TryParse(stringArray[i], out var value))
                {
                    throw new ArgumentException($"Wrong Input in array: {stringArray[i]} Postion :{i + 1}", "ArgumentException");
                }

                array[i] = value;               
            }
            return array;
        }

        public static int CheckFilteringValue(this string value)
        {
            if (!int.TryParse(value, out var val))
            {
                throw new ArgumentException($"Wrong Input of filtering value: {value}");
            }
            else
            {
                return val;
            }
        }

        public static (int min, int max) FindMinAndMax(this int[] array)
        {
            int min = array[0];
            int max = array[0];
            foreach (int v in array)
            {
                if (v < min)
                {
                    min = v;
                }
                if (v > max)
                {
                    max = v;
                }
            }
            return (min, max);
        }
    }
}
