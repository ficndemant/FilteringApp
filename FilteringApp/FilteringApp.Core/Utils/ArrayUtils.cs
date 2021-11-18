using FilteringApp.Core.Models;
using System;
using System.Collections.Generic;


namespace FilteringApp.Core.Utils
{
    public static class ArrayUtils
    {
        // do not change parameter values
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
    }
}
