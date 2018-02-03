using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Action<string> appendString = currentstring 
                => Console.WriteLine($"Sir {currentstring}");
            foreach (var name in input)
            {
                appendString(name);
            }
        }
    }
}
