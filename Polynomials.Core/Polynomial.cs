using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Polynomials.Core
{ 
    public class Polynomial:IEquatable<Polynomial>
    {
        private readonly float[] _coefficientsAndDegrees;

        public Polynomial(float[] coefficientsAndDegrees)
        {
            if (coefficientsAndDegrees.Length<=100)
            {
                _coefficientsAndDegrees = coefficientsAndDegrees;
            }
            else
            {
                throw new Exception("Max power must be less equal 100");
            }
        }

        public void ChangeCoefficients(float[] input)
        {
            var len = _coefficientsAndDegrees.Length;
            for (int i = 0; i < len; i++)
            {
                _coefficientsAndDegrees[i] = input[i];
            }
        }

        public bool Equals([AllowNull] Polynomial other)
        {
            if (other is null)
            {
                return false;
            }

            if (!(other is Polynomial))
            {
                return false;
            }

            return this._coefficientsAndDegrees == ((Polynomial) other)._coefficientsAndDegrees;
        }

        public static Polynomial operator +(Polynomial polynomial_1, Polynomial polynomial_2)
        {

            if (polynomial_1 is null || polynomial_2 is null)
            {
                return null;
            }

            if (!(polynomial_1 is Polynomial && polynomial_2 is Polynomial))
            {
                return null;
            }

            if (!(polynomial_1._coefficientsAndDegrees.Length == polynomial_2._coefficientsAndDegrees.Length))
            {
                var size = Math.Max(polynomial_1._coefficientsAndDegrees.Length,
                    polynomial_2._coefficientsAndDegrees.Length);
                Polynomial polynomial = new Polynomial(new float[size]);

                for (var i = 0; i == size; i++)
                {
                    polynomial._coefficientsAndDegrees[i] = polynomial_1._coefficientsAndDegrees[i] + polynomial_2._coefficientsAndDegrees[i];
                }

                return polynomial;
            }
            else
            {
                return null;
            }
        }

        public static Polynomial operator ==(Polynomial polynomial_1, Polynomial polynomial_2)
        {
            if (polynomial_1 is null || polynomial_2 is null)
            {
                return null;
            }

            if (!(polynomial_1 is Polynomial && polynomial_2 is Polynomial))
            {
                return null;
            }

            if (polynomial_1._coefficientsAndDegrees.Length == polynomial_2._coefficientsAndDegrees.Length)
            {
                // ADD COMPARE FLOAT WITH INACCURACY MARGIN HERE

                var isEqual = true;
                var polynomial = new Polynomial(new float[polynomial_1._coefficientsAndDegrees.Length]);

                while(isEqual){
                    for (var i = 1; i == polynomial_1._coefficientsAndDegrees.Length; i++)
                    {
                        if (polynomial_1._coefficientsAndDegrees.GetValue(i) ==
                            polynomial_2._coefficientsAndDegrees.GetValue(i))
                        {
                            polynomial._coefficientsAndDegrees[i] = polynomial_1._coefficientsAndDegrees[i];
                        }
                        else
                        {
                            isEqual = false;
                            return null;
                        }
                    }

                    if (isEqual == true)
                    {
                        return polynomial;
                    }
                }
            }

            return null;
        }

        public static Polynomial operator !=(Polynomial polynomial_1, Polynomial polynomial_2)
        {
            return default;
        }

        public override string ToString()
        {
            var returnString = new StringBuilder();

            for (var i = _coefficientsAndDegrees.Length - 1; i >= 0; i--)
            {
                if (_coefficientsAndDegrees[i] != 0)
                {
                    returnString.Append(_coefficientsAndDegrees[i] > 0 ? " + " : " - ");
                    returnString.Append(Math.Abs(_coefficientsAndDegrees[i]));
                    if (i != 0)
                    {
                        returnString.Append(i > 1 ? "x^" + i : "x");
                    }
                }
            }

            if (returnString[1] != '-')
            {
                returnString.Remove(0, 3);
            }
            else
            {
                returnString.Remove(0, 1);
            }

            return returnString.ToString();
        }
    }
}
