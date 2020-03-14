using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Kata.XUnit.Tests
{
    public class FizzBuzzTest
    {
        private FizzBuzz fizzBuzz;
        private OutputByNumberGenerator outputGenerator;

        public FizzBuzzTest()
        {
            outputGenerator = Substitute.For<OutputByNumberGenerator>();
            outputGenerator.GetOutputByNumber(Arg.Any<int>()).ReturnsNull();
            
            fizzBuzz = new FizzBuzz(outputGenerator);
        }

        [Fact]
        public void throws_errors()
        {
            var numbers = new List<int>();

            Action action = () => fizzBuzz.Execute(numbers);

            Assert.Throws<Exception>(action);
        }

        [Fact]
        public void prints_by_output_generator()
        {
            var numbers = new List<int> { 1 };
            outputGenerator.GetOutputByNumber(1).Returns("CustomOutput");
            
            var output = fizzBuzz.Execute(numbers);
            
            Assert.Equal("CustomOutput", output.First());    
        }

        [Fact]
        public void prints_fizz()
        {
            var numbers = new List<int> { 3 };
            
            var output = fizzBuzz.Execute(numbers);
            
            Assert.Equal("Fizz", output.First()); 
        }
        
        [Fact]
        public void prints_buzz()
        {
            var numbers = new List<int> { 5 };
            
            var output = fizzBuzz.Execute(numbers);
            
            Assert.Equal("Buzz", output.First()); 
        }
        
        [Fact]
        public void prints_number()
        {
            var numbers = new List<int> { 4 };
            
            var output = fizzBuzz.Execute(numbers);
            
            Assert.Equal("4", output.First()); 
        }
        
        
        [Fact]
        public void prints_fizzbuzz()
        {
            var numbers = new List<int> { 15 };
            
            var output = fizzBuzz.Execute(numbers);
            
            Assert.Equal("FizzBuzz", output.First()); 
        }
        
        [Fact]
        public void prints_fizz_buzz_number()
        {
            var numbers = new List<int> { 6, 10, 4 };
            
            var output = fizzBuzz.Execute(numbers);
            
            Assert.Equal("Fizz", output[0]);
            Assert.Equal("Buzz", output[1]);
            Assert.Equal("4", output[2]);
        }
    }
}