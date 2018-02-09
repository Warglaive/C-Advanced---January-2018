using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Shmoogle_Counter
{
    public class Program
    {
        public static void Main()
        {
            var doublesResult = new List<string>();
            var intResult = new List<string>();
            var integerPattern = @"int [a-z]{1}[a-zA-Z]*";
            var doublePattern = @"double [a-z]{1}[a-zA-Z]*";
            var intRegex = new Regex(integerPattern);
            var regex = new Regex(doublePattern);
            var input = Console.ReadLine();
            while (input != "//END_OF_CODE")
            {
                foreach (Match letter in regex.Matches(input))
                {
                    var splitDouble = letter.Value.Split(' ');
                    doublesResult.Add(splitDouble[1]);
                }
                foreach (Match intVarName in intRegex.Matches(input))
                {
                    var splitInteger = intVarName.Value.Split(' ');
                    intResult.Add(splitInteger[1]);
                }

                input = Console.ReadLine();
            }
            if (doublesResult.Count > 0)
            {
                Console.WriteLine($"Doubles: {string.Join(", ", doublesResult.OrderBy(x => x))}");
            }
            else
            {
                Console.WriteLine("Doubles: None");
            }
            if (intResult.Count > 0)
            {
                Console.WriteLine($"Ints: {string.Join(", ", intResult.OrderBy(x => x))}");
            }
            else
            {

                Console.WriteLine("Ints: None");
            }
        }
    }
}
