using System;
using System.Linq;

namespace _06._Target_Practice
{
    public class Program
    {
        private static int rows;
        private static int columns;
        public static void Main()
        {
            var rowsCols = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            rows = rowsCols[0];
            columns = rowsCols[1];

            var matrix = new char[rows, columns];

            var snake = Console.ReadLine().ToCharArray();
            var shotParams = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var impactRow = shotParams[0];
            var impactColumn = shotParams[1];
            var radius = shotParams[2];

            var snakeIndex = 0;

            FillInMatrix(snakeIndex, snake, matrix);
            Shoot(impactRow, impactColumn, radius, matrix);
            StartFallin(matrix);
            Print(matrix);
        }

        private static void Print(char[,] matrix)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void StartFallin(char[,] matrix)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    //proverqvame vseki element, ako pod nego e prazno - switchvame
                    if (matrix[row, col] != ' ' && matrix[row + 1, col] == ' ')
                    {
                        var temp = matrix[row, col];
                        matrix[row + 1, col] = temp;
                        matrix[row, col] = ' ';
                        row = 0;
                        col = 0;
                    }
                }
            }
        }

        private static void Shoot(int impactRow, int impactColumn, int radius, char[,] matrix)
        {
            matrix[impactRow, impactColumn] = ' ';
            //Calculate radius
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if ((row - impactRow) *
                        (row - impactRow) +
                        (col - impactColumn) *
                        (col - impactColumn)
                        <= radius * radius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

        }

        private static void FillInMatrix(int snakeIndex, char[] snake, char[,] matrix)
        {
            var counter = 0;
            for (int rowIndex = rows; rowIndex > 0; rowIndex--)
            {
                if (counter % 2 == 0)
                {
                    for (int colIndex = columns; colIndex > 0; colIndex--) //right to left
                    {
                        if (snakeIndex <= snake.Length - 1)
                        {
                            matrix[rowIndex - 1, colIndex - 1] = snake[snakeIndex];
                            snakeIndex++;
                        }
                        else
                        {
                            colIndex++;
                            snakeIndex = 0;
                        }
                    }
                }
                //left to right
                rowIndex--;
                if (rowIndex == 0)
                {
                    break;
                }
                for (int colIndex = 0; colIndex < columns; colIndex++)
                {
                    if (snakeIndex <= snake.Length - 1)
                    {
                        matrix[rowIndex - 1, colIndex] = snake[snakeIndex];
                        snakeIndex++;
                    }
                    else
                    {
                        colIndex--;
                        snakeIndex = 0;
                    }
                }
            }
        }
    }
}