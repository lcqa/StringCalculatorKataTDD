using System;
using System.Text;

namespace StringCalculatorLibrary
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            List<int> numbersList = new();
            var sum = 0;
            if(String.IsNullOrEmpty(numbers))
                return 0;
            
            
            numbersList.AddRange(ParseString(numbers));

            if (numbersList.Where(x => x < 0).Any())
                throw new Exception("Negatives not allowed");

            numbersList = numbersList.Where(x => x < 1000).ToList();


            return numbersList.Sum();
        }

        private List<int> ParseString(string numbers)
        {
            var delimiters = new List<string>() { ",", "\n" };

            if (numbers.StartsWith("//"))
            {
                var substringIndex = ParseDelimiters(numbers, delimiters);
                numbers = numbers.Substring(substringIndex);

            }
            return numbers.Split(delimiters.ToArray(),StringSplitOptions.None).Select(x => int.Parse(x)).ToList();
        }

        /// <summary>
        /// Process the delimiters and returns the index for the numbers substring
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="delimiters"></param>
        /// <returns></returns>
        private int ParseDelimiters(string numbers,List<string> delimiters)
        {
            var substringIndex = 0;
            if (numbers[2] == '[')
            {
                substringIndex = ParseSpecialDelimiters(numbers, delimiters);
                return substringIndex;

            }

            delimiters.Add(numbers[2].ToString());
            substringIndex = 4;


            return substringIndex;

        }

        private int ParseSpecialDelimiters(string numbers,List<string> delimiters)
        {
            var substringIndex = 0;
            var delimiterBuilder = new StringBuilder();
            for (int i = 2; i < numbers.Length; i++)
            {
                if (numbers[i] == '\n')
                {
                    substringIndex = i + 1;
                    break;
                }
                if (numbers[i] == ']' || numbers[i] == '[')
                {
                    if (numbers[i] == ']')
                    {
                        delimiters.Add(delimiterBuilder.ToString());
                        delimiterBuilder = new StringBuilder();
                    }
                    continue;

                }
                delimiterBuilder.Append(numbers[i]);
            }

            return substringIndex;
        }

    }
}