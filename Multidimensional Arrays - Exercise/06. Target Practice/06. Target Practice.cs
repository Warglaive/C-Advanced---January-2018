using System;
using System.Linq;

namespace _06._Target_Practice
{
    public class Program
    {
        public static void Main()
        {
            var rowsCols = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = rowsCols[0];
            var columns = rowsCols[1];

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

            for (int rowIndex = rows; rowIndex > 0; rowIndex--)
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