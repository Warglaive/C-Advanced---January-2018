using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Simple_Calculator
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var result = new Stack<string>(input.Reverse());
            while (result.Count > 1)
            {
                var firstDigit = int.Parse(result.Pop());
                var operatorX = result.Pop();
                var secondDigit = int.Parse(result.Pop());

                if (operatorX.Equals("+"))
                {
                    result.Push((firstDigit + secondDigit).ToString());
                }
                else
                {
                    result.Push((firstDigit - secondDigit).ToString());
                }
            }
            Console.WriteLine(result.Pop());
        }
    }
}
