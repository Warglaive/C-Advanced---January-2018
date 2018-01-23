using System;
using System.Collections.Generic;

namespace _05.Sequence_With_Queue
{
    public class Program
    {
        public static void Main()
        {
            var currentElement = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            queue.Enqueue(currentElement);
            Console.Write(currentElement + " ");
            for (int i = 1; i < 50;)
            {
                currentElement = queue.Dequeue();
                Console.Write(currentElement + 1 + " ");
                queue.Enqueue(currentElement + 1);
                i++;
                if (i < 50)
                {
                    Console.Write(2 * currentElement + 1 + " ");
                    queue.Enqueue(2 * currentElement + 1);
                    i++;
                }
                else
                {
                    break;
                }
                if (i < 50)
                {
                    Console.Write(currentElement + 2 + " ");
                    queue.Enqueue(currentElement + 2);
                    i++;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
