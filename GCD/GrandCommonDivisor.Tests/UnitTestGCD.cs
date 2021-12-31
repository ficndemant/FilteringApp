using System;
using GrandCommonDivisor.Core;
using Xunit;

namespace GrandCommonDivisor.Tests
{
    public class UnitTestGCD
    {
        [Theory]
        [InlineData(1, 2, 1)]
        [InlineData(-4, -6, 2)]
        [InlineData(-2, 2, 2)]
        [InlineData(0, 0, 0)]
        public void CalculateGCD_WhenValidValuesPassed_ReturnsValidResult(int value1, int value2, int expected)
        {
            Assert.Equal(expected, GCDUtils.CalculateGCD(value1, value2));
        }

        [Theory]
        [InlineData(new[] { 12, 48 })]
        [InlineData(new[] { 12, 24, 48 })]
        [InlineData(new[] { 12, 24, 48, 96 })]
        public void CalculateGCDValidParamsPassed_ReturnsValidResult(int[] input)
        {
            var actualCount = 12;
            Assert.Equal(actualCount, GCDUtils.CalculateGCD(input));
        }

        [Fact]
        public void CheckCorrectInput_ReturnsValidResult()
        {
            var userValue = "12";
            var expectedValue = 12;
            Assert.Equal(expectedValue, GCDUtils.CheckInput(userValue));
        }

        [Theory]
        [InlineData("0")]
        public void CheckInputWithAZero_ReturnsValidResult(string param)
        {
            var exception = Assert.Throws<ArgumentException>(() => GCDUtils.CheckInput(param));
            Assert.Equal("You can't use '0'!", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("?")]
        [InlineData("a")]
        public void CheckInputWithABadData_ReturnsValidResult(string param)
        {
            var exception = Assert.Throws<ArgumentException>(() => GCDUtils.CheckInput(param));
            Assert.Equal("Please try number again!", exception.Message);
        }
    }
}

