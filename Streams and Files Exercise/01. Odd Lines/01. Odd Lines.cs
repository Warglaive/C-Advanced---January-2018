using System;
using System.IO;

namespace _01._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new StreamReader("test.txt"))
            {
                var length = stream.BaseStream.Length;
                for (int i = 0; i < length; i++)
                {

                }
            }
        }
    }
}
