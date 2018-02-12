using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SecondTask
{
    public class SecondTask
    {
        public static void Main()
        {
            //fill in matrix
            var rows = int.Parse(Console.ReadLine());
            var matrix = new string[rows, rows * 2 + 1];
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                var input = Console.ReadLine();
                for (int colIndex = 0; colIndex < rows * 2; colIndex++)
                {
                    matrix[rowIndex, colIndex] = input[colIndex].ToString();
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "b") // b - right
                    {
                        var tempArray = matrix[row, col];
                        if (col + 1 > matrix.GetLength(1))//if out of matrix - flip side
                        {
                            matrix[row, col] = "d";
                        }
                        matrix[row, col + 1] = "b";
                        matrix[row, col] = tempArray;
                    }
                    else if (matrix[row, col - 1] == "b")//d-left
                    {
                        var tempArray = matrix[row, col - 1];
                        if (col - 1 < 0)//if out of matrix - flip side
                        {
                            matrix[row, col] = "b";
                        }
                        matrix[row, col + 1] = "d";
                        matrix[row, col] = tempArray;
                    }
                }
            }
        }
    }
}
