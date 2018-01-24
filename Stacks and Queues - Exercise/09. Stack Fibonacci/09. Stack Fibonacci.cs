using System;
using System.Collections.Generic;

namespace Stack_Fibonacci
{
    public class Stack_Fibonacci
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var fibonacci = new Stack<long>();
            fibonacci.Push(1);
            fibonacci.Push(1);
            for (var i = 2; i < n; i++)
            {
                var fibPrev = fibonacci.Pop();
                var fibNext = fibonacci.Peek() + fibPrev;
                fibonacci.Push(fibPrev);
                fibonacci.Push(fibNext);
            }
            Console.WriteLine(fibonacci.Peek());
        }
    }
}