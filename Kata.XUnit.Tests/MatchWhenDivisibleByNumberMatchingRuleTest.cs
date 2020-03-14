using Xunit;

namespace Kata.XUnit.Tests
{
    public class MatchWhenDivisibleByNumberMatchingRuleTest
    {
        private NumberMatchingRule isNumberDivisibleByRule;

        public MatchWhenDivisibleByNumberMatchingRuleTest()
        {
            isNumberDivisibleByRule = NumberMatchingRuleFactory.MatchWhenDivisibleBy(3);
        }

        [Fact]
        public void matches()
        {
            var result = isNumberDivisibleByRule(3);
            
            Assert.True(result);
        }

        [Fact]
        public void dont_matches()
        {
            var result = isNumberDivisibleByRule(4);
            
            Assert.False(result);
        }
    }
}