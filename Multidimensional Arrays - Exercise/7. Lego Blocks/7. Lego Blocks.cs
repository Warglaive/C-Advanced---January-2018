using System;
using System.Linq;

namespace _7._Lego_Blocks
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var firstArray = new int[n][];
            var secondArray = new int[n][];

            for (int row = 0; row < n * 2; row++)
            {
                var firstArrayLines = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < firstArrayLines.Length - 1; col++)
                {
                    firstArray[row][col] = firstArrayLines[col];
                }
            }
        }
    }
}