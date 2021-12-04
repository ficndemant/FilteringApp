using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilteringApp.Core.Utils
{
    public static class ArrayMergeSort
    {
        public static int[] DoMergeSort(this int[] numbers)
        {
            var sortedNumbers = MergeSort(numbers);
            //  !!!!!!!!!!!!!!   READ WHY BELOW BLOWS UP !!!!!!!!!!!!!!
            //foreach (int number in numbers)
            //{
            //    numbers[number] = sortedNumbers[number];
            //}
            //return sortedNumbers;

            for (int i = 0; i < sortedNumbers.Length; i++)
                numbers[i] = sortedNumbers[i];

            return sortedNumbers;
        }

        public static int[] DoMergeSort(this int[] numbers, int startIndex, int stopIndex)
        {
            var sortedNumbers = MergeSort(numbers,startIndex,stopIndex);
            for (int i = 0; i < sortedNumbers.Length; i++)
                numbers[i] = sortedNumbers[i];

            return sortedNumbers;
        }

        public static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length <= 1)
                return numbers;

            var leftList = new List<int>();
            var rightList = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i%2 == 0)
                {
                    leftList.Add(numbers[i]);
                }
                else
                {
                    rightList.Add(numbers[i]);
                }
            }

            leftList = MergeSort(leftList.ToArray()).ToList();
            rightList = MergeSort(rightList.ToArray()).ToList();

            return Merge(leftList, rightList);
        }

        public static int[] MergeSort(int[] numbers, int startIndex, int stopIndex)
        {
            var length = stopIndex - startIndex;
            int[] range = new int[length];
            for (int i=0; i<length; i++)
            {
                range[i] = numbers[i];
            }

            if (range.Length <= 1)
                return range;

            var leftList = new List<int>();
            var rightList = new List<int>();
            for (int i = 0; i < range.Length; i++)
            {
                if (i % 2 == 0)
                {
                    leftList.Add(range[i]);
                }
                else
                {
                    rightList.Add(range[i]);
                }
            }

            leftList = MergeSort(leftList.ToArray()).ToList();
            rightList = MergeSort(rightList.ToArray()).ToList();

            return Merge(leftList, rightList);
        }

        public static int[] Merge(List<int> leftList, List<int> rightList)
        {
            var result = new List<int>();
            while (NotEmpty(leftList) && NotEmpty(rightList))
            {
                if (leftList.First() >= rightList.First())
                    MoveValueFromListToResult(leftList, result);
                else
                    MoveValueFromListToResult(rightList, result);
            }

            while (NotEmpty(leftList))
            {
                MoveValueFromListToResult(leftList, result);
            }


            while (NotEmpty(rightList))
            {
                MoveValueFromListToResult(rightList, result);
            }

            return result.ToArray();
        }

        private static bool NotEmpty(List<int> list)
        {
            return list.Count > 0;
        }

        private static void MoveValueFromListToResult(List<int> list, List<int> result)
        {
            result.Add(list.First());
            list.RemoveAt(0);
        }
    }
}
