﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Basic_Stack_Operations
{
    public class Program
    {
        public static void Main()
        {
            var NSX = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var N = NSX[0];
            var S = NSX[1];
            var X = NSX[2];
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var stack = new Stack<int>();
            for (int i = 0; i < N; i++) // push to stack
            {
                stack.Push(numbers[i]);
            }
            for (int i = 0; i < S; i++) //pop from stack
            {
                stack.Pop();
            }
            if (stack.Count < 1)
            {
                Console.WriteLine(0);
                return;
            }
            foreach (var element in stack)
            {
                if (element.Equals(X))
                {
                    Console.WriteLine("true");
                    return;
                }
            }
            Console.WriteLine(stack.Min());
        }
    }
}
