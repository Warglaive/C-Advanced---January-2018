using System;
using System.Linq;

namespace _05._Rubiks_Matrix
{
    public class Program
    {
        private static int[,] matrix;
        private static int rows;
        private static int columns;
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            rows = input[0];
            columns = input[1];

            matrix = new int[rows, columns];

            var rubikMatrix = new int[rows, columns];
            var number = 0;
            //Fill in Matrix
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = ++number;
                    rubikMatrix[row, col] = number;
                }
            }
            //Algorithm
            var commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                var commandArgs = Console.ReadLine().Split(new[] { ' ' }
                        , StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var command = commandArgs[1];
                var index = int.Parse(commandArgs[0]);
                var rotations = int.Parse(commandArgs[2]);

                switch (command)
                {
                    case "up":
                        MoveColumn(index, rows - rotations % rows);
                        break;
                    case "down":
                        MoveColumn(index, rotations % rows);
                        break;
                    case "left":
                        MoveRow(index, columns - rotations % columns);
                        break;
                    case "right":
                        MoveRow(index, rotations % columns);
                        break;

                }
            }
            RearrangeMatrix();
        }

        private static void RearrangeMatrix()
        {
            var expected = 1;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (matrix[row, col] == expected)
                    {
                        Console.WriteLine("No swap required");
                        expected++;
                        continue;
                    }
                    else
                    {
                        for (int r = 0; r < rows; r++)
                        {
                            for (int c = 0; c < columns; c++)
                            {
                                if (matrix[r, c] == expected)
                                {
                                    int temp = matrix[row, col];
                                    matrix[row, col] = matrix[r, c];
                                    matrix[r, c] = temp;
                                    Console.WriteLine(
                                        $"Swap ({row}, {col}) with ({r}, {c})");

                                }
                            }
                        }
                    }
                    expected++;
                }
            }
        }

        private static void MoveRow(int index, int rotations)
        {
            // rotations %= columns;
            int[] tempArray = new int[columns];
            for (int col = 0; col < columns; col++)
            {
                int replacementIndex = col - rotations;
                if (replacementIndex < 0)
                {
                    replacementIndex += columns;
                }
                replacementIndex %= columns;

                tempArray[columns] = matrix[replacementIndex, col];
            }
            for (int col = 0; col < columns; col++)
            {
                matrix[index, col] = tempArray[col];
            }
        }

        private static void MoveColumn(int index, int rotations)
        {
            // rotations %= rows;
            int[] tempArray = new int[rows];
            for (int row = 0; row < rows; row++)
            {
                int replacementIndex = row - rotations;
                if (replacementIndex < 0)
                {
                    replacementIndex += columns;
                }
                replacementIndex %= columns;
                tempArray[row] = matrix[row, replacementIndex];
            }
            for (int row = 0; row < rows; row++)
            {
                matrix[row, index] = tempArray[row];
            }
        }
    }
}