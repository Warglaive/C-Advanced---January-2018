using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(',')
                .Select(int.Parse)
                .ToList();
            Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Sum());
        }
    }
}
