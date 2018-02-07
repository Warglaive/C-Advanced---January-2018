using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Array_Manipulator
{
    public class Program
    {
        public static void Main()
        {
            var integersArray = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            var commands = Console.ReadLine();
            while (commands != "end")
            {
                var commandArgs = commands.Split();
                if (commandArgs.Length == 2)
                {
                    var currentCommand = commandArgs[0];
                    var args = commandArgs[1];
                    switch (currentCommand)
                    {
                        case "exchange":
                            var index = int.Parse(args);
                            Exchange(integersArray, index);
                            break;
                        case "max":
                            MaxIndex(integersArray, args);
                            break;
                        case "min":
                            MinIndex(integersArray, args);
                            break;
                    }
                }
                else
                {
                    var firstOrLast = commandArgs[0];
                    var count = int.Parse(commandArgs[1]);
                    var evenOrOdd = commandArgs[2];
                    switch (firstOrLast)
                    {
                        case "first":
                            First(integersArray, count, evenOrOdd);
                            break;
                        case "last":
                            Last(integersArray, count, evenOrOdd);
                            break;
                    }
                }

                commands = Console.ReadLine();
            }
            Console.WriteLine("[" + string.Join(", ", integersArray) + "]");
        }

        private static void Last(List<int> integersArray, int count, string evenOrOdd)
        {
            if (count > integersArray.Count)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            var lastElements = new Stack<int>();
            switch (evenOrOdd)
            {
                case "even":
                    foreach (var currentInt in integersArray)
                    {
                        if (currentInt % 2 == 0)
                        {
                            lastElements.Push(currentInt);
                        }
                    }
                    var lastCountElementsEven = new List<int>();
                    if (lastElements.Count > 2)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            lastCountElementsEven.Add(lastElements.Pop());
                        }
                        Console.WriteLine("[" + string.Join(", ", lastCountElementsEven) + "]");
                    }
                    else
                    {

                        Console.WriteLine("[" + string.Join(", ", lastElements) + "]");
                    }
                    break;

                case "odd":
                    var firstOddElements = new Stack<int>();
                    foreach (var currentInt in integersArray)
                    {
                        if (currentInt % 2 == 1)
                        {
                            firstOddElements.Push(currentInt);
                        }
                    }
                    var lastCountElements = new List<int>();
                    if (firstOddElements.Count > 2)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            lastCountElements.Add(firstOddElements.Pop());
                        }
                        Console.WriteLine("[" + string.Join(", ", lastCountElements) + "]");
                    }
                    else
                    {

                        Console.WriteLine("[" + string.Join(", ", firstOddElements) + "]");
                    }
                    break;
            }
        }

        private static void First(List<int> integersArray, int count, string evenOrOdd)
        {
            if (count > integersArray.Count)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            var firstElements = new Queue<int>();
            switch (evenOrOdd)
            {
                case "even":
                    foreach (var currentInt in integersArray)
                    {
                        if (currentInt % 2 == 0)
                        {
                            firstElements.Enqueue(currentInt);
                        }
                    }
                    var lastCountElementsEven = new List<int>();
                    if (firstElements.Count > 2)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            lastCountElementsEven.Add(firstElements.Dequeue());
                        }
                        Console.WriteLine("[" + string.Join(", ", lastCountElementsEven) + "]");
                    }
                    else
                    {
                        Console.WriteLine("[" + string.Join(", ", firstElements) + "]");
                    }
                    break;

                case "odd":
                    var firstOddElements = new Queue<int>();
                    foreach (var currentInt in integersArray)
                    {
                        if (currentInt % 2 == 1)
                        {
                            firstOddElements.Enqueue(currentInt);
                        }
                    }
                    var lastCountElements = new List<int>();
                    if (firstOddElements.Count > 2)
                    {
                        while (firstOddElements.Count > count)
                        {
                            lastCountElements.Add(firstOddElements.Dequeue());
                        }
                        Console.WriteLine("[" + string.Join(", ", lastCountElements) + "]");
                    }
                    else
                    {
                        Console.WriteLine("[" + string.Join(", ", firstOddElements) + "]");
                    }
                    break;
            }
        }

        private static void MinIndex(List<int> integersArray, string args)
        {
            switch (args)
            {
                case "even":
                    var rightmostIndex = int.MinValue;
                    var maxEvenNum = int.MaxValue;
                    var isMatchEven = false;
                    for (int currentIndex = 0; currentIndex < integersArray.Count; currentIndex++)
                    {
                        if (integersArray[currentIndex] % 2 == 0)
                        {
                            if (maxEvenNum >= integersArray[currentIndex])
                            {
                                rightmostIndex = currentIndex;
                                maxEvenNum = integersArray[currentIndex];
                                isMatchEven = true;
                            }
                        }
                    }
                    if (isMatchEven)
                    {
                        Console.WriteLine(rightmostIndex);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                    break;
                case "odd":
                    var rightmostOdd = int.MinValue;
                    var maxOddNum = int.MaxValue;
                    var isMatchOdd = false;
                    for (int currentIndex = 0; currentIndex < integersArray.Count; currentIndex++)
                    {
                        if (integersArray[currentIndex] % 2 == 1)
                        {
                            if (maxOddNum >= integersArray[currentIndex])
                            {
                                rightmostOdd = currentIndex;
                                maxOddNum = integersArray[currentIndex];
                                isMatchOdd = true;
                            }
                        }
                    }
                    if (isMatchOdd)
                    {
                        Console.WriteLine(rightmostOdd);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                    break;
            }
        }

        private static void MaxIndex(List<int> integersArray, string args)
        {
            switch (args)
            {
                case "odd":
                    var rightMostOdd = int.MinValue;
                    var maxOddIndex = int.MinValue;
                    var isMatch = false;
                    for (int currentIndex = 0; currentIndex < integersArray.Count; currentIndex++)
                    {
                        if (integersArray[currentIndex] % 2 == 1)
                        {
                            if (rightMostOdd <= integersArray[currentIndex])
                            {
                                maxOddIndex = currentIndex;
                                rightMostOdd = integersArray[currentIndex];
                                isMatch = true;
                            }
                        }
                    }
                    if (isMatch)
                    {
                        Console.WriteLine(maxOddIndex);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                    break;
                //
                case "even":
                    var rightMostEven = int.MinValue;
                    var maxEvenNum = int.MinValue;
                    var isMatchEven = false;
                    for (int currentIndex = 0; currentIndex < integersArray.Count; currentIndex++)
                    {
                        if (integersArray[currentIndex] % 2 == 0)
                        {
                            if (maxEvenNum <= integersArray[currentIndex])
                            {
                                rightMostEven = currentIndex;
                                maxEvenNum = integersArray[currentIndex];
                                isMatchEven = true;
                            }
                        }
                    }
                    if (isMatchEven)
                    {
                        Console.WriteLine(rightMostEven);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                    break;
            }
        }

        private static void Exchange(List<int> integersArray, int index)
        {
            var tempArray = new List<int>();
            if (index < 0 || index >= integersArray.Count)
            {
                Console.WriteLine("Invalid index");
                return;
            }
            tempArray.AddRange(integersArray.Take(index + 1));
            integersArray.RemoveRange(0, index + 1);
            integersArray.AddRange(tempArray);
        }
    }
}
