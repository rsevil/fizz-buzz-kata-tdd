namespace Kata
{
    public static class AndNumberMatchingRule
    {
        public static NumberMatchingRule And(NumberMatchingRule left, NumberMatchingRule right)
        {
            return number => left(number) && right(number);
        }
    }
}