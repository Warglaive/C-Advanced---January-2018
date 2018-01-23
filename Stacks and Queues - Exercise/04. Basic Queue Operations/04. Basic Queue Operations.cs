using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Basic_Queue_Operations
{
    class Program
    {
        public static void Main()
        {
            var NSX = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var N = NSX[0];
            var S = NSX[1];
            var X = NSX[2];
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var queue = new Queue<int>();
            for (int i = 0; i < N; i++) // push to stack
            {
                queue.Enqueue(numbers[i]);
            }
            for (int i = 0; i < S; i++) //pop from stack
            {
                queue.Dequeue();
            }
            if (queue.Count < 1)
            {
                Console.WriteLine(0);
                return;
            }
            foreach (var element in queue)
            {
                if (element.Equals(X))
                {
                    Console.WriteLine("true");
                    return;
                }
            }
            Console.WriteLine(queue.Min());
        }
    }
}
