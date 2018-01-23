using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Truck_Tour
{
    public class Program
    {
        public static void Main()
        {
            var queue = new Queue<int>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var currentInt = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToList();
                var petrolAmount = currentInt[0];
                var distanceBetweenPumps = currentInt[1];
                //calculate total circle and fuel - 12 km, got fuel for 14

            }
        }
    }
}
