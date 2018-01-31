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

                var rcIndex = int.Parse(commands[0]);
                var direction = commands[1];
                var moves = int.Parse(commands[2]);

                switch (direction)
                {
                    case "up":
                        MoveCol(rcIndex, moves, matrix);
                        break;
                    case "down":
                        MoveCol(rcIndex, rows - moves % rows, matrix); //possible bug - matrix length
                        break;
                    case "left":
                        MoveRow(matrix, rcIndex, moves);
                        break;
                    case "right":
                        MoveRow(matrix, rcIndex, cols - moves % cols);
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
                        // if expectedNumber is different
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
                                        $"Swap ({rowIndex}, {colIndex}) with ({r}, {c})");
                                    break;
                                }
                            }
                        }
                    }
                    element++;
                }
            }
        }

        private static void MoveRow(int[,] matrix, int rcIndex, int moves)
        {
            var tempArray = new int[cols];
            for (int colIndex = 0; colIndex < cols; colIndex++)
            {
                tempArray[colIndex] = matrix[rcIndex, (colIndex + moves) % cols];
            }

            for (int colIndex = 0; colIndex < rows; colIndex++)
            {
                matrix[rcIndex, colIndex] = tempArray[colIndex];
            }
        }

        private static void MoveCol(int rcIndex, int moves, int[,] matrix)
        {
            var tempArray = new int[rows];
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                tempArray[rowIndex] = matrix[(rowIndex + moves) % rows, rcIndex];
            }

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex, rcIndex] = tempArray[rowIndex];
            }
        }
    }
}