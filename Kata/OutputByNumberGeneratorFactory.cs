namespace Kata
{
    public static class OutputByNumberGeneratorFactory
    {
        public static OutputByNumberGenerator RuledWithFixedOutput(NumberMatchingRule rule, string output)
        {
            return number => rule(number) ? output : default(string);
        }
        
        public static OutputByNumberGenerator Passthrough()
        {
            return number => number.ToString();
        }
    }
}