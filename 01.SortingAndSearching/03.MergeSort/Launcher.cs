using System;
using System.Diagnostics;
using System.Linq;

namespace _03.MergeSort
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToArray();
      
            Sort(array, 0, array.Length - 1);

            Console.WriteLine(string.Join(" ",array));
        }

        private static void Sort(int[] array,int startIndex,int endIndex)
        {
            if (startIndex>=endIndex)
            {
                return;
            }

            var middleIndex = (startIndex + endIndex) / 2;

            Sort(array, startIndex, middleIndex);
            Sort(array, middleIndex+1, endIndex);

            Merge(array, startIndex, middleIndex, endIndex);
        }

        private static void Merge(int[] array, int startIndex, int middleIndex, int endIndex)
        {
            if (middleIndex < 0 ||
                middleIndex + 1 >= array.Length ||
                array[middleIndex] <= array[middleIndex + 1])
            {
                return;
            }
            
            var newArray = new int[array.Length];

            for (int i = 0; i <array.Length; i++)
            {
                newArray[i] = array[i];
            }

            var leftIndex = startIndex;
            var rightIndex = middleIndex + 1;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (leftIndex > middleIndex)
                {
                    array[i] = newArray[rightIndex];
                    rightIndex++;
                }
                else if (rightIndex > endIndex)
                {
                    array[i] = newArray[leftIndex];
                    leftIndex++;
                }
                else if (newArray[leftIndex] <= newArray[rightIndex])
                {
                    array[i] = newArray[leftIndex];
                    leftIndex++;

                }
                else if (newArray[leftIndex] > newArray[rightIndex])
                {
                    array[i] = newArray[rightIndex];
                    rightIndex++;
                }
            }
        }
    }
}
