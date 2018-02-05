using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01._Regeh
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var pattern = @"[[+]\w+<\d+REGEH\d+>\w+]";
            var numPattern = @"\d+";
            var regex = new Regex(pattern);
            var numRegex = new Regex(numPattern);
            var numbersList = new List<int>();
            var stringResult = string.Empty;
            foreach (Match Match in regex.Matches(input))
            {
                var stringedMatch = Match.ToString();
                for (int charIndex = 0; charIndex < stringedMatch.Length; charIndex++)
                {
                    if (stringedMatch[charIndex].Equals('<'))
                    {
                        // take index
                        foreach (Match digits in numRegex.Matches(stringedMatch))
                        {
                            numbersList.Add(int.Parse(digits.Value));
                            if (numbersList.Sum() > input.Length)
                            {
                                var goAtStart = numbersList.Sum() - input.Length;
                                stringResult += input[goAtStart].ToString();
                            }
                            else
                            {
                                stringResult += input[numbersList.Sum()].ToString();
                            }
                        }
                        charIndex++;
                    }
                }
            }
            Console.WriteLine(stringResult);
        }
    }
}
