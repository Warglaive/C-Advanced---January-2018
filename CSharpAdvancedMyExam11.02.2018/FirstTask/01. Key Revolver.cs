using System;
using System.Linq;

namespace FirstTask
{
    public class Program
    {
        public static void Main()
        {
            var bulletPrice = decimal.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();
            var locks = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();
            var intelValue = decimal.Parse(Console.ReadLine());
            //front to back locks
            //reload on every barrelCount shoots
            decimal totalBulletsShot = 0;
            var shootedBulletsCounter = 0;
            for (int lockIndex = 0; lockIndex < locks.Count; lockIndex++)
            {
                for (int bulletIndex = bullets.Count - 1; bulletIndex > 0;)
                {

                    bulletIndex = bullets.Count - 1;
                    if (shootedBulletsCounter == gunBarrelSize)
                    {
                        Console.WriteLine("Reloading!");
                        shootedBulletsCounter = 0;
                    }
                    if (locks.Count < 1)
                    {
                        break;
                    }//if shooted bullets >= bullet barel size

                    //if smaller or equal(bullet) - remove lock
                    if (bullets[bulletIndex] <= locks[lockIndex])
                    {
                        Console.WriteLine("Bang!");
                        locks.RemoveAt(lockIndex);
                        bullets.RemoveAt(bulletIndex);
                        shootedBulletsCounter++;
                        totalBulletsShot++;
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                        bullets.RemoveAt(bulletIndex);
                        shootedBulletsCounter++;
                        totalBulletsShot++;
                    }
                }
                // if bullets go empty before locks 
                if (bullets.Count < locks.Count)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    Environment.Exit(0);
                }
                if (locks.Count <= 0 && bullets.Count >= 0)
                {
                    decimal totalCost = intelValue - totalBulletsShot * bulletPrice;
                    Console.WriteLine($"{bullets.Count} bullets left." +
                                      $" Earned ${totalCost}");
                    Environment.Exit(0);
                }
            }
        }
    }
}
