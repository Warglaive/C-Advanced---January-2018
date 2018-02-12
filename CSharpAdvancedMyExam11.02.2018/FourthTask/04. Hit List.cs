using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace FourthTask
{
    public class Program
    {
        public static void Main()
        {
            var result = new Dictionary<string, Dictionary<string, string>>();
            var targetInfoIndex = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            while (input != "end transmissions")
            {
                var inputArgs = input
                    .Split(new[] { ':', ';', '=' }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                var name = inputArgs[0];
                //take all arguments after name(may be long)
                for (int i = 1; i < inputArgs.Count; i += 2)
                {
                    var keyArgument = inputArgs[i];
                    if (!result.ContainsKey(name))
                    {
                        result.Add(name, new Dictionary<string, string>());
                    }
                    if (!result[name].ContainsKey(keyArgument))
                    {
                        result[name].Add(keyArgument, inputArgs[i + 1]);
                    }
                    result[name][keyArgument] = inputArgs[i + 1];
                }
                input = Console.ReadLine();
            }
            var finalLine = Console.ReadLine().Split(' ').ToList();
            var wantedTarget = finalLine[1];
            foreach (var currentTarget in result.Keys)
            {//print info about target
                if (currentTarget == wantedTarget)
                {
                    Console.WriteLine($"Info on {wantedTarget}:");
                    //
                    foreach (var keyInfo in result[currentTarget]
                        .OrderBy(x => x.Key))
                    {
                        Console.WriteLine($"---{keyInfo.Key}: {keyInfo.Value}");
                    }
                    //Print Index
                    var indexInfo = 0;
                    foreach (var indexInfoKvP in result[currentTarget])
                    {
                        indexInfo += indexInfoKvP.Key.Length;
                        indexInfo += indexInfoKvP.Value.Length;
                    }
                    Console.WriteLine($"Info index: {indexInfo}");
                    if (indexInfo >= targetInfoIndex)
                    {
                        Console.WriteLine("Proceed");
                    }
                    else
                    {
                        Console.WriteLine($"Need {targetInfoIndex - indexInfo} more info.");
                    }
                }
            }
        }
    }
}
