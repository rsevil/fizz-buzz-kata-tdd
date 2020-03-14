namespace Kata
{
    public static class NumberMatchingRuleFactory
    {
        public static NumberMatchingRule MatchWhenDivisibleBy(int divisor) 
            => number => number % divisor == 0;

        public static NumberMatchingRule And(NumberMatchingRule left, NumberMatchingRule right) 
            => number => left(number) && right(number);
    }

    public static class NumberMatchingRuleExtensions
    {
        public static NumberMatchingRule And(this NumberMatchingRule left, NumberMatchingRule right) 
            => NumberMatchingRuleFactory.And(left, right);
    }
}