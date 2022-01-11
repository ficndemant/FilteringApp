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
            const float tolerance = 0.000001F;
            return Math.Abs(left - right) < tolerance;
        }

        public static Polynomial operator +(Polynomial? left, Polynomial? right)
        {
            if (left is null && !(right is null))
            {
                Polynomial polynomial = (Polynomial)right.Clone();
                return polynomial;
            }

            if (!(left is null) && right is null)
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
                var polyL = (Polynomial) left.Clone();

                if (left._coefficients.Length > right._coefficients.Length)
                {
                    for (var i = 0; i < right._coefficients.Length; i++)
                    {
                        polyL[i] = left[i] - right[i];
                    }

                    return (Polynomial)polyL;
                }

                ////var size = Math.Max(left._coefficients.Length, right._coefficients.Length);
                ////var polynomial = new Polynomial(new float[size]);

                ////var polyR = (Polynomial)right.Clone();
                //var lastPol = new Polynomial(new float[right._coefficients.Length]);
                //for(var i=0; i < right._coefficients.Length; i++)
                //{
                //    lastPol[i] = 0;
                //}

                //if (left._coefficients.Length < right._coefficients.Length)
                //{
                //    for (var i = 0; i < right._coefficients.Length; i++)
                //    {
                //        lastPol[i] = -1 * left[i] + right[i];
                //        //lastPol[i] = left[i] - right[i];
                //        //polyR[i] = -1 * right[i] + left[i];
                //    }

                //    return (Polynomial)lastPol;
                //}
            }

            Polynomial poly2 = (Polynomial)left.Clone();
            if (left._coefficients.Length == right._coefficients.Length)
            {
                for (var i = 0; i < left._coefficients.Length; i++)
                {
                    poly2[i] = left[i] - right[i];
                }

                return (Polynomial)poly2;
            }

            throw new Exception("Can't do subtraction");
        }

        public static Polynomial operator *(Polynomial? poly, int number)
        {
            Polynomial copy = (Polynomial)poly.Clone();

            for (var i = 0; i < poly._coefficients.Length; i++)
            {
                copy[i] = poly[i] * number;
            }

            return copy;
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
            if (left is null)
            {
                if (right is null)
                {
                    return false;
                }

                return true;
            }

            return !(left.Equals(right));
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
            for (var i = 0; i < this._coefficients.Length; i++)
            {
                poly[i] = this[i];
            }

            return poly;
        }
    }
}

