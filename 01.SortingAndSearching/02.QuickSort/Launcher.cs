using System;
using System.Linq;

namespace _02.QuickSort
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToArray();

        }

        private static void Sort(int[] array)
        {
            var left = 0;
            var right = array.Length-1;
            var middle = array.Length / 2;

            if (array.Length<3)
            {
                return;
            }
            var element = array[middle];

            for (int i = left; i <right; i++)
            {
                if (array[i]<element)
                {

                }
            }
        }
    }
}
