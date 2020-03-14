using NSubstitute;
using Xunit;

namespace Kata.XUnit.Tests
{
    public class OutputByRuleGeneratorTest
    {
        private OutputByNumberGenerator outputByRuleGenerator;
        private NumberMatchingRule rule;

        public OutputByRuleGeneratorTest()
        {
            rule = Substitute.For<NumberMatchingRule>();
            outputByRuleGenerator = OutputByRuleGenerator.For(rule, "Output");
        }

        [Fact]
        public void output_text_when_rule_matches()
        {
            rule(Arg.Any<int>()).Returns(true);

            var output = outputByRuleGenerator(1);
            
            Assert.Equal("Output", output);
        }
        
        [Fact]
        public void output_null_when_rule_dont_matches()
        {
            rule(Arg.Any<int>()).Returns(false);

            var output = outputByRuleGenerator(1);
            
            Assert.Null(output);
        } 
    }
}