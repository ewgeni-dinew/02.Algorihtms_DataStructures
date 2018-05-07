using System;
using System.Linq;

namespace _06.ReverseArray
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Reverse(array, 0, array.Length - 1);
            Console.WriteLine(string.Join(" ",array));

        }

        private static void Reverse(int [] array,int leftIndex,int rightIndex)
        {
            if ((rightIndex - leftIndex)<=0 )
            {
                return;
            }

            var leftNum = array[leftIndex];
            var rightNum = array[rightIndex];
            array[leftIndex++] = rightNum;
            array[rightIndex--] = leftNum;
            
            Reverse(array, leftIndex, rightIndex);
        }
    }
}
