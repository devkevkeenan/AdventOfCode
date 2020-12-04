using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public static class Solutions
    {
        public static int Numbers()
        {
            var targetNumber = 2020;
            var data = File.ReadAllLines("day-1-1.txt").Select(int.Parse).ToArray();
            Array.Sort(data);

            var i = 0;
            var j = data.Length - 1;
            var count = 0;
            while (data[i] + data[j] != targetNumber && count < data.Length)
            {
                count++;

                if (data[i] + data[j] > targetNumber)
                {
                    j--;
                }
                else if (data[i] + data[j] < targetNumber)
                {
                    i++;
                }
            }

            return data[i] * data[j];
        }
    }
}
