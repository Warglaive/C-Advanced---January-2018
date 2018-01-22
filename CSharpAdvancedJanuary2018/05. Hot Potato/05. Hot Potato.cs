using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Hot_Potato
{
    public class Program
    {
        public static void Main()
        {
            var kids = Console.ReadLine().Split().ToList();
            var queue = new Queue<string>(kids);
            var number = int.Parse(Console.ReadLine());
            while (queue.Count > 1)
            {
                for (int i = 0; i < number - 1; i++)
                {
                    string reminder = queue.Dequeue();
                    queue.Enqueue(reminder);
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
