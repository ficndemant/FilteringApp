using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
//using System.Threading.Channels;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading;


namespace Polynomials.Core
{ 
    public class Polynomial:IEquatable<Polynomial>
    {
        private readonly float[] _coefficientsAndDegrees;
            //private float[] _reversedFloats;

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

            //Polynomial personObj = Object as Polynomial;
            //if (personObj == null)
            //{
            //    return false;
            //}
            //else
            //{
            //    return Equals(personObj);
            //}

            if ( this._coefficientsAndDegrees== other._coefficientsAndDegrees)
            {
                return true;
            };
            return false;
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

        //bool IEquatable<Polynomial>.Equals(Polynomial other)
        //{
        //    if (Equals(first, second))
        //    {
        //        return true;
        //    }

        //    return false;
        //}


        // This is here just to have ability to change polynom afer we already got it
        // For now just a basic bullshit code
        //public float[] CoefficientsAndDegrees
        //{
        //    //get { return _coefficientsAndDegrees; }  this is not neccessary
        //    set
        //    {
        //        for (int i = 0; i < value.Length; i++)
        //        {
        //            if (value[i] == 0.0F)
        //            {
        //                //Do something
        //                _coefficientsAndDegrees[i] = value[i];
        //            }
        //        }
        //        // _coefficientsAndDegrees = value;

        //    }
        //}

        // reverse polynomial array
        //public void ReversePolynomial()
        //{
        //    var reversed = new float[_coefficientsAndDegrees.Length];
        //    var count = _coefficientsAndDegrees.Length;
        //    for (int i = 0; i < _coefficientsAndDegrees.Length; i++)
        //    {
        //        reversed[i] = _coefficientsAndDegrees[count - 1];
        //            count--;
        //    }
        //    _reversedFloats = reversed;
        //}


        // will work now on printing the polynomial to screen in a user friendly form
        //public void Print()
        //{
        //    var count = _coefficientsAndDegrees.Length;
        //    Console.WriteLine("MyPoly polynomial looks like this for now: ");
        //    for (var i = 0; i < _coefficientsAndDegrees.Length; i++)
        //    {
        //        Console.Write($"{_coefficientsAndDegrees[count-1]}x^{count-1} ");
        //        count--;
        //    }

        //}


    }
}
