using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class Methods
    {
        public static int[] GetItemsWhichSumToTarget(int[] list, int target, int numberOfItems)
        {
            Array.Sort(list);
            return GetNItemsWhichSumToTarget(list, target, numberOfItems);
        }

        public static int[] GetNItemsWhichSumToTarget(int[] list, int target, int numberOfItems)
        {
            if (numberOfItems == 2)
            {
                return GetTwoItemsWhichSumToTarget(list, target);
            }
            else
            {
                for (int i = 0; i < list.Length - (numberOfItems - 2); i++)
                {
                    var tempTarget = target - list[i];
                    var innerResult = GetNItemsWhichSumToTarget(list.Skip(i).ToArray(), tempTarget, numberOfItems - 1);
                    if (innerResult != null)
                    {
                        var result = new[] { list[i] };
                        return result.Concat(innerResult).ToArray();
                    }
                }
            }

            return null;
        }

        public static int[] GetTwoItemsWhichSumToTarget(int[] list, int target)
        {
            var i = 0;
            var j = list.Length - 1;

            // if the items don't add up loop
            while (list[i] + list[j] != target)
            {
                if (i + 1 == j)
                    return null;

                // if the sum is too big, reduce upper number
                while (list[i] + list[j] > target)
                {
                    j--;
                }

                if (i + 1 == j)
                    return null;

                // if the sum is too small, increase lower number
                while (list[i] + list[j] < target)
                {
                    i++;
                }
            }

            return new[] { list[i], list[j] };
        }

        public static long MultiplyItems(int[] list)
        {
            return list.Aggregate<int, long>(1, (current, item) => current * item);
        }

        private static readonly Regex PasswordRegex = new Regex(@"^([0-9]*)-([0-9]*) ([a-z]): ([a-z]+)$");
        public static int GetNumberOfValidPasswords(string[] list, bool usePositionRule)
        {
            var result = 0;
            
            foreach (var item in list)
            {
                var regexMatch = PasswordRegex.Match(item);
                var minValue = int.Parse(regexMatch.Groups[1].Value);
                var maxValue = int.Parse(regexMatch.Groups[2].Value);
                var charToMatch = char.Parse(regexMatch.Groups[3].Value);
                var password = regexMatch.Groups[4].Value;

                var numberOfInstances = password.Count(x => x == charToMatch);

                if (usePositionRule)
                {
                    if (password[minValue-1] == charToMatch ^ password[maxValue-1] == charToMatch)
                    {
                        result++;
                    }
                }
                else
                {
                    if (numberOfInstances >= minValue && numberOfInstances <= maxValue)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        public static bool[,] GetMap(string[] list)
        {
            var result = new bool[list[0].Length, list.Length];

            for (int y = 0; y < list.Length; y++)
            {
                for (int x = 0; x < list[0].Length; x++)
                {
                    result[x, y] = list[y][x] == '#';
                }
            }

            return result;
        }

        public static int GetNumberOfCollisions(bool[,] map, int xMovement, int yMovement)
        {
            var result = 0;
            var xPos = 0;
            var yPos = 0;

            while (yPos < map.GetLength(1))
            {
                result += map[xPos, yPos] ? 1 : 0;
                xPos = (xPos + xMovement) % map.GetLength(0);
                yPos += yMovement;
            }

            return result;
        }
    }
}
