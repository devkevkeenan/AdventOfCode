﻿using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a day : ");
            var day = int.Parse(Console.ReadLine());
            if (day == 1)
            {
                var list = File.ReadAllLines("day-1.txt").Select(int.Parse).ToArray();

                var answer1 = Methods.GetItemsWhichSumToTarget(list, 2020, 2);
                Console.WriteLine($"Part 1 Answer : {Methods.MultiplyItems(answer1)}");

                var answer2 = Methods.GetItemsWhichSumToTarget(list, 2020, 3);
                Console.WriteLine($"Part 2 Answer : {Methods.MultiplyItems(answer2)}");
            }
            else if (day == 2)
            {
                var list = File.ReadAllLines("day-2.txt").ToArray();

                var answer1 = Methods.GetNumberOfValidPasswords(list, false);
                Console.WriteLine($"Part 1 Answer : {answer1}");

                var answer2 = Methods.GetNumberOfValidPasswords(list, true);
                Console.WriteLine($"Part 2 Answer : {answer2}");
            }
            else if (day == 3)
            {
                var list = File.ReadAllLines("day-3.txt").ToArray();
                var map = Methods.GetMap(list);

                var answer1 = Methods.GetNumberOfCollisions(map, 3, 1);
                Console.WriteLine($"Part 1 Answer : {answer1}");

                var answer2Scenarios = new Tuple<int, int>[]
                {
                    new Tuple<int, int>(1, 1),
                    new Tuple<int, int>(3, 1),
                    new Tuple<int, int>(5, 1),
                    new Tuple<int, int>(7, 1),
                    new Tuple<int, int>(1, 2)
                };

                var answer2s = answer2Scenarios.Select(x => Methods.GetNumberOfCollisions(map, x.Item1, x.Item2))
                    .ToArray();

                var answer2 = Methods.MultiplyItems(answer2s);
                Console.WriteLine($"Part 2 Answer : {answer2}");
            }
            else if (day == 4)
            {
                var list = File.ReadAllLines("day-4.txt").ToArray();
                var passports = Methods.GetPassports(list);
                var answer1 = Methods.GetNumberOfValidPassports(passports, Methods.PassportMeetsValidation);
                Console.WriteLine($"Part 1 Answer : {answer1}");
                var answer2 = Methods.GetNumberOfValidPassports(passports, Methods.PassportHasRequiredFields);
                Console.WriteLine($"Part 2 Answer : {answer2}");
            }
            else if (day == 5)
            {
                var list = File.ReadAllLines("day-5.txt").ToArray();
                var answer1 = Methods.GetHighestSeat(list);
                Console.WriteLine($"Part 1 Answer : {answer1}");
                var answer2 = Methods.GetMissingSeat(list);
                Console.WriteLine($"Part 2 Answer : {answer2}");
            }
            else if (day == 6)
            {
                var text = File.ReadAllText("day-6.txt");
                var groups = text.Split("\n\n").Select(x => x.Split("\n").ToArray()).ToArray();
                var answer1 = groups.Sum(Methods.GetAnyYesAnswerCount);
                Console.WriteLine($"Part 1 Answer : {answer1}");
                var answer2 = groups.Sum(Methods.GetAllYesAnswerCount);
                Console.WriteLine($"Part 2 Answer : {answer2}");
            }
        }
    }
}
