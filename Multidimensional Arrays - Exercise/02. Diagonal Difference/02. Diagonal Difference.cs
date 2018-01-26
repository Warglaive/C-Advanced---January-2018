using System;
using System.Linq;

namespace _02._Diagonal_Difference
{
    public class Program
    {
        public static void Main()
        {
            var squareMatrixSize = int.Parse(Console.ReadLine());
            var currentMatrix = new int[squareMatrixSize, squareMatrixSize];
            //read input
            for (int rows = 0; rows < squareMatrixSize; rows++)
            {
                var inputLine = Console.ReadLine()
                    .Split(new[] { ' ' }
                        , StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int columns = 0; columns < currentMatrix.GetLength(1); columns++)
                {
                    currentMatrix[rows, columns] = inputLine[columns];
                }
            }
            //
            var primaryDiagonal = 0;
            var secondaryDiagonal = 0;
            //PRIMARI DIAGONAL
            for (var rows = -1; rows < squareMatrixSize - 1; rows++)
            {
                for (int columns = 0; columns < squareMatrixSize; columns++)
                {
                    rows++;
                    primaryDiagonal += currentMatrix[rows, columns];
                }
            }
            //SECONDARY DIAGONAL
            for (var rows = -1; rows < squareMatrixSize - 1; rows++)
            {
                for (var columns = squareMatrixSize - 1; columns >= 0; columns--)
                {
                    rows++;
                    secondaryDiagonal += currentMatrix[rows, columns];
                }
            }
            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}