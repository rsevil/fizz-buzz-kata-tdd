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
            return MapNumbersToOutput(numbers);
        }

        private static void EnsureThatNumbersIsNotEmpty(List<int> numbers)
        {
            if (!numbers.Any())
                throw new Exception("No me pases lista vacia");
        }

        private List<string> MapNumbersToOutput(List<int> numbers)
        {
            return numbers
                .Select(GetOutputByNumber)
                .ToList();
        }

        private string GetOutputByNumber(int number)
        {
            string outputByNumber = null;
            
            if (IsDivisibleBy3And5(number))
                outputByNumber = Fizz_Buzz;
            
            if (outputByNumber == null && IsDivisibleBy3(number))
                outputByNumber = Fizz;
            
            if (outputByNumber == null && IsDivisibleBy5(number))
                outputByNumber = Buzz;
            
            if (outputByNumber == null)
                outputByNumber = number.ToString();
            
            return outputByNumber;
        }

        private bool IsDivisibleBy3And5(int number)
        {
            return IsDivisibleBy3(number) && IsDivisibleBy5(number);
        }

        private bool IsDivisibleBy5(int number)
        {
            return IsDivisibleBy(5, number);
        }

        private bool IsDivisibleBy3(int number)
        {
            return IsDivisibleBy(3, number);
        }

        private static bool IsDivisibleBy(int divisor, int number)
        {
            return number % divisor == 0;
        }
    }
}