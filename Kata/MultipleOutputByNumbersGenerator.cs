using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public delegate List<string> MultipleOutputByNumbersGeneratorFn(List<int> numbers);
    
    public static class MultipleOutputByNumbersGenerator 
    {
        public static MultipleOutputByNumbersGeneratorFn For(params OutputByNumberGenerator[] generators)
        {
            return numbers =>
            {
                if (!numbers.Any())
                    throw new Exception();
                
                return MapToOutput(numbers, generators);
            };
        }
        
        private static List<string> MapToOutput(List<int> numbers, OutputByNumberGenerator[] generators)
        {
            return numbers
                .Select(number => GenerateOutputByNumber(number, generators))
                .ToList();
        }

        private static string GenerateOutputByNumber(int number, OutputByNumberGenerator[] generators)
        {
            return generators
                .Select(generator => generator(number))
                .First(output => !string.IsNullOrEmpty(output));
        }
    }
}