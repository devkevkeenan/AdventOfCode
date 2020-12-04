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
            switch (day)
            {
                case 1:
                    var list = File.ReadAllLines("day-1.txt").Select(int.Parse).ToArray();

                    var answer1 = Methods.GetItemsWhichSumToTarget(list, 2020, 2);
                    Console.WriteLine($"Part 1 Answer : {Methods.MultiplyItems(answer1)}");

                    var answer2 = Methods.GetItemsWhichSumToTarget(list, 2020, 3);
                    Console.WriteLine($"Part 2 Answer : {Methods.MultiplyItems(answer2)}");

                    break;
                default:
                    break;
            }
            
        }
    }
}
