using System;
using System.Linq;

namespace _02.Radioactive_Bunnies
{
    public class Program
    {
        public static int finalRow = int.MinValue;
        public static int finalCol = int.MinValue;
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
                        MoveUp(theLair);
                        break;
                    case 'D':
                        MoveDown(theLair);
                        break;
                    case 'L':
                        MoveLeft(theLair);
                        break;
                    case 'R':
                        MoveRight(theLair);
                        break;
                }
            }

        }

        private static void MoveRight(string[,] theLair)
        {
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
                            finalRow = rows;
                            finalCol = cols + 1;
                            MultiplyBunnies(theLair);
                            PrintFinalLair(theLair);
                            Console.WriteLine($"dead: {finalRow} {finalCol}");
                            Environment.Exit(0);
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
                        PrintFinalLair(theLair);
                        Console.WriteLine($"won: {finalRow} {finalCol}");
                        Environment.Exit(0);
                    }
                }
            }
            MultiplyBunnies(theLair);
        }

        private static void MoveLeft(string[,] theLair)
        {
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
                            finalRow = rows;
                            finalCol = cols - 1;
                            MultiplyBunnies(theLair);
                            PrintFinalLair(theLair);
                            Console.WriteLine($"dead: {finalRow} {finalCol}");
                            Environment.Exit(0);
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
                        PrintFinalLair(theLair);
                        Console.WriteLine($"won: {finalRow} {finalCol}");
                        Environment.Exit(0);
                    }
                }
            }
            MultiplyBunnies(theLair);
        }

        private static void MoveDown(string[,] theLair)
        {
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
                            finalRow = rows + 1;
                            finalCol = cols;
                            MultiplyBunnies(theLair);
                            PrintFinalLair(theLair);
                            Console.WriteLine($"dead: {finalRow} {finalCol}");
                            Environment.Exit(0);
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
                        PrintFinalLair(theLair);
                        Console.WriteLine($"won: {finalRow} {finalCol}");
                        Environment.Exit(0);
                    }
                }
            }
            MultiplyBunnies(theLair);
        }

        private static void PrintFinalLair(string[,] theLair)
        {
            //PrintFinalLair final lair
            for (int rowsIndex = 0; rowsIndex < theLair.GetLength(0); rowsIndex++)
            {
                for (int colsIndex = 0; colsIndex < theLair.GetLength(1); colsIndex++)
                {
                    Console.Write(theLair[rowsIndex, colsIndex]);
                }
                Console.WriteLine();
            }
        }

        private static void MoveUp(string[,] theLair)
        {
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
                            finalRow = rows - 1;
                            finalCol = cols;
                            MultiplyBunnies(theLair);
                            PrintFinalLair(theLair);
                            Console.WriteLine($"dead: {finalRow} {finalCol}");
                            Environment.Exit(0);
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
                        PrintFinalLair(theLair);
                        Console.WriteLine($"won: {finalRow} {finalCol}");
                        Environment.Exit(0);
                    }
                }
            }
            MultiplyBunnies(theLair);
        }

        private static void MultiplyBunnies(string[,] theLair)
        {
            string[,] tempMatrix = (string[,])theLair.Clone();
            //ako na suotvetniq index ima zaek i v DVETE matrici
            //- razmnojavai, else - ne;
            bool playerHasDied = false;
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
                            //check if player reached;
                            if (theLair[rows - 1, cols] == "P" && finalRow < 0 && finalCol < 0)
                            {
                                finalRow = rows - 1;
                                finalCol = cols;
                                playerHasDied = true;
                            }
                            theLair[rows - 1, cols] = "B";
                        }
                        //if in border DOWN;
                        if (rows + 1 < rowsBorder && theLair[rows + 1, cols] != "B")
                        {
                            if (theLair[rows + 1, cols] == "P" && finalRow < 0 && finalCol < 0)
                            {
                                finalRow = rows + 1;
                                finalCol = cols;
                                playerHasDied = true;
                            }
                            theLair[rows + 1, cols] = "B";
                        }
                        //if in border LEFT
                        if (cols - 1 >= 0 && theLair[rows, cols - 1] != "B")
                        {
                            if (theLair[rows, cols - 1] == "P" && finalRow < 0 && finalCol < 0)
                            {
                                finalRow = rows;
                                finalCol = cols - 1;
                                playerHasDied = true;
                            }
                            theLair[rows, cols - 1] = "B";
                            cols--;
                        }
                        //if in border RIGHT
                        if (cols + 1 < colsBorder && theLair[rows, cols + 1] != "B")
                        {
                            if (theLair[rows, cols + 1] == "P" && finalRow < 0 && finalCol < 0)
                            {
                                finalRow = rows;
                                finalCol = cols + 1;
                                playerHasDied = true;
                            }
                            theLair[rows, cols + 1] = "B";
                            cols++;
                        }
                    }
                }
            }
            if (playerHasDied)
            {
                PrintFinalLair(theLair);
                Console.WriteLine($"dead: {finalRow} {finalCol}");
                Environment.Exit(0);
            }
        }
    }
}