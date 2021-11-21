namespace FilteringApp.Core.Models
{
    public class ArrayParseResult
    {
        public ArrayParseResult(int[] array)
        {
            IsValid = true;
            Array = array;
        }

        public ArrayParseResult(string error)
        {
            IsValid = false;
            Error = error;
        }

        public bool IsValid { get; }

        public int[] Array { get; }

        public string Error { get; }
    }
}
