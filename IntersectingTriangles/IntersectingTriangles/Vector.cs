using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectingTriangles
{
    class Vector
    {
        public Point Start { get; private set; }
        public Point End { get; private set; }

        public Vector(Point a, Point b)
        {
            this.Start = a;
            this.End = b;
        }
    }
}
