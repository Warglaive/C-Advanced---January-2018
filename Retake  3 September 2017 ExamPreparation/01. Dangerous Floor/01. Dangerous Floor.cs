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
                var figureType = inputArgs[0];
                var rowIndex = inputArgs[1];
                var colIndex = inputArgs[2];

                var finalRow = inputArgs[4];
                var finalCol = inputArgs[4];

                IsThereApieceOnStartingSquare(figureType,rowIndex,colIndex);

                //
                input = Console.ReadLine();
            }
        }
    }
}
