using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectingTriangles
{
    class Launcher
    {
        private static List<Triangle> triangles = new List<Triangle>();

        static void Main(string[] args)
        {
            var numberOfTriangles = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfTriangles; i++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                var triangle = new Triangle(new Point(input[0], input[1]), new Point(input[2], input[3]), new Point(input[4], input[5]));

                triangles.Add(triangle);
            }

            Console.WriteLine("Intersecting triangles: ");

            for (int i = 0; i < triangles.Count - 1; i++)
            {
                for (int j = i + 1; j < triangles.Count; j++)
                {
                    if (TrianglesIntersect(triangles[i], triangles[j]))
                    {
                        Console.WriteLine($"{i + 1},{j + 1}");
                    }
                }
            }

            Console.ReadKey();
        }

        private static bool TrianglesIntersect(Triangle triangle1, Triangle triangle2)
        {
            foreach (var vector in triangle1.Sides)
            {
                foreach (var vector_prim in triangle2.Sides)
                {
                    if (LinesIntersect(vector.Start, vector.End, vector_prim.Start, vector_prim.End))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool LinesIntersect(Point a, Point b, Point c, Point d)
        {
            var a1 = b.Y - a.Y;
            var b1 = a.X - b.X;
            var c1 = a1 * a.X + b1 * a.Y;

            var a2 = d.Y - c.Y;
            var b2 = c.X - d.X;
            var c2 = a2 * c.X + b2 * c.Y;

            var det = a1 * b2 - a2 * b1;

            if (det == 0)
            {
                return false;
            }
            else
            {
                var x = (b2 * c1 - b1 * c2) / det;
                var y = (a1 * c2 - a2 * c1) / det;

                if (Math.Min(a.X, b.X) <= x && x <= Math.Max(a.X, b.X)
                    && Math.Min(c.X, d.X) <= x && x <= Math.Max(c.X, d.X)
                    && Math.Min(a.Y, b.Y) <= y && y <= Math.Max(a.Y, b.Y)
                    && Math.Min(c.Y, d.Y) <= y && y <= Math.Max(c.Y, d.Y))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}