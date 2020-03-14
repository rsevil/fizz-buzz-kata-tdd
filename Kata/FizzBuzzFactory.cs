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
            var isNumberDivisibleBy3Rule = IsNumberDivisibleByRuleFn.Where(3);
            var isNumberDivisibleBy5Rule = IsNumberDivisibleByRuleFn.Where(5);
            var isNumberDivisibleBy3And5Rule = AndNumberMatchingRule.And(
                isNumberDivisibleBy3Rule, isNumberDivisibleBy5Rule);

            var fizzBuzzGenerator = OutputByRuleGenerator.For(isNumberDivisibleBy3And5Rule, Fizz + Buzz);
            
            var fizzGenerator = OutputByRuleGenerator.For(isNumberDivisibleBy3Rule, Fizz);
            var buzzGenerator = OutputByRuleGenerator.For(isNumberDivisibleBy5Rule, Buzz);
            var numberGenerator = DirectOutputGenerator.For();
            
            var multipleOutputByNumbersGenerator = MultipleOutputByNumbersGenerator.For(
                fizzBuzzGenerator, fizzGenerator, buzzGenerator, numberGenerator
            );
            
            return numbers => multipleOutputByNumbersGenerator(numbers);
        }
    }
}