using System;
using System.Linq;

namespace _01._Action_Print
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .ToList();
            Action<string> print = name => Console.WriteLine(name);
            foreach (var name in input)
            {
                print(name);
            }
        }
    }
}
