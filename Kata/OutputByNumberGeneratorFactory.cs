namespace Kata
{
    public static class OutputByNumberGeneratorFactory
    {
        public static OutputByNumberGenerator RuledWithFixedOutput(NumberMatchingRule rule, string output) 
            => number => rule(number) ? output : default(string);

        public static OutputByNumberGenerator Passthrough() 
            => number => number.ToString();
    }
}