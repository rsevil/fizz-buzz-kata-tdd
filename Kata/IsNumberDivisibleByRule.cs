namespace Kata
{
    public class IsNumberDivisibleByRule : NumberMatchingRule
    {
        private readonly int divisor;

        public IsNumberDivisibleByRule(int divisor)
        {
            this.divisor = divisor;
        }

        public bool Matches(int number)
        {
            return number % divisor == 0;
        }
    }
}