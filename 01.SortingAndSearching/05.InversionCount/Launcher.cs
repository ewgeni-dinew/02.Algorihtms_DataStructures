using System;
using System.Linq;

namespace _05.InversionCount
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
              .Split(' ')
              .Select(int.Parse)
              .ToArray();

            var count = 0;

            for (int i = 0; i < array.Length-1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        //Console.WriteLine($"{array[i]} {array[j]}");
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
