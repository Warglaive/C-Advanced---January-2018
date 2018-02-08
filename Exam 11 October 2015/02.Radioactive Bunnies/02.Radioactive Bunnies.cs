using System;
using System.Linq;

namespace _02.Radioactive_Bunnies
{
    public class Program
    {
        public static int finalRow;
        public static int finalCol;
        public static void Main()
        {
            var rowsAndColumns = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            var rows = rowsAndColumns[0]; //N
            var columns = rowsAndColumns[1];
            //fill in the lair(matrix)
            var theLair = new string[rows, columns];
            for (int rowsIndex = 0; rowsIndex < rows; rowsIndex++)
            {
                var inputLine = Console.ReadLine();
                for (int colIndex = 0; colIndex < columns; colIndex++)
                {
                    theLair[rowsIndex, colIndex] = inputLine[colIndex].ToString();
                }
            }
            //receiving player's steps
            var commands = Console.ReadLine().ToCharArray();
            foreach (var currentDirection in commands)
            {
                switch (currentDirection)
                {
                    case 'U': //Up - towards first line

                        var isAlive = MoveUp(theLair);
                        if (!isAlive)  // print if dead
                        {
                            Print(theLair, finalRow, finalCol, isAlive);
                            Environment.Exit(0);
                        }
                        break;
                    case 'D':
                        isAlive = MoveDown(theLair);
                        if (!isAlive)
                        {
                            Print(theLair, finalRow, finalCol, isAlive);
                            Environment.Exit(0);
                        }
                        break;
                    case 'L':
                        isAlive = MoveLeft(theLair);
                        if (!isAlive)
                        {
                            Print(theLair, finalRow, finalCol, isAlive);
                            Environment.Exit(0);
                        }
                        break;
                    case 'R':
                        isAlive = MoveRight(theLair);
                        if (!isAlive)
                        {
                            Print(theLair, finalRow, finalCol, isAlive);
                            Environment.Exit(0);
                        }
                        break;
                }
            }

        }

        private static bool MoveRight(string[,] theLair)
        {
            bool playerIsAlive = true;
            for (int rows = 0; rows < theLair.GetLength(0); rows++)
            {
                for (int cols = 0; cols < theLair.GetLength(1); cols++)
                {
                    //border check
                    if (theLair[rows, cols] == "P" && cols + 1 < theLair.GetLength(1))
                    {
                        var tempArray = theLair[rows, cols];
                        //if bunny reached when player move - he dies
                        if (theLair[rows, cols + 1] == "B")
                        {
                            playerIsAlive = false;
                            finalRow = rows;
                            finalCol = cols + 1;
                        }
                        else
                        {
                            theLair[rows, cols + 1] = tempArray;
                            if (theLair[rows, cols] != "B")
                            {
                                theLair[rows, cols] = ".";
                            }
                            break;
                        }
                    }
                    //check if winner(outside of the matrix)
                    else if (theLair[rows, cols] == "P" && cols + 1 > theLair.GetLength(1))
                    {
                        finalRow = rows;
                        finalCol = cols;
                        //put empty on last player possition cuz he exited and won
                        theLair[finalRow, finalCol] = ".";
                        MultiplyBunnies(theLair);//multiply before print winner
                        Print(theLair, finalRow, finalCol, playerIsAlive);
                        Environment.Exit(0);
                    }
                }
            }
            MultiplyBunnies(theLair);
            return playerIsAlive;
        }

        private static bool MoveLeft(string[,] theLair)
        {
            bool playerIsAlive = true;
            for (int rows = 0; rows < theLair.GetLength(0); rows++)
            {
                for (int cols = 0; cols < theLair.GetLength(1); cols++)
                {
                    //border check
                    if (theLair[rows, cols] == "P" && cols - 1 >= 0)
                    {
                        var tempArray = theLair[rows, cols];
                        //if bunny reached when player move - he dies
                        if (theLair[rows, cols - 1] == "B")
                        {
                            playerIsAlive = false;
                            finalRow = rows;
                            finalCol = cols - 1;
                        }
                        else
                        {
                            theLair[rows, cols - 1] = tempArray;
                            if (theLair[rows, cols] != "B")
                            {
                                theLair[rows, cols] = ".";
                            }
                            break;
                        }
                    }
                    //check if winner(outside of the matrix)
                    else if (theLair[rows, cols] == "P" && cols - 1 < 0)
                    {
                        finalRow = rows;
                        finalCol = cols;
                        //put empty on last player possition cuz he exited and won
                        theLair[finalRow, finalCol] = ".";
                        MultiplyBunnies(theLair);//multiply before print winner
                        Print(theLair, finalRow, finalCol, playerIsAlive);
                        Environment.Exit(0);
                    }
                }
            }
            MultiplyBunnies(theLair);
            return playerIsAlive;
        }

        private static bool MoveDown(string[,] theLair)
        {
            bool playerIsAlive = true;
            for (int rows = 0; rows < theLair.GetLength(0); rows++)
            {
                for (int cols = 0; cols < theLair.GetLength(1); cols++)
                {
                    //border check
                    if (theLair[rows, cols] == "P" && rows + 1 < theLair.GetLength(0))
                    {
                        var tempArray = theLair[rows, cols];
                        //if bunny reached when player move - he dies
                        if (theLair[rows + 1, cols] == "B")
                        {
                            playerIsAlive = false;
                            finalRow = rows + 1;
                            finalCol = cols;
                        }
                        else
                        {
                            theLair[rows + 1, cols] = tempArray;
                            if (theLair[rows, cols] != "B")
                            {
                                theLair[rows, cols] = ".";
                            }
                            break;
                        }
                    }
                    //check if winner(outside of the matrix)
                    else if (theLair[rows, cols] == "P" && rows + 1 > theLair.GetLength(0))
                    {
                        finalRow = rows;
                        finalCol = cols;
                        //put empty on last player possition cuz he exited and won
                        theLair[finalRow, finalCol] = ".";
                        MultiplyBunnies(theLair);//multiply before print winner
                        Print(theLair, finalRow, finalCol, playerIsAlive);
                        Environment.Exit(0);
                    }
                }
            }
            MultiplyBunnies(theLair);
            return playerIsAlive;
        }

        private static void Print(string[,] theLair, int row, int col, bool isAlive)
        {
            //Print final lair
            for (int rowsIndex = 0; rowsIndex < theLair.GetLength(0); rowsIndex++)
            {
                for (int colsIndex = 0; colsIndex < theLair.GetLength(1); colsIndex++)
                {
                    Console.Write(theLair[rowsIndex, colsIndex]);
                }
                Console.WriteLine();
            }
            //Print player
            if (isAlive)
            {
                Console.WriteLine($"won: {row} {col}");
            }
            else
            {
                Console.WriteLine($"dead: {row} {col}");
            }
        }

        private static bool MoveUp(string[,] theLair)
        {
            bool playerIsAlive = true;
            for (int rows = 0; rows < theLair.GetLength(0); rows++)
            {
                for (int cols = 0; cols < theLair.GetLength(1); cols++)
                {
                    if (theLair[rows, cols] == "P" && rows - 1 >= 0)//border check
                    {
                        var tempArray = theLair[rows, cols];
                        //if bunny reached when player move - he dies
                        if (theLair[rows - 1, cols] == "B")
                        {
                            playerIsAlive = false;//take final rows where player died
                            finalRow = rows - 1;
                            finalCol = cols;
                        }
                        else
                        {
                            theLair[rows - 1, cols] = tempArray;
                            if (theLair[rows, cols] != "B")
                            {
                                theLair[rows, cols] = ".";
                            }
                            break;
                        }
                    }//check if winner(outside of the matrix)
                    else if (theLair[rows, cols] == "P" && rows - 1 < 0)
                    {
                        finalRow = rows;
                        finalCol = cols;
                        //put empty on last player possition cuz he exited and won
                        theLair[finalRow, finalCol] = ".";
                        MultiplyBunnies(theLair);//multiply before print winner
                        Print(theLair, finalRow, finalCol, playerIsAlive);
                        Environment.Exit(0);
                    }
                }
            }
            MultiplyBunnies(theLair);
            return playerIsAlive;
        }

        private static void MultiplyBunnies(string[,] theLair)
        {
            string[,] tempMatrix = (string[,])theLair.Clone();
            //ako na suotvetniq index ima zaek i v DVETE matrici
            //- razmnojavai, else - ne;
            var rowsBorder = theLair.GetLength(0);
            var colsBorder = theLair.GetLength(1);
            for (int rows = 0; rows < rowsBorder; rows++)
            {
                for (int cols = 0; cols < colsBorder; cols++)
                {
                    if (theLair[rows, cols] == "B" && tempMatrix[rows, cols] == "B")
                    {
                        //if in border UP;
                        if (rows - 1 >= 0 && theLair[rows - 1, cols] != "B")
                        {
                            theLair[rows - 1, cols] = "B";
                        }
                        //if in border DOWN;
                        if (rows + 1 < rowsBorder && theLair[rows + 1, cols] != "B")
                        {
                            theLair[rows + 1, cols] = "B";
                        }
                        //if in border LEFT
                        if (cols - 1 >= 0 && theLair[rows, cols - 1] != "B")
                        {
                            theLair[rows, cols - 1] = "B";
                            cols--;
                        }
                        //if in border RIGHT
                        if (cols + 1 < colsBorder && theLair[rows, cols + 1] != "B")
                        {
                            theLair[rows, cols + 1] = "B";
                            cols++;
                        }
                    }
                }
            }
        }
    }
}