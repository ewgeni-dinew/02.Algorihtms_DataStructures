using System;
using System.Diagnostics;
using System.Numerics;

namespace Diamonds
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch();

            var input = int.Parse(Console.ReadLine());
            long sum = 0;

            watch.Start();

            for (int i = 0; i <= input; i++)
            {
                for (int j = i; j <= input; j++)
                {
                    sum += (j + i);
                }
            }
            watch.Stop();
            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Time: " + watch.ElapsedMilliseconds);
        }
    }
}
