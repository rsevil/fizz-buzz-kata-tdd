namespace Kata
{
    public static class NumberMatchingRuleFactory
    {
        public static NumberMatchingRule MatchWhenDivisibleBy(int divisor)
        {
            return number => number % divisor == 0;
        }
        
        public static NumberMatchingRule And(NumberMatchingRule left, NumberMatchingRule right)
        {
            return number => left(number) && right(number);
        }
    }
}