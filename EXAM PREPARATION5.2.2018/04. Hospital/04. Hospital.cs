using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hospital
{
    public class Program
    {
        public static void Main()
        {
            var departments = new Dictionary<string, List<string>>();
            var doctors = new Dictionary<string, List<string>>();

            var input = Console.ReadLine().Split(new[] { ' ' }
                    , StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            while (input[0] != "Output")
            {
                var currentDepartment = input[0];
                var currentDoctor = input[1] + " " + input[2];
                var patient = input[3];
                //add department and patients
                if (!departments.ContainsKey(currentDepartment))
                {
                    departments.Add(currentDepartment, new List<string>());
                }
                departments[currentDepartment].Add(patient);
                //add doctor and patients
                if (!doctors.ContainsKey(currentDoctor))
                {
                    doctors.Add(currentDoctor, new List<string>());
                }
                doctors[currentDoctor].Add(patient);
                input = Console.ReadLine().Split(new[] { ' ' }
                        , StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
            }
            var printCommand = Console.ReadLine();
            while (printCommand != "End")
            {
                var printCommandArgs = printCommand.Split(' ').ToList();
                var expectedOutput = printCommandArgs[0];
                if (printCommandArgs.Count > 1)
                {
                    int roomNumber;

                    if (int.TryParse(printCommandArgs[1], out roomNumber))
                    {
                        var skipCount = 3 * (roomNumber - 1);
                        foreach (var patients in departments[expectedOutput]
                            .Skip(skipCount)
                            .Take(3).OrderBy(x => x))
                        {
                            Console.WriteLine(patients);
                        }
                    }
                    else
                    {
                        var doctor = expectedOutput + " " + printCommandArgs[1];
                        foreach (var currentDoctor in doctors[doctor]
                            .OrderBy(x => x))
                        {
                            Console.WriteLine(currentDoctor);
                        }
                    }
                }
                else
                {
                    foreach (var currentDepartment in departments[expectedOutput])
                    {
                        Console.WriteLine(currentDepartment);
                    }
                }
                printCommand = Console.ReadLine();
            }
        }
    }
}

