using NSubstitute;
using Xunit;

namespace Kata.XUnit.Tests
{
    public class OutputByRuleGeneratorTest
    {
        private OutputByNumberGenerator outputByNumberGenerator;
        private NumberMatchingRule numberMatchingRule;

        public OutputByRuleGeneratorTest()
        {
            numberMatchingRule = Substitute.For<NumberMatchingRule>();
            outputByNumberGenerator = OutputByNumberGeneratorFactory
                .RuledWithFixedOutput(numberMatchingRule, "Output");
        }

        [Fact]
        public void output_text_when_rule_matches()
        {
            numberMatchingRule(Arg.Any<int>()).Returns(true);

            var output = outputByNumberGenerator(1);
            
            Assert.Equal("Output", output);
        }
        
        [Fact]
        public void output_null_when_rule_dont_matches()
        {
            numberMatchingRule(Arg.Any<int>()).Returns(false);

            var output = outputByNumberGenerator(1);
            
            Assert.Null(output);
        } 
    }
}