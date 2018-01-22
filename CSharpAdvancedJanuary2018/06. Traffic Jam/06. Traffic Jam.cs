using System;
using System.Collections.Generic;

namespace _06.Traffic_Jam
{
    public class Program
    {
        public static void Main()
        {

            var number = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            var input = Console.ReadLine();
            var counter = 0;
            while (input != "end")
            {
                if (input != "green")
                {
                    queue.Enqueue(input);
                }
                if (input == "green")
                {
                    for (int i = 0; i < number; i++)
                    {
                        if (queue.Count > 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            counter++;
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
