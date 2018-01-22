using System;
using System.Collections.Generic;

namespace _04.Matching_Brackets
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var result = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].ToString() == "(")
                {
                    result.Push(i);
                }
                if (input[i].ToString() == ")")
                {
                    var openingBrecket = result.Pop();
                    for (int j = openingBrecket; j <= i; j++)
                    {
                        Console.Write(input[j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
