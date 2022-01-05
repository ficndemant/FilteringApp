using System;
using Polynomials.Core;
using Xunit;

namespace Polynomials.Tests
{
    public class PolynomialTests
    {
        [Fact]
        public void InitiateAPolynomialWithExpectedValue()
        {
            //Arrange
            var arr = new float[] { 1.1F, 1.2F, 1.3F, 1.4F, 1.5F };

            //Act
            var p = new Polynomial(arr);

            //Assert
            for (var i = 0; i < arr.Length; i++)
            {
                Assert.Equal(p[i], arr[i], 8);
            }
        }

        [Fact]
        public void InitiatePolynomialWithMaxLength()
        {
            //Arrange
            var arr = new float[100];
            Array.Fill(arr, 0);

            //Act
            var p = new Polynomial(arr);

            //Assert
            for (var i = 0; i < arr.Length; i++)
            {
                Assert.Equal(p[i], arr[i], 8);
            }
        }

        [Fact]
        public void Test4()
        {
            //Arrange
            var arr = new float[101];
            Array.Fill(arr, 0);

            //Act
            var actualException = Assert.Throws<Exception>(() => new Polynomial(arr));

            //Assert
            Assert.Equal("Max power must be less or equal 100", actualException.Message);
        }

        [Fact]
        public void Test5()
        {

        }

        [Fact]
        public void Test6()
        {

        }

        [Fact]
        public void Test7()
        {

        }

        [Fact]
        public void Test8()
        {

        }

        [Fact]
        public void Test9()
        {

        }

        [Fact]
        public void Test10()
        {

        }

    }
}
