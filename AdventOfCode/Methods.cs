using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        public static int MultiplyItems(int[] list)
        {
            return list.Aggregate(1, (x, y) => x * y);
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
    }
}
