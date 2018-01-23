using System;
using System.Collections.Generic;

namespace _03.Maximum_Element
{
    public class Program
    {
        public static void Main()
        {
            var stack = new Stack<int>();
            var maxNumStack = new Stack<int>();
            var N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                var queries = Console.ReadLine()
                    .Split(new[] { ' ' }
                    , StringSplitOptions.RemoveEmptyEntries);
                var currentQuery = queries[0];
                switch (currentQuery)
                {
                    case "1":
                        var elementToBePushed = int.Parse(queries[1]);
                        PushElement(elementToBePushed, stack, maxNumStack);
                        break;
                    case "2":
                        DeleteTopElement(stack, maxNumStack);
                        break;
                    case "3":
                        printMaxNum(stack, maxNumStack);
                        break;
                }

            }
        }

        public static void PushElement(int elementToBePushed, Stack<int> stack, Stack<int> maxNumStack)
        {
            stack.Push(elementToBePushed);
            if (maxNumStack.Count == 0 || elementToBePushed > maxNumStack.Peek())
            {
                maxNumStack.Push(elementToBePushed);
            }
        }

        public static void DeleteTopElement(Stack<int> stack, Stack<int> maxNumStack)
        {
            if (stack.Count > 0)
            {
                if (maxNumStack.Count == 0)
                {
                    stack.Pop();
                }
                else if (maxNumStack.Peek() == stack.Pop())
                {
                    maxNumStack.Pop();
                }
            }
        }

        public static void printMaxNum(Stack<int> stack, Stack<int> maxNumStack)
        {
            if (stack.Count > 0)
            {
                Console.WriteLine(maxNumStack.Peek());
            }
        }
    }
}
