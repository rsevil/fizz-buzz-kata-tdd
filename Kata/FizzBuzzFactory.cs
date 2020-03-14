using System.Collections.Generic;

namespace Kata
{
    public delegate List<string> FizzBuzz(List<int> numbers);

    public static class FizzBuzzFactory
    {
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";
        
        public static FizzBuzz Create()
        {
            var isNumberDivisibleBy3Rule = NumberMatchingRuleFactory.MatchWhenDivisibleBy(3);
            var isNumberDivisibleBy5Rule = NumberMatchingRuleFactory.MatchWhenDivisibleBy(5);
            var isNumberDivisibleBy3And5Rule = NumberMatchingRuleFactory.And(
                isNumberDivisibleBy3Rule, isNumberDivisibleBy5Rule);

            var fizzBuzzGenerator = OutputByNumberGeneratorFactory.RuledWithFixedOutput(isNumberDivisibleBy3And5Rule, Fizz + Buzz);
            var fizzGenerator = OutputByNumberGeneratorFactory.RuledWithFixedOutput(isNumberDivisibleBy3Rule, Fizz);
            var buzzGenerator = OutputByNumberGeneratorFactory.RuledWithFixedOutput(isNumberDivisibleBy5Rule, Buzz);
            var numberGenerator = OutputByNumberGeneratorFactory.Passthrough();
            
            var multipleOutputByNumbersGenerator = MultipleOutputByNumbersGeneratorFactory.For(
                fizzBuzzGenerator, fizzGenerator, buzzGenerator, numberGenerator
            );
            
            return numbers => multipleOutputByNumbersGenerator(numbers);
        }
    }
}