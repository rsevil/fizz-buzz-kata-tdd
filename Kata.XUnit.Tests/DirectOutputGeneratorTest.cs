using Xunit;

namespace Kata.XUnit.Tests
{
    public class DirectOutputGeneratorTest
    {
        private DirectOutputGenerator directOutputGenerator;

        public DirectOutputGeneratorTest()
        {
            directOutputGenerator = new DirectOutputGenerator();
        }

        [Fact]
        public void outputs_input()
        {
            var input = 1;
            
            var output = directOutputGenerator.GenerateOutputByNumber(input);
            
            Assert.Equal(input.ToString(), output);
        }
    }
}