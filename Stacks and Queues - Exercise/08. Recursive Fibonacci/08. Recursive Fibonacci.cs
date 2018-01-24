using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Recursive_Fibonacci
{
    public class Program
    {
        public static void Main()
        {
            long input = long.Parse(Console.ReadLine());
            var currentFibonacci = GetFibuonacci(input);
            Console.WriteLine(currentFibonacci);
        }

        private static long GetFibuonacci(long input)
        {
            long a = 0;
            long b = 1;
            for (int i = 0; i < input; i++)
            {
                long temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }
}
