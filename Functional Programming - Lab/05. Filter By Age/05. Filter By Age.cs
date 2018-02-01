using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    public class Program
    {
        public static void Main()
        {
            var result = new Dictionary<string, int>();
            var linesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesCount; i++)
            {
                var input = Console.ReadLine()
                    .Split(new[] { ',' }
                        , StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                var name = input[0];
                var age = int.Parse(input[1]);
                result[name] = age;
            }
            var condition = Console.ReadLine();
            var currentAge = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();
            if (condition == "younger")
            {
                switch (format)
                {
                    case "name":
                        PrintNameOnly(currentAge, result);
                        break;
                    case "name age":
                        PrintNameAge(currentAge, result);
                        break;
                    case "age":
                        PrintAge(currentAge, result);
                        break;
                }
            }
            else
            {
                switch (format)
                {
                    case "name":
                        PrintNameOnlyOlder(currentAge, result);
                        break;
                    case "name age":
                        PrintNameAgeOlder(currentAge, result);
                        break;
                    case "age":
                        PrintAgeOlder(currentAge, result);
                        break;
                }
            }
        }

        private static void PrintAgeOlder(int currentAge, Dictionary<string, int> result)
        {
            foreach (var name in result)
            {
                if (name.Value > currentAge)
                {
                    Console.WriteLine($"{name.Value}");
                }
            }
        }

        private static void PrintNameAgeOlder(int currentAge, Dictionary<string, int> result)
        {
            foreach (var name in result)
            {
                if (name.Value >= currentAge)
                {
                    Console.WriteLine($"{name.Key} - {name.Value}");
                }
            }
        }

        private static void PrintNameOnlyOlder(int currentAge, Dictionary<string, int> result)
        {
            foreach (var name in result)
            {
                if (name.Value >= currentAge)
                {
                    Console.WriteLine(name.Key);
                }
            }
        }

        private static void PrintAge(int currentAge, Dictionary<string, int> result)
        {
            foreach (var name in result)
            {
                if (name.Value <= currentAge)
                {
                    Console.WriteLine($"{name.Value}");
                }
            }
        }

        private static void PrintNameAge(int currentAge, Dictionary<string, int> result)
        {
            foreach (var name in result)
            {
                if (name.Value < currentAge)
                {
                    Console.WriteLine($"{name.Key} - {name.Value}");
                }
            }
        }

        private static void PrintNameOnly(int currentAge, Dictionary<string, int> result)
        {
            foreach (var name in result)
            {
                if (name.Value < currentAge)
                {
                    Console.WriteLine(name.Key);
                }
            }
        }
    }
}
