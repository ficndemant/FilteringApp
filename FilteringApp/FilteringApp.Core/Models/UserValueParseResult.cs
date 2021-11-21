namespace FilteringApp.Core.Models
{
    public class UserValueParseResult
    {
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
