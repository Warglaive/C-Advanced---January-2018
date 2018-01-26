using System;
using System.Linq;

namespace _03._Squares_in_Matrix
{
    public class Program
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rowsCount = matrixSize[0];
            var columnsCount = matrixSize[1];
            var matrix = new char[rowsCount, columnsCount];
            //fill in Matrix
            for (int linesCount = 0; linesCount < rowsCount; linesCount++)
            {
                var currentLine = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int columns = 0; columns < columnsCount; columns++)
                {
                    matrix[linesCount, columns] = currentLine[columns];
                }
            }
            //
            var squareCount = 0;
            for (int rows = 0; rows < rowsCount - 1; rows++)
            {
                for (int columns = 0; columns < columnsCount - 1; columns++)
                {
                    //check for 2 equal chars on first roll
                    var currentLineChar = matrix[rows, columns];
                    var currentLineNextChar = matrix[rows, columns + 1];

                    var nextRowChar = matrix[rows + 1, columns];
                    var nextRowNextChar = matrix[rows + 1, columns + 1];

                    if (currentLineChar == currentLineNextChar
                        && nextRowChar == nextRowNextChar
                        && currentLineChar == nextRowChar
                        && currentLineNextChar == nextRowNextChar
                        && currentLineChar == nextRowNextChar
                        && currentLineNextChar == nextRowChar)
                    {
                        squareCount++;
                    }
                }
            }
            Console.WriteLine(squareCount);
        }
    }
}
