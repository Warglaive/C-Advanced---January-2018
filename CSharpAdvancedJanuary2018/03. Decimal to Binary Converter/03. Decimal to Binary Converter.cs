using System;
using System.Collections.Generic;

namespace _03.Decimal_to_Binary_Converter
{
    public class Program
    {
        public static void Main()
        {
            var input = int.Parse(Console.ReadLine());
            if (input == 0)
            {
                Console.WriteLine(0);
                return;
            }   
            var result = new Stack<int>();
            while (input > 0)
            {
                var currentNum = input % 2;
                result.Push(currentNum);
                input = input / 2;
            }
            foreach (var digit in result)
            {
                Console.Write(digit);
            }
            Console.WriteLine();
        }
    }
}
