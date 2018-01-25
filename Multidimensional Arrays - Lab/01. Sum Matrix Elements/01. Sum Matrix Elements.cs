using System;
using System.Linq;

namespace _01.Sum_Matrix_Elements
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
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                }
            }
            Console.WriteLine(sum);
        }
    }
}