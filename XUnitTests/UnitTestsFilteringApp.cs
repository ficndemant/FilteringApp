using System;
using FilteringApp.Core.Utils;
using FilteringApp.Core.Models;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace MyFirstUnitTests
{
    public class UnitTestsFilteringApp
    {
        public class ArrayUtilsTests
        {
            [Theory, ClassData(typeof(UserArraInputData))]
            public void TestingFilteringOutResultsOfTheArray_Passing(UserInput userInput, List<int> expected)
            {
                var actual = userInput.FilterOutResults();
                Assert.Equal(expected, actual);
            }

            [Theory, ClassData(typeof(AdditionSetOfArrayData))]
            public void TestArrayElementsAddition_Passing(int[] array, int expected)
            {
                var actual = array.AddArrayElements();
                Assert.Equal(actual, expected);
            }

            [Theory]
            [ClassData(typeof(CheckOfStringInputArrayData))]
            public void TestValidationOfArrayElements_Passing(string[] array,  int[] expected)
            {
                int[] result = array.CheckArray();
                Assert.Equal(result, expected);
            }

            [Theory, ClassData(typeof(CheckOfWrongStringInputArrayDataThrowsException))]
            public void TestValidationOfWrongArrayElementsThrowingRightExceptions_Passing(string[] array)
            {
                var exception = Assert.Throws<ArgumentException>(() => array.CheckArray());
                string res = exception.ParamName;
                Assert.Equal("ArgumentException", res);
            }

            [Theory, ClassData(typeof(CheckFilteringInputValue))]
            public void TestInputFilteringValue(string value, int result)
            {
                var outcome = value.CheckFilteringValue();
                Assert.Equal(outcome, result);
            }

            [Theory]
            [ClassData(typeof(ArrayMinMaxData))]
            public void FindMinAndMax_Passing(int[] input, int min, int max)
            {
                Assert.Equal(max, input.FindMinAndMax().max);
                Assert.Equal(min, input.FindMinAndMax().min);
            }
        }

        public class UserArraInputData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { new UserInput((new int[]{1,2,3,4}),1), new List<int>{ 1 } },
                new object[] { new UserInput((new int[]{1,22,3,4}),2), new List<int> { 22 } }
            };

            public IEnumerator<object[]> GetEnumerator()
            { return _data.GetEnumerator(); }

            IEnumerator IEnumerable.GetEnumerator()
            { return GetEnumerator(); }
        }

        public class AdditionSetOfArrayData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { new int[]{1,2,3,4,1}, 11 },
            };

            public IEnumerator<object[]> GetEnumerator()
            { return _data.GetEnumerator(); }

            IEnumerator IEnumerable.GetEnumerator()
            { return GetEnumerator(); }
        }

        public class CheckOfStringInputArrayData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { new string[] { "1","2","3","4","5" }, new int[] { 1, 2, 3, 4, 5 } },
            };

            public IEnumerator<object[]> GetEnumerator()
            { return _data.GetEnumerator(); }

            IEnumerator IEnumerable.GetEnumerator()
            { return GetEnumerator(); }
        }

        public class CheckOfWrongStringInputArrayDataThrowsException : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { new string[] { "A,2,3,4,5" }},
                new object[] { new string[] { "2,1,!,3,4" }},
                new object[] { new string[] { "2,,,3,4" }}
            };

            public IEnumerator<object[]> GetEnumerator()
            { return _data.GetEnumerator(); }

            IEnumerator IEnumerable.GetEnumerator()
            { return GetEnumerator(); }
        }

        public class CheckFilteringInputValue : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { "1", 1 },
                new object[] { "2", 2 },
                new object[] { "3", 3 },
                new object[] { "1324", 1324 },
            };

            public IEnumerator<object[]> GetEnumerator()
            { return _data.GetEnumerator(); }

            IEnumerator IEnumerable.GetEnumerator()
            { return GetEnumerator(); }
        }

        public class ArrayMinMaxData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] {  new int[] {2, 6, 4, 8, 4 }, 2 , 8 }
            };

            public IEnumerator<object[]> GetEnumerator()
            { return _data.GetEnumerator(); }

            IEnumerator IEnumerable.GetEnumerator()
            { return GetEnumerator(); }
        }
    }
}

