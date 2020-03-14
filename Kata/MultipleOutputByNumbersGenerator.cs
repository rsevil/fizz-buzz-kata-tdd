using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class MultipleOutputByNumbersGenerator
    {
        private readonly OutputByNumberGenerator[] generators;

        public MultipleOutputByNumbersGenerator(params OutputByNumberGenerator[] generators)
        {
            this.generators = generators;
        }

        public List<string> GenerateOutput(List<int> numbers)
        {
            EnsureInputIsNotEmpty(numbers);
            return MapToOutput(numbers);
        }

        private static void EnsureInputIsNotEmpty(List<int> numbers)
        {
            if (!numbers.Any())
                throw new Exception();
        }

        private List<string> MapToOutput(List<int> numbers)
        {
            return numbers
                .Select(GenerateOutputByNumber)
                .ToList();
        }

        private string GenerateOutputByNumber(int number)
        {
            return generators
                .Select(generator => generator.GenerateOutputByNumber(number))
                .First(output => !string.IsNullOrEmpty(output));
        }
    }
}