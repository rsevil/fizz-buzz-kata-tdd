using System.Collections.Generic;

namespace Kata
{
    public delegate List<string> FizzBuzz(List<int> numbers);
    
    public class FizzBuzzFactory
    {
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";
        
        public FizzBuzz Create()
        {
            var isNumberDivisibleBy3Rule = new IsNumberDivisibleByRule(3);
            var isNumberDivisibleBy5Rule = new IsNumberDivisibleByRule(5);
            var isNumberDivisibleBy3And5Rule = new AndNumberMatchingRule(
                isNumberDivisibleBy3Rule, isNumberDivisibleBy5Rule);

            var fizzBuzzGenerator = new OutputByRuleGenerator(isNumberDivisibleBy3And5Rule, Fizz + Buzz);
            
            var fizzGenerator = new OutputByRuleGenerator(isNumberDivisibleBy3Rule, Fizz);
            var buzzGenerator = new OutputByRuleGenerator(isNumberDivisibleBy5Rule, Buzz);
            var numberGenerator = new DirectOutputGenerator();
            
            var multipleOutputByNumbersGenerator = new MultipleOutputByNumbersGenerator(
                fizzBuzzGenerator, fizzGenerator, buzzGenerator, numberGenerator
            );
            
            return multipleOutputByNumbersGenerator.GenerateOutput;
        }
    }
}