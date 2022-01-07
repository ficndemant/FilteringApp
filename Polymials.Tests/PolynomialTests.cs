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
        public void InitiatePolynomialWithOverLength_ThrowsProperException()
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
        public void Equals_CheckIfTwoPolynomialsAre_Equal()
        {
            //Arrange
            var p = new Polynomial(new float[] { 1.1F, 1.2F, 1.3F, 1.4F, 1.5F });
            var s = new Polynomial(new float[] { 1.1F, 1.2F, 1.3F, 1.4F, 1.5F });

            //Act
            var result = p.Equals(s);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_CheckIfTwoPolynomialsAre_NotEqual()
        {
            //Arrange
            var p = new Polynomial(new float[] { 1.1F, 1.2F, 1.3F, 1.4F, 1.5F });
            var s = new Polynomial(new float[] { 1.2F, 1.2F, 1.3F, 1.4F, 1.5F });

            //Act
            var result = p.Equals(s);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void Are_FloatsEqualEnough()
        {
            //Arrange
            var left = 1.00001F;
            var right = 1.00001F;
            
            //Act
            var result = Polynomial.FloatsAreEqualEnough(left, right);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Are_Not_FloatsEqualEnough()
        {
            //Arrange
            float left = 1.00001F;
            float right = 1.0001F;

            //Act
            var result = Polynomial.FloatsAreEqualEnough(left, right);

            //Assert
            Assert.False(result);
        }

        //[Theory]
        //[InlineData(new float[] { 1.1F, 1.2F, 1.3F, 1.4F, 1.5F },new float[] { 1.1F, 1.2F, 1.3F, 1.4F, 1.5F })]
        [Fact]
        public void OverloadingEqualsOperatorWith_GodData()
        {
            //Arrange
            var left = new Polynomial(new float[] { 1.1F, 1.2F, 1.3F, 1.4F, 1.5F });
            var right = new Polynomial(new float[] { 1.1F, 1.2F, 1.3F, 1.4F, 1.5F });

            //Act
            var result = left == right;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void OverloadingEqualsOperatorWith_BadData()
        {
            //Arrange
            var left = new Polynomial(new float[] { 1.1F, 1.2F, 1.3F, 1.4F, 1.5F });
            var right = new Polynomial(new float[] { 1.1F, 1.2F, 1.3F, 1.4F });

            //Act
            var result = left == right;

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void OverloadingPlusOperatorWith_TwoGoodPolynomials()
        {
            //Arrange
            var left = new Polynomial(new float[] { 1.1F, 1.2F, 1.3F, 1.4F, 1.5F });
            var right = new Polynomial(new float[] { 1.1F, 1.2F, 1.3F, 1.4F, 1.5F });
            var sum = new Polynomial(new float[] { 2.2F, 2.4F, 2.6F, 2.8F, 3.0F });

            //Act
            var result = left + right;
            var isItTrue = (Polynomial)result == (Polynomial)sum;

            //Assert
            Assert.True(isItTrue);
        }

        [Fact]
        public void OverloadingPlusOperatorWith_LeftNull_Polynomial()
        {
            //Arrange
            var left = (Polynomial)null;
            var right = new Polynomial(new float[] { 1.1F, 1.2F, 1.3F, 1.4F, 1.5F });
            var sum = new Polynomial(new float[] { 1.1F, 1.2F, 1.3F, 1.4F, 1.5F });

            //Act
            var result = left + right;
            var isItTrue = (Polynomial)result == (Polynomial)sum;

            //Assert
            Assert.True(isItTrue);
        }

        [Fact]
        public void OverloadingPlusOperatorWith_RightNull_Polynomial()
        {
            //Arrange
            var left =  new Polynomial(new float[] { 1.1F, 1.2F, 1.3F, 1.4F, 1.5F });
            var right = (Polynomial)null;
            var sum = new Polynomial(new float[] { 1.1F, 1.2F, 1.3F, 1.4F, 1.5F });

            //Act
            var result = left + right;
            var isItTrue = (Polynomial)result == (Polynomial)sum;

            //Assert
            Assert.True(isItTrue);
        }

        [Fact]
        public void OverloadingMinusOperatorWith_TwoGoodPolynomials()
        {
            //Arrange
            var left = new Polynomial(new float[] { 2.2F, 2.4F, 2.6F, 2.8F, 3.0F });
            var right = new Polynomial(new float[] { 1.1F, 1.2F, 1.3F, 1.4F, 1.5F });
            var diff = new Polynomial(new float[] { 1.1F, 1.2F, 1.3F, 1.4F, 1.5F });

            //Act
            var result = left - right;
            var isItTrue = (Polynomial)result == (Polynomial)diff;

            //Assert
            Assert.True(isItTrue);
        }
    }
}
