using Xunit;

namespace Kata.XUnit.Tests
{
    public class DirectOutputGeneratorTest
    {
        private OutputByNumberGenerator directOutputGenerator;

        public DirectOutputGeneratorTest()
        {
            directOutputGenerator = DirectOutputGenerator.For();
        }

        [Fact]
        public void outputs_input()
        {
            var input = 1;
            
            var output = directOutputGenerator(input);
            
            Assert.Equal(input.ToString(), output);
        }
    }
}