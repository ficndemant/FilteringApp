using System;
using Polynomials.Core;
//using System;
//using System.Runtime.InteropServices;


namespace Polynomials.core
{
    class Program
    {

        static void Main(string[] args)
        {
            var myPolynomial = new Polynomial(new float[]{1.2F, 0.0F, -2.3F, 0.0F, 2.1F});
            var myPolynomial2 = new Polynomial(new float[] { 1.2F, 0.0F, -2.3F, 0.0F, 2.1F });
            Console.WriteLine(myPolynomial.ToString());
            Console.WriteLine(myPolynomial2.ToString());
            Console.Write(myPolynomial.Equals(myPolynomial2));
            
            //myPolynomial.ReversePolynomial();
            //myPolynomial.PrintReversed();

            //Here just an attempt to change polynomial when need arises,  
            //myPolynomial.CoefficientsAndDegrees = new float[] {1.2F, 1.2F};


        }
    }
}
