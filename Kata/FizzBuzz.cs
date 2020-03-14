using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class FizzBuzz
    {
        const string Fizz = "Fizz";
        const string Buzz = "Buzz";
        const string Fizz_Buzz = "FizzBuzz";

        public List<string> Execute(List<int> numbers)
        {
            EnsureThatNumbersIsNotEmpty(numbers);
            return GenerateOutput(numbers);
        }

        private static void EnsureThatNumbersIsNotEmpty(List<int> numbers)
        {
            if (!numbers.Any())
                throw new Exception("No me pases lista vacia");
        }

        private List<string> GenerateOutput(List<int> numbers)
        {
            var output = new List<string>(); 
            foreach (var number in numbers)
            {
                if (IsDivisibleBy3(number))
                    if (IsDivisibleBy5(number))
                        output.Add(Fizz_Buzz);
                    else
                        output.Add(Fizz);
                else if (IsDivisibleBy5(number))
                    output.Add(Buzz);
                else
                {
                    output.Add(number.ToString());
                }
            }

            return output;
        }

        private bool IsDivisibleBy5(int number)
        {
            return number % 5 == 0;
        }

        private bool IsDivisibleBy3(int number)
        {
            return number % 3 == 0;
        }
    }
}