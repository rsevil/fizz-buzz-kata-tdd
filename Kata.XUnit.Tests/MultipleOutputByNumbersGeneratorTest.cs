using System;
using System.Collections.Generic;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Kata.XUnit.Tests
{
    public class MultipleOutputByNumbersGeneratorTest
    {
        private MultipleOutputByNumbersGenerator multipleOutputByNumbersGenerator;

        public MultipleOutputByNumbersGeneratorTest()
        {
            var generator = GetOutputByNumberGenerator(1);
            var generator2 = GetOutputByNumberGenerator(2);
            var generator3 = GetOutputByNumberGenerator(3);
            
            multipleOutputByNumbersGenerator = new MultipleOutputByNumbersGenerator(
                generator, generator2, generator3);
        }

        [Fact]
        public void composes_outputs()
        {
            var numbers = new List<int> {1, 2, 3};

            var result = multipleOutputByNumbersGenerator.GenerateOutput(numbers);
            
            Assert.Equal("1", result[0]);
            Assert.Equal("2", result[1]);
            Assert.Equal("3", result[2]);
        }
        
        [Fact]
        public void throws_error_on_empty_input()
        {
            var numbers = new List<int>();

            Action action = () => multipleOutputByNumbersGenerator.GenerateOutput(numbers);

            Assert.Throws<Exception>(action);
        } 

        private static OutputByNumberGenerator GetOutputByNumberGenerator(int number)
        {
            var outputByNumberGenerator = Substitute.For<OutputByNumberGenerator>();
            outputByNumberGenerator.GenerateOutputByNumber(Arg.Any<int>()).ReturnsNull();
            outputByNumberGenerator.GenerateOutputByNumber(number).Returns(number.ToString());
            return outputByNumberGenerator;
        }
    }
}