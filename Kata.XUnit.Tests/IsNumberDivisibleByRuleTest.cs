using Xunit;

namespace Kata.XUnit.Tests
{
    public class IsNumberDivisibleByRuleTest
    {
        private IsNumberDivisibleByRule isNumberDivisibleByRule;

        public IsNumberDivisibleByRuleTest()
        {
            isNumberDivisibleByRule = new IsNumberDivisibleByRule(3);
        }

        [Fact]
        public void matches()
        {
            var result = isNumberDivisibleByRule.Matches(3);
            
            Assert.True(result);
        }

        [Fact]
        public void dont_matches()
        {
            var result = isNumberDivisibleByRule.Matches(4);
            
            Assert.False(result);
        }
    }
}