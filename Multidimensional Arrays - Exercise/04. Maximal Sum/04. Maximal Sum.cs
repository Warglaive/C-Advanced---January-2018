using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Maximal_Sum
{
    public class Program
    {
        public static void Main()
        {
            var size = Console.ReadLine()
                .Split(new[] { ' ' }
                    , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var rowsCount = size[0];
            var columnsCount = size[1];
            var matrix = new int[rowsCount, columnsCount];
            //fill in matrix
            for (int rows = 0; rows < rowsCount; rows++)
            {
                var input = Console.ReadLine()
                    .Split(new[] { ' ' }
                        , StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int columns = 0; columns < columnsCount; columns++)
                {
                    matrix[rows, columns] = input[columns];
                }
            }
            //algorithm
            var rowIndex = int.MinValue;
            var colIndex = int.MinValue;
            var maxSum = 0;
            for (int startRow = 0; startRow < rowsCount - 2; startRow++)
            {
                for (var startColumn = 0; startColumn < columnsCount - 2; startColumn++)
                {
                    var currentRowSum = 0;
                    for (var rows = startRow; rows <= startRow + 2; rows++)
                    {
                        for (var columns = startColumn; columns <= startColumn + 2; columns++)
                        {
                            currentRowSum += matrix[rows, columns];

                            if (currentRowSum > maxSum)
                            {
                                rowIndex = rows - 1;
                                colIndex = columns - 1;
                                maxSum = currentRowSum;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[rowIndex - 1, colIndex - 1]} " +
                              $"{matrix[rowIndex - 1, colIndex]} " +
                              $"{matrix[rowIndex - 1, colIndex + 1]}");

            Console.WriteLine($"{matrix[rowIndex, colIndex - 1]} " +
                              $"{matrix[rowIndex, colIndex]} " +
                              $"{matrix[rowIndex, colIndex + 1]}");

            Console.WriteLine($"{matrix[rowIndex + 1, colIndex - 1]} " +
                              $"{matrix[rowIndex + 1, colIndex]} " +
                              $"{matrix[rowIndex + 1, colIndex + 1]}");

        }
    }
}