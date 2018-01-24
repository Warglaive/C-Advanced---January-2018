using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.Simple_Text_Editor
{
    public static class Program
    {
        public static void Main()
        {
            var oldVersions = new Stack<string>();
            var text = new StringBuilder();
            var n = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    ?.Split(new[] { ' ' }
                    , StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input != null)
                {
                    var command = input[0];
                    switch (command)
                    {
                        case "1":
                            oldVersions.Push(text.ToString());
                            var argument = input[1];
                            SomeString(argument, text);
                            break;
                        case "2":
                            oldVersions.Push(text.ToString());
                            argument = input[1];
                            EraseCountElements(argument, text);
                            break;
                        case "3":
                            argument = input[1];
                            ReturnCharAtIndex(argument, text);
                            break;
                        case "4":
                            UnDoes(text, oldVersions);
                            break;
                    }
                }
            }
        }

        private static void UnDoes(StringBuilder text, Stack<string> oldVersions)
        {
            text.Clear();
            text.Append(oldVersions.Pop());
        }

        private static void ReturnCharAtIndex(string argument, StringBuilder text)
        {
            var charIndex = int.Parse(argument);
            Console.WriteLine(text[charIndex - 1]);
        }

        private static void EraseCountElements(string argument, StringBuilder text)
        {
            var elementsToBeRemoved = int.Parse(argument);
            text.Remove(text.Length - elementsToBeRemoved, elementsToBeRemoved);
        }

        private static void SomeString(string argument, StringBuilder text)
        {
            text.Append(argument);
        }
    }
}
