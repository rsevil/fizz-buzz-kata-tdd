namespace Kata
{
    public class AndNumberMatchingRule : NumberMatchingRule
    {
        private readonly NumberMatchingRule left;
        private readonly NumberMatchingRule right;

        public AndNumberMatchingRule(NumberMatchingRule left, NumberMatchingRule right)
        {
            this.left = left;
            this.right = right;
        }


        public bool Matches(int number)
        {
            return left.Matches(number) && right.Matches(number);
        }
    }
}