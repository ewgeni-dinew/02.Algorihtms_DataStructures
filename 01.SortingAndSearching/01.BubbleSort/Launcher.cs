using System;
using System.Diagnostics;
using System.Linq;

namespace _01.BubbleSort
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var swapped = false;

            for (int j = 0; j < array.Length; j++)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    var firstElement = array[i];
                    var secondElement = array[i + 1];

                    if (firstElement > secondElement)
                    {
                        array[i + 1] = firstElement;
                        array[i] = secondElement;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
                swapped = false;
            }

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
