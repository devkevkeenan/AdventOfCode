using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
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

        private static readonly string[] RequiredKeys = new[] {"ecl", "pid", "eyr", "hcl", "byr", "iyr", "hgt"};
        
        public static int GetNumberOfValidPassports(List<Dictionary<string, string>> passports, Func<Dictionary<string, string>, bool> validCriteria)
        {
            return passports.Count(validCriteria);
        }

        public static bool PassportMeetsValidation(Dictionary<string, string> passport)
        {
            return RequiredKeys.All(passport.ContainsKey);
        }

        public static bool PassportHasRequiredFields(Dictionary<string, string> passport)
        {
            if (!PassportMeetsValidation(passport))
                return false;

            var valid = true;
            foreach (var keyValuePair in passport)
            {
                switch (keyValuePair.Key)
                {
                    case "byr":
                        //(Birth Year) -four digits; at least 1920 and at most 2002.
                        if (!ValueIsInRange(keyValuePair.Value, 1920, 2002))
                            valid = false;
                        break;
                    case "iyr":
                        //(Issue Year) - four digits; at least 2010 and at most 2020.
                        if (!ValueIsInRange(keyValuePair.Value, 2010, 2020))
                            valid = false;
                        break;
                    case "eyr":
                        //(Expiration Year) - four digits; at least 2020 and at most 2030.
                        if (!ValueIsInRange(keyValuePair.Value, 2020, 2030))
                            valid = false;
                        break;
                    case "hgt":
                        //(Height) - a number followed by either cm or in:
                        //If cm, the number must be at least 150 and at most 193.
                        //If in, the number must be at least 59 and at most 76.
                        var unit = keyValuePair.Value.Substring(Math.Max(0, keyValuePair.Value.Length - 2));
                        if (unit != "cm" && unit != "in")
                            valid = false;
                        else
                        {
                            var number = keyValuePair.Value.Substring(0, keyValuePair.Value.Length - 2);
                            if (unit == "cm" && !ValueIsInRange(number, 150, 193))
                                valid = false;
                            else if (unit == "in" && !ValueIsInRange(number, 59, 76))
                                valid = false;

                        }

                        break;
                    case "hcl":
                        //(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                        if (!Regex.IsMatch(keyValuePair.Value, "^#[0123456789abcdef]{6}$"))
                            valid = false;
                        break;
                    case "ecl":
                        //(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                        if (!Regex.IsMatch(keyValuePair.Value, "^amb|blu|brn|gry|grn|hzl|oth$"))
                            valid = false;
                        break;
                    case "pid":
                        //(Passport ID) - a nine - digit number, including leading zeroes.
                        if (!Regex.IsMatch(keyValuePair.Value, "^[0-9]{9}$"))
                            valid = false;
                        break;
                    default:
                        break;
                }
            }

            return valid;
        }

        private static bool ValueIsInRange(string stringValue, int minValue, int maxValue)
        {
            return int.TryParse(stringValue, out var intValue) && intValue >= minValue && intValue <= maxValue;
        }

        public static List<Dictionary<string, string>> GetPassports(string[] list)
        {
            var passports = new List<Dictionary<string, string>> {new Dictionary<string, string>()};

            foreach (var line in list)
            {
                if (string.IsNullOrEmpty(line))
                {
                    passports.Add(new Dictionary<string, string>());
                }
                else
                {
                    var lineItems = line.Split(" ");
                    foreach (var lineItem in lineItems)
                    {
                        var components = lineItem.Split(":");
                        passports.Last().Add(components[0], components[1]);
                    }
                }
            }

            return passports;
        }
    }
}
