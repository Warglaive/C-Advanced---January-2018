using System;
using System.Linq;

namespace _2.Square_With_Maximum_Sum
{
    public class Program
    {
        public static void Main()
        {
            //First Add elements to matrix
            var rowsAndColumns = Console.ReadLine().Split(',')
                .Select(int.Parse).ToArray();
            var columnsCount = rowsAndColumns[0];
            var rowsCount = rowsAndColumns[1];
            var matrix = new int[columnsCount, rowsCount];
            for (int columns = 0; columns < columnsCount; columns++)
            {
                var rowValues = Console.ReadLine().Split(',')
                    .Select(int.Parse).ToArray();

                for (int rows = 0; rows < rowsCount; rows++)
                {
                    matrix[columns, rows] = rowValues[rows];
                }
            }
            //Now sum the elements
            var sum = 0;
            var firstNum = 0;
            var secondNum = 0;
            var thirdNum = 0;
            var fourthNum = 0;
            for (var rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (var columns = 0; columns < matrix.GetLength(1) - 1; columns++)
                {
                    var newSquareSum = matrix[rows, columns] +
                                       matrix[rows + 1, columns] +
                                       matrix[rows, columns + 1] +
                                       matrix[rows + 1, columns + 1];
                    if (newSquareSum > sum)
                    {
                        sum = newSquareSum;

                        firstNum = matrix[rows, columns];
                        secondNum = matrix[rows + 1, columns];
                        thirdNum = matrix[rows, columns + 1];
                        fourthNum = matrix[rows + 1, columns + 1];
                    }
                }
            }
            Console.WriteLine($"{firstNum} {thirdNum}");
            Console.WriteLine($"{secondNum} {fourthNum}");
            Console.WriteLine(sum);
        }
    }
}
