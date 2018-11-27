namespace MergeIntervals.App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Launcher
    {
        static void Main(string[] args)
        {
            var inputIntervals = ReadIntervals();

            var intervals = GetIntervals(inputIntervals);

            var result = MergeIntervals(intervals);

            PrintResult(intervals, result);

        }

        private static double[] ReadIntervals()
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ', ',', ']', '[' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            return input;
        }

        private static List<Interval> GetIntervals(double[] inputIntervals)
        {
            var intervals = new List<Interval>();

            for (int i = 0; i < inputIntervals.Length; i += 2)
            {
                intervals.Add(new Interval(inputIntervals[i], inputIntervals[i + 1]));
            }

            //Orders the provided intervals
            intervals = intervals.OrderBy(i => i.Start)
                .ThenBy(i => i.End)
                .ToList();

            return intervals;
        }

        private static List<Interval> MergeIntervals(List<Interval> intervals)
        {
            var result = new List<Interval>();

            var lastInterval = intervals.First();

            //Must add an element in order for the ->Comparison<- to work
            intervals.Add(new Interval(int.MaxValue, int.MaxValue));

            //we can skip the first element, because we use it as the variable "lastInterval"
            foreach (var interval in intervals.Skip(1))
            {
                //->Comparison<-
                if (interval.Start <= lastInterval.End)
                {
                    interval.Start = lastInterval.Start;
                    interval.End = Math.Max(interval.End, lastInterval.End);
                }
                else
                {
                    //we add the last modified interval, because we won't change it no more
                    result.Add(lastInterval);
                }

                lastInterval = interval;
            }

            //Removes the previously added element
            intervals.RemoveAt(intervals.Count - 1);

            return result;
        }

        private static void PrintResult(List<Interval> intervals, List<Interval> result)
        {
            if (intervals.Count == result.Count)
            {
                //No intervals have been merged
                Console.WriteLine("-1");
            }
            else
            {
                var output = string.Join(", ", result.Select(x => $"[{x.Start},{x.End}]"));

                Console.WriteLine(output);
            }
        }
    }
}
