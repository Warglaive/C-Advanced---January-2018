using System;
using System.IO;

namespace _01._Odd_Lines
{
    class Program
    {
        static void Main()
        {
            var counter = 0;
            using (var stream = new StreamReader("text.txt"))
            {
                var currentLine = stream.ReadLine();
                while (currentLine != null)
                {
                    if (counter % 2 == 1)
                    {
                        Console.WriteLine(currentLine);
                        counter++;
                        currentLine = stream.ReadLine();
                    }
                    else
                    {
                        counter++;
                        currentLine = stream.ReadLine();
                    }
                }
            }
        }
    }
}