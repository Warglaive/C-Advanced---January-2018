using System;

namespace _02._Knight_Game
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            if (n < 3)
            {
                Console.WriteLine(0);
                Environment.Exit(0);
            }
            var matrix = new string[n, n];
            //fill in matrix
            for (int rowIndex = 0; rowIndex < n; rowIndex++)
            {
                var input = Console.ReadLine();
                for (int colIndex = 0; colIndex < n; colIndex++)
                {
                    matrix[rowIndex, colIndex] = input[colIndex].ToString();
                }
            }
            //algorithm
            //check if current knight can attack
            int currentKnightsInDanger = 0;
            int maxKnightsInDanger = -1;
            int mostDangerousKnightRow = 0;
            int mostDangerousKnightCol = 0;
            int count = 0;
            while (true)
            {
                for (int rowIndex = 0; rowIndex < n - 2; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < n - 2; colIndex++)
                    {
                        if (matrix[rowIndex, colIndex] == "K")
                        {
                            //2 Rows DOWN - 1 column RIGHT
                            if ((rowIndex + 2 < n
                                 && colIndex + 1 < n)
                                &&
                                matrix[rowIndex + 2, colIndex + 1] == "K")
                            {
                                currentKnightsInDanger++;
                            }
                            //2 Rows DOWN - 1 column LEFT
                            if ((rowIndex + 2 < n
                                 && colIndex - 1 >= 0)
                                &&
                                matrix[rowIndex + 2, colIndex - 1] == "K")
                            {
                                currentKnightsInDanger++;
                            }
                            //2 Rows UP - 1 column LEFT
                            if ((rowIndex - 2 >= 0
                                 && colIndex - 1 >= 0)
                                &&
                                matrix[rowIndex - 2, colIndex - 1] == "K")
                            {
                                currentKnightsInDanger++;

                            }
                            //2 Rows UP - 1 column RIGHT
                            if ((rowIndex - 2 >= 0
                                 && colIndex + 1 < n)
                                && matrix[rowIndex - 2, colIndex + 1] == "K")
                            {
                                currentKnightsInDanger++;
                            }
                            //1 Row UP - 2 columns LEFT
                            if ((rowIndex - 1 >= 0
                                 && colIndex - 2 >= 0)
                                &&
                                matrix[rowIndex - 1, colIndex - 2] == "K")
                            {
                                currentKnightsInDanger++;

                            } // 1 Row Up - 2 columns RIGHT
                            if (rowIndex - 1 >= 0
                                && colIndex + 2 < n
                                && matrix[rowIndex - 1, colIndex + 2] == "K")
                            {
                                currentKnightsInDanger++;
                            }
                            //1 Row DOWN - 2 columns RIGHT
                            if ((rowIndex + 1 < n
                                 && colIndex + 2 < n)
                                &&
                                matrix[rowIndex + 1, colIndex + 2] == "K")
                            {
                                currentKnightsInDanger++;

                            } //1 Row DOWN - 2 columns LEFT
                            if ((rowIndex + 1 < n
                                 && colIndex - 2 >= 0)
                                &&
                                matrix[rowIndex + 1, colIndex - 2] == "K")
                            {
                                currentKnightsInDanger++;
                            }
                        }
                        if (currentKnightsInDanger > maxKnightsInDanger)
                        {
                            maxKnightsInDanger = currentKnightsInDanger;
                            mostDangerousKnightRow = rowIndex;
                            mostDangerousKnightCol = colIndex;
                        }
                        currentKnightsInDanger = 0;
                    }
                }
                if (maxKnightsInDanger != 0)
                {
                    matrix[mostDangerousKnightRow, mostDangerousKnightCol] = "0";
                    count++;
                    maxKnightsInDanger = 0;
                }
                else
                {
                    Console.WriteLine(count);
                    return;
                }
            }
        }
    }
}