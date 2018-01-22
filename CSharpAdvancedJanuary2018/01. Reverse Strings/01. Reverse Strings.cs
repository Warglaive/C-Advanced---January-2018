using System;
using System.Collections.Generic;

namespace _01.Reverse_Strings
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var result = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                result.Push(input[i]);
            }
            foreach (var letter in result)
            {
                Console.Write(letter);
            }
            Console.WriteLine();
        }
    }
}
