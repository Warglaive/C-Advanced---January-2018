using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Custom_Min_Function
{
    public class Program
    {
        public static void Main()
        {
            var setOfIntegers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> func = n => n.Min();

            Console.WriteLine(func(setOfIntegers));
        }
    }
}
