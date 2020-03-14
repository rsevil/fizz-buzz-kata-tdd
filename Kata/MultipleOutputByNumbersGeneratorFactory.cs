using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public static class MultipleOutputByNumbersGeneratorFactory 
    {
        public static MultipleOutputByNumbersGenerator For(params OutputByNumberGenerator[] generators) =>
            numbers =>
            {
                if (!numbers.Any())
                    throw new Exception();
                
                return MapToOutput(numbers, generators);
            };

        private static List<string> MapToOutput(List<int> numbers, OutputByNumberGenerator[] generators) 
            => numbers
                .Select(number => GenerateOutputByNumber(number, generators))
                .ToList();

        private static string GenerateOutputByNumber(int number, OutputByNumberGenerator[] generators) 
            => generators
                .Select(generator => generator(number))
                .First(output => !string.IsNullOrEmpty(output));
    }
}