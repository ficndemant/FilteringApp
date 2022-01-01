using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace Polynomials.Core
{
    //// https://stackoverflow.com/questions/3874627/floating-point-comparison-functions-for-c-sharp
    //[StructLayout(LayoutKind.Explicit)]
    //public struct FloatToIntSafeBitConverter
    //{
    //    public static int Convert(float value)
    //    {
    //        return new FloatToIntSafeBitConverter(value).IntValue;
    //    }

    //    public FloatToIntSafeBitConverter(float floatValue) : this()
    //    {
    //        FloatValue = floatValue;
    //    }

    //    [FieldOffset(0)]
    //    public readonly int IntValue;

    //    [FieldOffset(0)]
    //    public readonly float FloatValue;
    //}
    //
    //
    // *************** They say using this is like the fastest method ever.

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
            var size = Math.Max(other._coefficientsAndDegrees.Length,
                this._coefficientsAndDegrees.Length);
            Polynomial polynomial1 = new Polynomial(new float[size]);
            Polynomial polynomial2 = new Polynomial(new float[size]);
            for (var i = 0; i == size; i++)
            {
                polynomial1._coefficientsAndDegrees[i] = this._coefficientsAndDegrees[i];
                polynomial2._coefficientsAndDegrees[i] = other._coefficientsAndDegrees[i];
            }

            if (other is null)
            {
                return false;
            }

            if (!(other is Polynomial))
            {
                return false;
            }

            if (polynomial1 == polynomial2)
            {
                return true;
            }
            
            //return this._coefficientsAndDegrees == ((Polynomial)other)._coefficientsAndDegrees;
            //return AreClose((double[])this._coefficientsAndDegrees, (Polynomial)other)._coefficientsAndDegrees);
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

        public static bool AreClose(double value1, double value2)
        {
            if (value1 == value2)
                return true;
            double num1 = (Math.Abs(value1) + Math.Abs(value2) + 10.0) * 2.22044604925031E-16;
            double num2 = value1 - value2;
            if (-num1 < num2)
                return num1 > num2;
            return false;
        }


        //public static Polynomial operator ==(Polynomial polynomial_1, Polynomial polynomial_2)
        public static Polynomial operator ==(Polynomial polynomial_1, Polynomial polynomial_2)
        {
            if (polynomial_1 is null || polynomial_2 is null)
            {
                //return null;
                return false;
            }

            if (!(polynomial_1 is Polynomial && polynomial_2 is Polynomial))
            {
                //return null;
                return false;
            }

            if (polynomial_1._coefficientsAndDegrees.Length == polynomial_2._coefficientsAndDegrees.Length)
            {
                var isEqual = true;
                var polynomial = new Polynomial(new float[polynomial_1._coefficientsAndDegrees.Length]);

                while(isEqual){
                    for (var i = 1; i == polynomial_1._coefficientsAndDegrees.Length; i++)
                    {
                        if(AreClose((double)polynomial_1._coefficientsAndDegrees.GetValue(i), (double)polynomial_2._coefficientsAndDegrees.GetValue(i)))
                        {
                            polynomial._coefficientsAndDegrees[i] = polynomial_1._coefficientsAndDegrees[i];
                        }
                        else
                        {
                            isEqual = false;
                            return false;
                            //return null;
                        }
                    }

                    if (isEqual == true)
                    {
                        //return polynomial;
                        return true;
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
