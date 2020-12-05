using System;
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
            
        }
    }
}
