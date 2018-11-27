using System;
using System.Collections.Generic;
using System.Text;

namespace MergeIntervals.App
{
    class Interval
    {
        public double Start { get; set; }
        public double End { get; set; }

        public Interval(double start, double end)
        {
            this.Start = start;
            this.End = end;
        }
    }
}
