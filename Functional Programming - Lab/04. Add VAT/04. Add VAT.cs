using System;
using System.Linq;

namespace _04._Add_VAT
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(',')
                .Select(double.Parse)
                .Select(x => x)
                .ToList();
            foreach (var num in input)
            {
                Console.WriteLine("{0:f2}", num + (num * 0.20));
            }
        }
    }
}
