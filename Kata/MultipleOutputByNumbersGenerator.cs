using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer.Server;

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