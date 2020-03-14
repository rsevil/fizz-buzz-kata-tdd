namespace Kata
{
    public static class OutputByRuleGenerator
    {
        public static OutputByNumberGenerator For(NumberMatchingRule rule, string output)
        {
            return number => rule(number) ? output : default(string);
        }
    }
}