namespace FilteringApp.Core.Models
{
    public class UserInput
    {
        public UserInput(int[] userArray, int intValue)
        {
            UserArray = userArray;
            IntValue = intValue;
        }

        public int[] UserArray { get; }

        public int IntValue { get; }
    }
}
