using System;
using System.Collections.Generic;
using System.Text;

namespace FilteringApp.Core.Models
{
    public class UserValueParseResult
    {
        //public UserValueParseResult(bool isValid, int value, string error)
        //{
        //    IsValid = isValid;
        //    Value = value;
        //    Error = error;
        //}

        public UserValueParseResult(int value)
        {
            IsValid = true;
            Value = value;
        }

        public UserValueParseResult(string error)
        {
            IsValid = false;
            Error = error;
        }


        public bool IsValid { get; }

        public int Value { get; }

        public string Error { get; }
    }
}
