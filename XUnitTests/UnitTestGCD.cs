using System;
using GrandCommonDivisor.Core;
using Xunit;

namespace MyFirstUnitTests
{
    public class UnitTestGCD
    {
        [Theory]
        [InlineData(1, 2, 1)]
        [InlineData(-4, -6, 2)]
        [InlineData(-2, 2, 2)]
        public void CalculateGCDGoodData_Passing(int value1, int value2, int expected)
        {
            Assert.Equal(expected, GCDUtils.CalculateGCD(value1, value2));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        public void CalculateGCDZerosDataFed_Passing(int value1, int value2, int expected)
        {
            Assert.Equal(expected, GCDUtils.CalculateGCD(value1, value2));
        }

        [Theory]
        [InlineData(new int[] { 12, 48 })]
        [InlineData(new int[] { 12, 24, 48 })]
        [InlineData(new int[] { 12, 24, 48, 96 })]
        public void CalculateGCDParams_Passing(int[] input)
        {
            var actualCount = 12;
            Assert.Equal(actualCount, GCDUtils.CalculateGCD(input));
        }

        [Fact]
        public void CheckCorrectInput_Passing()
        {
            var userValue = "12";
            var expectedValue = 12;
            Assert.Equal(expectedValue, GCDUtils.CheckInput(userValue));
        }

        [Theory]
        [InlineData("0")]
        public void CheckInputForbiddenValues(string param)
        {
            var exception = Assert.Throws<ArgumentException>(() => GCDUtils.CheckInput(param));
            Assert.Equal("You can't use '0'!", exception.Message);
        }
    }
}

