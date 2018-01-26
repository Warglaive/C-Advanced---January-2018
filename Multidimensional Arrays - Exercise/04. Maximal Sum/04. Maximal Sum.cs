using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Maximal_Sum
{
    public class Program
    {
        public static void Main()
        {
            var maxSum = new Stack<int>();

            var size = Console.ReadLine()
                .Split(new[] { ' ' }
                    , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var rowsCount = size[0];
            var columnsCount = size[1];
            var matrix = new int[rowsCount, columnsCount];
            var totalSquaresPossible = Math.Floor(rowsCount * columnsCount / 3d);
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
            for (int startRow = 0; startRow < totalSquaresPossible; startRow++)
            {
                var biggestSum = 0;

                var currentRowSum = 0;
                for (int rows = 0; rows < 3; rows++)
                {
                    for (int columns = 0; columns < 3; columns++)
                    {
                        currentRowSum += matrix[rows, columns];
                        if (currentRowSum > biggestSum)
                        {
                            biggestSum = currentRowSum;
                        }
                    }
                }
            }
        }
    }
}