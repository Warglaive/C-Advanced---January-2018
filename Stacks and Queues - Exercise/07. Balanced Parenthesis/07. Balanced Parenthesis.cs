using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Balanced_Parenthesis
{
    public class Program
    {
        public static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();
            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }
            char[] opening = { '(', '[', '{' };
            char[] closing = { ')', ']', '}' };
            var stack = new Stack<char>();

            foreach (var element in input)
            {
                if (opening.Contains(element))
                {
                    stack.Push(element);
                }
                else if (closing.Contains(element))
                {
                    var lastOpeningElement = stack.Pop();

                    var openingIndex = Array.IndexOf(opening, lastOpeningElement);
                    var closingIndex = Array.IndexOf(closing, element);
                    if (openingIndex != closingIndex)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            if (stack.Any())
            {
                Console.WriteLine("NO");
                return;
            }
            Console.WriteLine("YES");
        }
    }
}
