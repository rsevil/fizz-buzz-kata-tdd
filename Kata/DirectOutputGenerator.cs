namespace Kata
{
    public static class DirectOutputGenerator
    {
        public static OutputByNumberGenerator For()
        {
            return number => number.ToString();
        }
    }
}