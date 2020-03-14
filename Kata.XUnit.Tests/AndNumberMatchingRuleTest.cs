using NSubstitute;
using Xunit;

namespace Kata.XUnit.Tests
{
    public class AndNumberMatchingRuleTest
    {
        private NumberMatchingRule left;
        private NumberMatchingRule right;
        private NumberMatchingRule andNumberMatchingRule;

        public AndNumberMatchingRuleTest()
        {
            left = Substitute.For<NumberMatchingRule>();
            right = Substitute.For<NumberMatchingRule>();
            
            andNumberMatchingRule = AndNumberMatchingRule.And(left, right);
        }

        [Fact]
        public void matches()
        {
            left(Arg.Any<int>()).Returns(true);
            right(Arg.Any<int>()).Returns(true);

            var matches = andNumberMatchingRule(1);
            
            Assert.True(matches);
        }

        [Fact]
        public void dont_matches_by_left()
        {
            left(Arg.Any<int>()).Returns(false);
            right(Arg.Any<int>()).Returns(true);

            var matches = andNumberMatchingRule(1);
            
            Assert.False(matches);
        }
        
        [Fact]
        public void dont_matches_by_right()
        {
            left(Arg.Any<int>()).Returns(true);
            right(Arg.Any<int>()).Returns(false);

            var matches = andNumberMatchingRule(1);
            
            Assert.False(matches);
        }
    }
}