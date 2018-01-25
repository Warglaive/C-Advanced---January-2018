using System;
using System.Linq;

namespace _03.Group_Numbers
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(',')
                .Select(int.Parse).ToArray();
            var sizes = new int[3];
            foreach (var number in numbers) //take arrays length
            {
                var reminder = Math.Abs(number % 3);
                sizes[reminder]++;
            }
            int[][] jaggedArray = new int[3][];
            for (int counter = 0; counter < sizes.Length; counter++)
            {
                jaggedArray[counter] = new int[sizes[counter]];
            }
            int[] index = new int[3];
            foreach (var number in numbers)
            {
                var reminder = Math.Abs(number % 3);
                jaggedArray[reminder][index[reminder]] = number;
                index[reminder]++;
            }
            for (int rows = 0; rows < jaggedArray.Length; rows++)
            {
                for (int columns = 0; columns < jaggedArray[rows].Length; columns++)
                {
                    Console.Write(jaggedArray[rows][columns] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
