using System;
using System.Linq;
namespace _01._Matrix_of_Palindromes
{
    class Program
    {
        static void Main()
        {
            var matrixLength = Console.ReadLine()
                .Split(' ')
                .ToArray();
            var rows = int.Parse(matrixLength[0]);
            var columns = int.Parse(matrixLength[1]);
            var result = new string[rows, columns];
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    var strRes = string.Empty;
                    strRes += alphabet[row];
                    strRes += (char)(alphabet[row] + column);
                    strRes += alphabet[row];
                    result[row, column] = strRes;
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}