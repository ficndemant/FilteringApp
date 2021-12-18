using System;
using Xunit;
using GrandCommonDivisor.Core;


namespace XUnitTests
{
    using System.Collections.Generic;
    using Xunit;

    namespace MyFirstUnitTests
    {
        public class UnitTestGCD
        {
            [Theory]
            [InlineData(1, 2, 1)]
            [InlineData(-4, -6, 2)]
            [InlineData(-2, 2, 2)]
            public void CalculateGCD(int value1, int value2, int expected)
            {
                Assert.Equal(expected, GCDUtils.CalculateGCD(value1, value2));
            }

            public static IEnumerable<object[]> SplitCountData =>
                new List<object[]>
                {
                        new object[] { 12,24},
                        new object[] { 12,24,48 },
                        new object[] { 12,24,48,96 }
                };
            [Theory, MemberData(nameof(SplitCountData))]
            public void CalculateGCDParams(int input, int expectedCount)
            {
                var actualCount = 12;
                Assert.Equal(12, GCDUtils.CalculateGCD(expectedCount,actualCount));
            }

            [Fact]
            public void CheckCorrectInput()
            {
                Assert.Equal(12, GCDUtils.CheckInput("12"));
            }

            [Fact]
            public void CheckIncorrectInput_BadCharacterInput()
            {
                var exception = Assert.Throws<ArgumentException>(() => GCDUtils.CheckInput(" "));
                Assert.Equal("Please try number again!", exception.Message);
            }

            [Fact]
            public void CheckIncorrectInput_ZeroInput()
            {
                var exception = Assert.Throws<ArgumentException>(() => GCDUtils.CheckInput("0"));
                Assert.Equal("You can't use '0'!", exception.Message);
            }
        }
    }
}
