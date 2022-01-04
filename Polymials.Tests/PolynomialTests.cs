using System;
using Polynomials.Core;
using Xunit;

namespace Polynomials.Tests
{
    public class PolynomialTests
    {
        [Fact]
        public void Test1()
        {
            Polynomial polynomial = new Polynomial(new float[1]);
            ICloneable cloneable = polynomial;

            polynomial.Clone();
            cloneable.Clone();
        }
    }
}
