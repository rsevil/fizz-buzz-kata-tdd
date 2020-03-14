using System.Collections.Generic;

namespace Kata
{
    public delegate List<string> FizzBuzz(List<int> numbers);

    public static class FizzBuzzFactory
    {
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";
        
        public static FizzBuzz Create() 
            => numbers => MultipleOutputByNumbersGenerator()(numbers);

        private static MultipleOutputByNumbersGenerator MultipleOutputByNumbersGenerator() 
            => MultipleOutputByNumbersGeneratorFactory.For(
                FizzBuzzGenerator(), FizzGenerator(), BuzzGenerator(), NumberGenerator());

        private static OutputByNumberGenerator FizzBuzzGenerator() 
            => OutputByNumberGeneratorFactory
                .RuledWithFixedOutput(IsNumberDivisibleBy3And5Rule(), Fizz + Buzz);

        private static OutputByNumberGenerator FizzGenerator() 
            => OutputByNumberGeneratorFactory
                .RuledWithFixedOutput(IsNumberDivisibleBy3Rule(), Fizz);

        private static OutputByNumberGenerator BuzzGenerator() 
            => OutputByNumberGeneratorFactory
                .RuledWithFixedOutput(IsNumberDivisibleBy5Rule(), Buzz);

        private static OutputByNumberGenerator NumberGenerator() 
            => OutputByNumberGeneratorFactory.Passthrough();

        private static NumberMatchingRule IsNumberDivisibleBy3And5Rule() 
            => IsNumberDivisibleBy3Rule().And(IsNumberDivisibleBy5Rule());

        private static NumberMatchingRule IsNumberDivisibleBy3Rule() 
            => NumberMatchingRuleFactory.MatchWhenDivisibleBy(3);

        private static NumberMatchingRule IsNumberDivisibleBy5Rule() 
            => NumberMatchingRuleFactory.MatchWhenDivisibleBy(5);
    }
}