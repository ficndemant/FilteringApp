using System;

namespace CheckUserInput.Core
{
    // delete class, move mothod to ArrayUtils as static method
    public class P2funcs
    {
        public int AddArrayElements(int[] array)
            //why never use array objects btw? It worked :D
        {
            var arrayToAdd = (int[])array; // poczytać o kastingu, usunąć tą linijkę
            var theSum = 0;
            foreach (var item in arrayToAdd)
            {
                theSum += arrayToAdd[item]; // tu jest coś nie tak :d
            }
            return theSum; 
        }
    }
}
