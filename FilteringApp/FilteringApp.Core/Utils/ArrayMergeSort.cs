using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilteringApp.Core.Utils
{
    public static class ArrayMergeSort
    {
        public static int[] MergeSort()
        {
            return default;
        }

        public static int[] Merge()
        {
            return default;
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
