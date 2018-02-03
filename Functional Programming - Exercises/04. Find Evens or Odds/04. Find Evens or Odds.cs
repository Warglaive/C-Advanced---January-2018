using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }
                , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var evenOrOdd = Console.ReadLine().ToLower();
            var min = input[0];
            var max = input[1];
            Predicate<int> isOdd = n => n % 2 == 1 || n % 2 == -1;
            Predicate<int> isEven = n => n % 2 == 0;
            var result = new List<int>();
            if (evenOrOdd == "odd")
            {
                for (int i = min; i <= max; i++)
                {
                    if (isOdd(i))
                    {
                        result.Add(i);
                    }
                }
                Console.WriteLine(string.Join(" ", result));
            }
            else if (evenOrOdd == "even")
            {
                for (int i = min; i <= max; i++)
                {
                    if (isEven(i))
                    {
                        result.Add(i);
                    }
                }
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
