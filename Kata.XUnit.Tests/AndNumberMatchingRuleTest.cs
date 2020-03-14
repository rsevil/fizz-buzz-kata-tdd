using NSubstitute;
using Xunit;

namespace Kata.XUnit.Tests
{
    public class AndNumberMatchingRuleTest
    {
        private NumberMatchingRule left;
        private NumberMatchingRule right;
        private AndNumberMatchingRule andNumberMatchingRule;

        public AndNumberMatchingRuleTest()
        {
            left = Substitute.For<NumberMatchingRule>();
            right = Substitute.For<NumberMatchingRule>();
            
            andNumberMatchingRule = new AndNumberMatchingRule(left, right);
        }

        [Fact]
        public void matches()
        {
            left.Matches(Arg.Any<int>()).Returns(true);
            right.Matches(Arg.Any<int>()).Returns(true);

            var matches = andNumberMatchingRule.Matches(1);
            
            Assert.True(matches);
        }

        [Fact]
        public void dont_matches_by_left()
        {
            left.Matches(Arg.Any<int>()).Returns(false);
            right.Matches(Arg.Any<int>()).Returns(true);

            var matches = andNumberMatchingRule.Matches(1);
            
            Assert.False(matches);
        }
        
        [Fact]
        public void dont_matches_by_right()
        {
            left.Matches(Arg.Any<int>()).Returns(true);
            right.Matches(Arg.Any<int>()).Returns(false);

            var matches = andNumberMatchingRule.Matches(1);
            
            Assert.False(matches);
        }
    }
}