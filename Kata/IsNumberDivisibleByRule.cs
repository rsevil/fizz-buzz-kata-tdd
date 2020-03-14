namespace Kata
{
    public static class IsNumberDivisibleByRuleFn
    {
        public static NumberMatchingRule Where(int divisor)
        {
            return number => number % divisor == 0;
        }
    }
}