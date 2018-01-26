using System;
using System.Linq;

namespace _01._Matrix_of_Palindromes
{
    class Program
    {
        static void Main()
        {
            var matrixLength = Console.ReadLine().Split(' ').ToArray();
            var rows = int.Parse(matrixLength[0]);
            var columns = int.Parse(matrixLength[1]);
            var result = new string[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.WriteLine('a' + i);
                }
            }
        }
    }
}
