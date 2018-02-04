using System;
using System.Linq;

namespace _01._Dangerous_Floor
{
    public class Program
    {
        public static void Main()
        {
            var boardMatrix = new string[8, 8];

            //fill in matrix
            for (int row = 0; row < 8; row++)
            {
                var line = Console.ReadLine()
                    .Split(',')
                    .ToList();
                for (int col = 0; col < 8; col++)
                {
                    boardMatrix[row, col] = line[col];
                }
            }

            var input = Console.ReadLine();
            while (input != "END")
            {
                //
                var inputArgs = input.ToCharArray();
                var figureType = inputArgs[0].ToString();
                var rowIndex = int.Parse(inputArgs[1].ToString());
                var colIndex = int.Parse(inputArgs[2].ToString());

                var finalRow = int.Parse(inputArgs[4].ToString());
                var finalCol = int.Parse(inputArgs[5].ToString());
                if (finalRow >= 8 || finalCol >= 8)//Borders Check
                {
                    Console.WriteLine("Move go out of board!");
                    input = Console.ReadLine();
                    continue;
                }
                //FirstCheck
                if (IsThereApieceOnStartingSquare(figureType, rowIndex, colIndex, boardMatrix))
                {
                    //Perform movement
                    MoveFigure(figureType, boardMatrix, rowIndex, colIndex, finalRow, finalCol);
                }

                //
                input = Console.ReadLine();
            }
        }

        private static void MoveFigure(string figureType, string[,] boardMatrix, int rowIndex, int colIndex, int finalRow, int finalCol)
        {
            switch (figureType)
            {
                case "K":
                    isKingMovable(boardMatrix, rowIndex, colIndex, finalRow, finalCol);
                    break;
                case "R":
                    IsRookMovable(boardMatrix, rowIndex, colIndex, finalRow, finalCol);
                    break;
                case "B":
                    IsBishopMovable(boardMatrix, rowIndex, colIndex, finalRow, finalCol);
                    break;
                case "Q":
                    IsQueenMovable(boardMatrix, rowIndex, colIndex, finalRow, finalCol);
                    break;
                case "P":
                    isPawnMovable(boardMatrix, rowIndex, colIndex, finalRow, finalCol);
                    break;
            }
        }

        private static void isPawnMovable(string[,] boardMatrix, int rowIndex, int colIndex, int finalRow, int finalCol)
        {
            if (colIndex == finalCol && rowIndex - 1 == finalRow)
            {
                var tempArray = boardMatrix[rowIndex, colIndex];
                boardMatrix[finalRow, finalCol] = tempArray;
                boardMatrix[rowIndex, colIndex] = "x";
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }
        }

        private static void IsQueenMovable(string[,] boardMatrix, int rowIndex, int colIndex, int finalRow, int finalCol)
        {
            if (boardMatrix[finalRow, finalCol] == "x")
            {
                MoveQueen(boardMatrix, rowIndex, colIndex, finalRow, finalCol);
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }
        }

        private static void MoveQueen(string[,] boardMatrix, int rowIndex, int colIndex, int finalRow, int finalCol)
        {
            var tempArray = boardMatrix[rowIndex, colIndex];
            boardMatrix[finalRow, finalCol] = tempArray;
            boardMatrix[rowIndex, colIndex] = "x";
        }

        private static void IsBishopMovable(string[,] boardMatrix, int rowIndex, int colIndex, int finalRow, int finalCol)
        {
            //moves any number of vacant squares in any diagonal direction
            //check if is diagonally
            if (rowIndex != finalRow && colIndex != finalCol)
            {
                MoveBishop(boardMatrix, rowIndex, colIndex, finalRow, finalCol);
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }
        }

        private static void MoveBishop(string[,] boardMatrix, int rowIndex, int colIndex, int finalRow, int finalCol)
        {
            var tempArray = boardMatrix[rowIndex, colIndex];
            boardMatrix[finalRow, finalCol] = tempArray;
            boardMatrix[rowIndex, colIndex] = "x";
        }

        private static void IsRookMovable(string[,] boardMatrix, int rowIndex, int colIndex, int finalRow, int finalCol)
        {
            //check if move is on same row or col

            if (rowIndex == finalRow || colIndex == finalCol)
            {
                MoveRook(boardMatrix, rowIndex, colIndex, finalRow, finalCol);
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }
        }

        private static void MoveRook(string[,] boardMatrix, int rowIndex, int colIndex, int finalRow, int finalCol)
        {
            var tempArray = boardMatrix[rowIndex, colIndex];
            boardMatrix[finalRow, finalCol] = tempArray;
            boardMatrix[rowIndex, colIndex] = "x";
        }

        private static void isKingMovable(string[,] boardMatrix, int rowIndex, int colIndex, int finalRow, int finalCol)
        {
            //POSSIBLE BUG
            //check diagonally
            if ((rowIndex - 1 == finalRow
                || rowIndex + 1 == finalRow)
                && (colIndex + 1 == finalCol
                || colIndex - 1 == finalCol))
            {
                MoveKing(boardMatrix, rowIndex, colIndex, finalRow, finalCol);
            }
            //Check vertically(columns)
            else if (colIndex == finalCol && (rowIndex == finalRow - 1
                || rowIndex == finalRow + 1))
            {
                MoveKing(boardMatrix, rowIndex, colIndex, finalRow, finalCol);
            }
            //check horizontally(row)
            else if ((rowIndex == finalRow)
                && (colIndex == finalCol + 1 || colIndex == finalCol - 1))
            {
                MoveKing(boardMatrix, rowIndex, colIndex, finalRow, finalCol);
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }
        }

        private static void MoveKing(string[,] boardMatrix, int rowIndex, int colIndex, int finalRow, int finalCol)
        {
            var tempArray = boardMatrix[rowIndex, colIndex];
            boardMatrix[finalRow, finalCol] = tempArray;
            boardMatrix[rowIndex, colIndex] = "x";
        }

        private static bool IsThereApieceOnStartingSquare(string figureType, int rowIndex, int colIndex, string[,] boardMatrix)
        {
            if (boardMatrix[rowIndex, colIndex].Equals(figureType))
            {
                return true;
            }
            Console.WriteLine("There is no such a piece!");
            return false;
        }
    }
}