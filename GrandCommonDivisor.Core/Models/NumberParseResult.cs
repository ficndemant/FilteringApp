namespace GrandCommonDivisor.Core.models
{
    public class NumberParseResult
    {
        public NumberParseResult(int number)
        {
            IsValid = true;
            Number = number;
        }

        public NumberParseResult(string error)
        {
            IsValid = false;
            Error = error;
        }

        public bool IsValid { get; }

        public int Number { get; }

        public string Error { get; }
    }
}
