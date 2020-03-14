using Xunit;

namespace Kata.XUnit.Tests
{
    public class PassthroughOutputByNumberGeneratorTest
    {
        private OutputByNumberGenerator directOutputGenerator;

        public PassthroughOutputByNumberGeneratorTest()
        {
            directOutputGenerator = OutputByNumberGeneratorFactory.Passthrough();
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