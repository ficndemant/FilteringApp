using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilteringApp.Core.Utils
{
    public static class ArrayMergeSort
    {
        public static void MergeInPlace(int[] a, int l, int m, int r)
        {

            {
                // increment the maximum_element by one to avoid
                // collision of 0 and maximum element of array in modulo
                // operation

                //int mx = max(a[m], a[r]) + 1;
                int mx = Math.Max(a[m], a[r]) + 1;

                int i = l, j = m + 1, k = l;
                while (i <= m && j <= r && k <= r)
                {
                    // recover back original element to compare
                    int e1 = a[i] % mx;
                    int e2 = a[j] % mx;
                    if (e1 <= e2)
                    {
                        a[k] += (e1 * mx);
                        i++;
                        k++;
                    }
                    else
                    {
                        a[k] += (e2 * mx);
                        j++;
                        k++;
                    }
                }

                // process those elements which are left in the array
                while (i <= m)
                {
                    int el = a[i] % mx;
                    a[k] += (el * mx);
                    i++;
                    k++;
                }

                while (j <= r)
                {
                    int el = a[j] % mx;
                    a[k] += (el * mx);
                    j++;
                    k++;
                }

                // finally update elements by dividing with maximum
                // element
                for (int i2 = l; i2 <= r; i2++)
                    a[i] /= mx;

            }
        }

        public static void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {

                // Same as (l + r) / 2, but avoids overflow
                // for large l and r
                int m = l + (r - l) / 2;

                // Sort first and second halves
                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);
                MergeInPlace(arr, l, m, r);
            }
        }

//        //-------------------------------------------------------------------------------------------------
//        public static int[] DoMergeSort(this int[] numbers, int startIndex, int stopIndex)
//        {
//            var sortedNumbers = MergeSortRange(numbers, startIndex, stopIndex);
//            for (int i = 0; i < sortedNumbers.Length; i++)
//                numbers[i] = sortedNumbers[i];

//            return sortedNumbers;
//        }


//        public static int[] MergeSortRange(int[] numbers, int startIndex, int stopIndex)
//        {
//            var length = (stopIndex - startIndex) + 1;
//            int[] range = new int[length];

//            int j = 0;
//            for (int i = startIndex; i <= stopIndex; i++)
//            {
//                range[j] = numbers[i];
//                j++;
//            }

//            if (range.Length <= 1)
//                return range;

//            var leftList = new List<int>();
//            var rightList = new List<int>();
//            for (int i = 0; i < range.Length; i++)
//            {
//                if (i % 2 == 0)
//                {
//                    leftList.Add(range[i]);
//                }
//                else
//                {
//                    rightList.Add(range[i]);
//                }
//            }

//            leftList = MergeSort(leftList.ToArray()).ToList();
//            rightList = MergeSort(rightList.ToArray()).ToList();

//            return Merge(leftList, rightList);
//        }

//        public static int[] MergeSort(int[] numbers)
//        {
//            if (numbers.Length <= 1)
//                return numbers;

//            var leftList = new List<int>();
//            var rightList = new List<int>();

//            for (int i = 0; i < numbers.Length; i++)
//            {
//                if (i % 2 == 0)
//                {
//                    leftList.Add(numbers[i]);
//                }
//                else
//                {
//                    rightList.Add(numbers[i]);
//                }
//            }

//            leftList = MergeSort(leftList.ToArray()).ToList();
//            rightList = MergeSort(rightList.ToArray()).ToList();

//            return Merge(leftList, rightList);
//        }

//        public static int[] Merge(List<int> leftList, List<int> rightList)
//        {
//            var result = new List<int>();
//            while (NotEmpty(leftList) && NotEmpty(rightList))
//            {
//                if (leftList.First() >= rightList.First())
//                {
//                    MoveValueFromListToResult(leftList, result);
//                }
//                else
//                {
//                    MoveValueFromListToResult(rightList, result);
//                }
//            }

//            while (NotEmpty(leftList))
//            {
//                MoveValueFromListToResult(leftList, result);
//            }

//            while (NotEmpty(rightList))
//            {
//                MoveValueFromListToResult(rightList, result);
//            }

//            return result.ToArray();
//        }

//        private static bool NotEmpty(List<int> list)
//        {
//            return list.Count > 0;
//        }

//        private static void MoveValueFromListToResult(List<int> list, List<int> result)
//        {
//            result.Add(list.First());
//            list.RemoveAt(0);
//        }
    }
}
