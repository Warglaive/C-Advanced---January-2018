using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Reverse_Numbers
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions
                    .RemoveEmptyEntries)
                .ToList();
            var stack = new Stack<int>();
            for (int i = 0; i <= input.Count - 1; i++)
            {
                stack.Push(int.Parse(input[i]));
            }
            for (int i = 0; i <= input.Count - 1; i++)
            {
                Console.Write(stack.Pop() + " ");
            }
            Console.WriteLine();
        }
    }
}