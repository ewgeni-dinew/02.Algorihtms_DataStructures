using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectingTriangles
{
    class Triangle
    {
        public Point Point_1 { get; private set; }
        public Point Point_2 { get; private set; }
        public Point Point_3 { get; private set; }
        public ICollection<Vector> Sides { get; private set; }

        public Triangle(Point a, Point b, Point c)
        {
            this.Point_1 = a;
            this.Point_2 = b;
            this.Point_3 = c;
            this.Sides = new List<Vector>() { new Vector(Point_1, Point_2), new Vector(Point_2, Point_3), new Vector(Point_1, Point_3) };
        }
    }
}
