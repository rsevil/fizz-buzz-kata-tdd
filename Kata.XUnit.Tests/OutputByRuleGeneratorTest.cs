using NSubstitute;
using Xunit;

namespace Kata.XUnit.Tests
{
    public class OutputByRuleGeneratorTest
    {
        private OutputByRuleGenerator outputByRuleGenerator;
        private NumberMatchingRule rule;

        public OutputByRuleGeneratorTest()
        {
            rule = Substitute.For<NumberMatchingRule>();
            outputByRuleGenerator = new OutputByRuleGenerator(rule, "Output");
        }

        [Fact]
        public void output_text_when_rule_matches()
        {
            rule.Matches(Arg.Any<int>()).Returns(true);

            var output = outputByRuleGenerator.GenerateOutputByNumber(1);
            
            Assert.Equal("Output", output);
        }
        
        [Fact]
        public void output_null_when_rule_dont_matches()
        {
            rule.Matches(Arg.Any<int>()).Returns(false);

            var output = outputByRuleGenerator.GenerateOutputByNumber(1);
            
            Assert.Null(output);
        } 
    }
}