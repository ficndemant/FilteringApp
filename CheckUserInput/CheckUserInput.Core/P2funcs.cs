using System;

namespace CheckUserInput.Core
{
    public class P2funcs
    {
        public int AddArrayElements(Array array)
        {
            int[] arrayToAdd = (int[])array;
            var len = arrayToAdd.Length;
            var theSum = 0;
            for(int i = 0; i < len; i++)
            {
                 theSum = theSum + arrayToAdd[i];
            }
            return theSum; 
        }
    }
}
