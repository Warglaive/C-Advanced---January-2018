using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hospital
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }
                    , StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var result = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
            //
            var roomCount = 0;
            while (input[0] != "Output")
            {
                var department = input[0];
                var doctor = input[1] + " " + input[2];
                var patient = input[3];

                if (!result.ContainsKey(department))
                {
                    result.Add(department, new Dictionary<string, Dictionary<string, int>>());
                }

                if (!result[department].ContainsKey(doctor))
                {
                    result[department].Add(doctor, new Dictionary<string, int>());
                }

                if (!result[department][doctor].ContainsKey(patient))
                {
                    result[department][doctor].Add(patient, roomCount);
                }

                input = Console.ReadLine().Split(new[] { ' ' }
                        , StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
            }
            var printCommand = Console.ReadLine();
        }
    }
}
