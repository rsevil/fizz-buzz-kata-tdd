namespace Kata
{
    public class OutputByRuleGenerator : OutputByNumberGenerator
    {
        private readonly NumberMatchingRule rule;
        private readonly string output;

        public OutputByRuleGenerator(NumberMatchingRule rule, string output)
        {
            this.rule = rule;
            this.output = output;
        }

        public string GetOutputByNumber(int number)
        {
            return When(rule.Matches(number), output);
        }

        private static string When(bool matches, string output)
        {
            return matches ? output : default(string);
        }
    }
}