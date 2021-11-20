using System;
using System.Collections.Generic;
using System.Text;

namespace FilteringApp.Core.Models
{
    public class ArrayParseResult
    {
        public ArrayParseResult(bool isValid, int[] array, string error)
        {
            IsValid = isValid;
            Array = array;
            Error = error;
        }

        public bool IsValid { get; set; }

        public int[] Array { get; }

        public string Error { get; set; }
    }
}
