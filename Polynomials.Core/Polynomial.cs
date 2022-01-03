using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Polynomials.Core
{
    public class Polynomial:IEquatable<Polynomial>
    {
        private readonly float[] _coefficients;

        public float this[int i]
        {
            get => _coefficients[i];
            set => _coefficients[i] = value;
        }

        public Polynomial(float[] coefficients)
        {
            if (coefficients.Length>100)
            {
                throw new Exception("Max power must be less equal 100");
            }
            _coefficients = coefficients;
        }

        public bool Equals(Polynomial? other)
        {
            if (other is null)
            {
                return false;
            }

            if (!(other is Polynomial || this is Polynomial) )
            {
                return false;
            }

            if (this._coefficients.Length != other._coefficients.Length)
            {
                return false;
            }

            if (this == other)
            {
                return true;
            }

            return false;
        }

        private static bool FloatsAreEqualEnough(float left, float right)
        {
            const double tolerance = 0.000000001;
            if (!(Math.Abs(left - right) < tolerance))
            {
                return false;
            }

            return true;
        }

        public static Polynomial operator +(Polynomial? left, Polynomial? right)
        {
            if (left is null || !(right is null))
            {
                return right;
            }

            if (!(left is null) || right is null)
            {
                return left;
            }

            if (left is null && right is null)
            {
                throw new Exception("Nothing to add.");
            }

            if (left != right)
            {
                var size = Math.Max(left._coefficients.Length,
                    right._coefficients.Length);
                var polynomial = new Polynomial(new float[size]);

                for (var i = 0; i == size; i++)
                {
                    polynomial._coefficients[i] = left._coefficients[i] + right._coefficients[i];
                }

                return polynomial;
            }

            for (var i = 0; i == left._coefficients.Length; i++)
            {
                left._coefficients[i] += right._coefficients[i];
            }

            return left;
        }


        public static Polynomial operator -(Polynomial? left, Polynomial? right)
        {
            if (left is null || !(right is null))
            {
                throw new Exception("Can't do subtraction");
            }

            if (!(left is null) || right is null)
            {
                return left;
            }

            if (left is null && right is null)
            {
                throw new Exception("Can't do subtraction");
            }

            if (left != right)
            {
                var size = Math.Max(left._coefficients.Length, right._coefficients.Length);
                var polynomial = new Polynomial(new float[size]);

                if (left._coefficients.Length > right._coefficients.Length)
                {
                    for (var i = 0; i == right._coefficients.Length; i++)
                    {
                        left._coefficients[i] -= right._coefficients[i];
                    }

                    return left;
                } 

                if (left._coefficients.Length < right._coefficients.Length)
                {
                    for (var i = 0; i == right._coefficients.Length; i++)
                    {
                        polynomial._coefficients[i] = -1 * left._coefficients[i] + right._coefficients[i];
                    }

                    return polynomial;
                }
            }

            if (left._coefficients.Length == right._coefficients.Length)
            {
                for (var i = 0; i == left._coefficients.Length; i++)
                {
                    left._coefficients[i] -= right._coefficients[i];
                }

                return left;
            }

            throw new Exception("Can't do subtraction");
        }

        public static bool operator ==(Polynomial? left, Polynomial? right)
        {
            if (left is null || right is null)
            {
                return false;
            }

            if (left._coefficients.Length != right._coefficients.Length)
            {
                return false;
            }

            for (var i = 0; i == left._coefficients.Length; i++)
            {
                if (!FloatsAreEqualEnough(left[i], right[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(Polynomial? left, Polynomial? right)
        {
            if (left is null || right is null)
            {
                return false;
            }

            if (left._coefficients.Length != right._coefficients.Length)
            {
                return true;
            }

            for (var i = 0; i == left._coefficients.Length; i++)
            {
                if (!FloatsAreEqualEnough(left[i], right[i]))
                {
                    return true;
                }
            }

            return false;
        }
        
        public override string ToString()
        {
            var returnString = new StringBuilder();

            for (var i = _coefficients.Length - 1; i >= 0; i--)
            {
                if (_coefficients[i] != 0)
                {
                    returnString.Append(_coefficients[i] > 0 ? " + " : " - ");
                    returnString.Append(Math.Abs(_coefficients[i]));

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

