using System;
using System.Linq;

namespace _05._Rubiks_Matrix
{
    public class Program
    {
        private static int rows;
        private static int cols;
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            rows = input[0];
            cols = input[1];
            var matrix = new int[rows, cols];
            var rubikMatrix = new int[rows, cols];
            var counter = 0;
            //Fill in Matrix
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = ++counter;
                    rubikMatrix[i, j] = counter;
                }
            }
            //Algorithm
            var commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                var commands = Console.ReadLine().Split(new[] { ' ' }
                        , StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var rowCol = int.Parse(commands[0]);
                var direction = commands[1];
                var moves = int.Parse(commands[2]);
                switch (direction)
                {
                    case "up":
                        MoveUp(rowCol, moves, matrix);
                        break;
                    case "down":
                        MoveDown(rowCol, moves, matrix);
                        break;
                    case "left":
                        MoveLeft(rowCol, moves, matrix);
                        break;
                    case "right":
                        MoveRight(rowCol, moves, matrix);
                        break;
                }
            }
            rearrangeMatrix(matrix);
        }

        private static void rearrangeMatrix(int[,] matrix)
        {
            var element = 1;
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    if (matrix[rowIndex, colIndex] == element)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < rows; r++)
                        {
                            for (int c = 0; c < cols; c++)
                            {
                                if (matrix[r, c] == element)
                                {
                                    var currentElement = matrix[rowIndex, colIndex];
                                    matrix[rowIndex, colIndex] = element;
                                    matrix[r, c] = currentElement;
                                    Console.WriteLine(
                                        $"Swap ({rowIndex}, {colIndex}) " +
                                        $"with ({r}, {c})");
                                }
                            }
                        }
                    }
                    element++;
                }
            }
        }

        private static void MoveRight(int rowCol, int moves, int[,] matrix)
        {
            var columns = cols; //column's count (by input)
            var tempArray = new int[columns];
            for (int row = 0; row < columns; row++) //fill col's values in temp array
            {
                tempArray[row] = matrix[rowCol, row];
            }
            var counter = tempArray.Length - 1;
            for (int row = 0; row < tempArray.Length; row++) //change values in matrix from temp array
            {
                matrix[rowCol, row] = tempArray[counter];
                counter++;
                if (counter > tempArray.Length - 1)
                {
                    counter = 0;
                }
            }
        }

        private static void MoveLeft(int rowCol, int moves, int[,] matrix)
        {
            var columns = cols; //column's count (by input)
            var tempArray = new int[columns];
            for (int row = 0; row < columns; row++) //fill col's values in temp array
            {
                tempArray[row] = matrix[rowCol, row];
            }
            var counter = 1;
            for (int row = 0; row < tempArray.Length; row++) //change values in matrix from temp array
            {
                matrix[rowCol, row] = tempArray[counter];
                counter++;
                if (counter > tempArray.Length - 1)
                {
                    counter = 0;
                }
            }
        }

        private static void MoveDown(int rowCol, int moves, int[,] matrix)
        {
            //save current column's values
            var columns = cols; //column's count (by input)
            var tempArray = new int[columns];
            for (int col = 0; col < columns; col++) //fill col's values in temp array
            {
                tempArray[col] = matrix[col, rowCol];
            }
            var counter = tempArray.Length - 1;
            for (int col = 0; col < tempArray.Length; col++) //change values in matrix from temp array
            {
                matrix[col, rowCol] = tempArray[counter];
                counter++;
                if (counter > tempArray.Length - 1)
                {
                    counter = 0;
                }
            }
        }

        private static void MoveUp(int rowCol, int moves, int[,] matrix)
        {
            //save current column's values
            var columns = cols; //column's count (by input)
            var tempArray = new int[columns];
            for (int col = 0; col < columns; col++) //fill col's values in temp array
            {
                tempArray[col] = matrix[col, rowCol];
            }
            var counter = 1;
            for (int col = 0; col < tempArray.Length; col++) //change values in matrix from temp array
            {
                matrix[col, rowCol] = tempArray[counter];
                counter++;
                if (counter > tempArray.Length - 1)
                {
                    counter = 0;
                }
            }
        }
    }
}