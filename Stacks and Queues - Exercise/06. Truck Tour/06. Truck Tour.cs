using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Truck_Tour
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                var pump = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                queue.Enqueue(pump);
            }
            for (int currentStart = 0; currentStart < n - 1; currentStart++)
            {
                var fuel = 0;
                for (int pumpsPassed = 0; pumpsPassed < n; pumpsPassed++)
                {
                    var currentPump = queue.Dequeue();
                    var fuelGiven = currentPump[0];
                    var distanceTillNextPuml = currentPump[1];
                    queue.Enqueue(currentPump);
                    fuel += fuelGiven - distanceTillNextPuml;
                    if (fuel < 0)
                    {
                        currentStart += pumpsPassed;
                        break;
                    }
                }
                if (fuel > 0)
                {
                    Console.WriteLine(currentStart);
                    return;
                }
            }
        }
    }
}
