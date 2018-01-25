using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Pascal_Triangle
{
    public class Program
    {
        public static void Main()
        {
            var height = long.Parse(Console.ReadLine());

            var triangle = new long[height][];
            for (int currentHeight = 0; currentHeight < height; currentHeight++)
            {
                triangle[currentHeight] = new long[currentHeight + 1];
                triangle[currentHeight][0] = 1;
                triangle[currentHeight][currentHeight] = 1;
                if (currentHeight >= 2)
                {
                    for (var widthCounter = 1; widthCounter < currentHeight; widthCounter++)
                    {
                        triangle[currentHeight][widthCounter] =
                            triangle[currentHeight - 1][widthCounter - 1] +
                            triangle[currentHeight - 1][widthCounter];
                    }
                }
            }
            //print
            for (var rows = 0; rows < triangle.Length; rows++)
            {
                for (var columns = 0; columns < triangle[rows].Length; columns++)
                {
                    Console.Write(triangle[rows][columns] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}