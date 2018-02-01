using System;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    public class Program
    {
        public static void Main()
        {
            var number = Console.ReadLine()
                .Split(',')
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(a => a)
                .ToList();
            Console.WriteLine(string.Join(", ", number));
        }
    }
}
