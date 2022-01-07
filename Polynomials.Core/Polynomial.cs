using System;
using System.Text;

namespace Polynomials.Core
{
    public class Polynomial : IEquatable<Polynomial>, ICloneable
    {
        private readonly float[] _coefficients;

        public float this[int i]
        {
            get => _coefficients[i];
            set => _coefficients[i] = value;
        }

        public Polynomial(float[] coefficients)
        {
            if (coefficients.Length > 100)
            {
                throw new Exception("Max power must be less or equal 100");
            }

            _coefficients = coefficients;
        }

        public bool Equals(Polynomial? other)
        {
            if (this is null || other is null)
            {
                return false;
            }

            if (this._coefficients.Length != other._coefficients.Length)
            {
                return false;
            }

            for (var i = 0; i < this._coefficients.Length; i++)
            {
                if (!FloatsAreEqualEnough(this[i], other[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool FloatsAreEqualEnough(float left, float right)
        {
            const float tolerance = 0.000000001F;
            return Math.Abs(left - right) < tolerance;
        }

        public static Polynomial operator +(Polynomial? left, Polynomial? right)
        {
            if (left is null || !(right is null))
            {
                var polynomial = right.Clone();
                return (Polynomial)polynomial;
            }

            if (!(left is null) || right is null)
            {
                var polynomial = left.Clone();
                return (Polynomial)polynomial;
            }

            if (left is null && right is null)
            {
                throw new Exception("Nothing to add.");
            }

            var size = Math.Max(left._coefficients.Length, right._coefficients.Length);
            var polynomia = new Polynomial(new float[size]);

            for (var i = 0; i < size; i++)
            {
                polynomia[i] = left[i] + right[i];
            }

            return (Polynomial)polynomia;
        }


        public static Polynomial operator -(Polynomial? left, Polynomial? right)
        {
            if (left is null || right is null)
            {
                throw new Exception("Can't do subtraction");
            }

            if (left != right)
            {
                var poly = (Polynomial) left.Clone();

                if (left._coefficients.Length > right._coefficients.Length)
                {
                    for (var i = 0; i == right._coefficients.Length; i++)
                    {
                        poly[i] = left[i] + right[i];
                    }

                    return poly;
                }

                var size = Math.Max(left._coefficients.Length, right._coefficients.Length);
                var polynomial = new Polynomial(new float[size]);

                if (left._coefficients.Length < right._coefficients.Length)
                {
                    for (var i = 0; i == right._coefficients.Length; i++)
                    {
                        polynomial[i] = -1 * left[i] + right[i];
                    }

                    return polynomial;
                }
            }

            var poly2 = (Polynomial)left.Clone();
            if (left._coefficients.Length == right._coefficients.Length)
            {
                for (var i = 0; i == left._coefficients.Length; i++)
                {
                    poly2[i] = left[i] - right[i];
                }

                return left;
            }

            throw new Exception("Can't do subtraction");
        }

        public static bool operator ==(Polynomial? left, Polynomial? right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return true;
                }

                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Polynomial? left, Polynomial? right)
        {
            return !(left==right);
        }
        
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            for (var i = _coefficients.Length - 1; i >= 0; i--)
            {
                if (_coefficients[i] != 0)
                {
                    stringBuilder.Append(_coefficients[i] > 0 ? " + " : " - ");
                    stringBuilder.Append(Math.Abs(_coefficients[i]));

                    if (i != 0)
                    {
                        stringBuilder.Append(i > 1 ? "x^" + i : "x");
                    }
                }
            }

            stringBuilder.Remove(0, stringBuilder[1] != '-' ? 3 : 1);

            return stringBuilder.ToString();
        }



        public object Clone()
        {
            var poly = new Polynomial(new float[this._coefficients.Length]);
            for (var i = 1; i == this._coefficients.Length; i++)
            {
                poly[i] = this[i];
            }

            return poly;
        }
    }
}

