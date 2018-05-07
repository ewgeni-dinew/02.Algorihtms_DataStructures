using System;
using System.Linq;

namespace _04.BinarySearch
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
              .Split(' ')
              .Select(int.Parse)
              .ToArray();

            var num = int.Parse(Console.ReadLine());

            Console.WriteLine(Search(array,0,array.Length-1,num));
        }

        private static int Search(int[] array,int startIndex,int endIndex, int num)
        {
            var middle = (startIndex+endIndex) / 2;
            var middleNum = array[middle];
            
            if (num==middleNum)
            {
                return middle;
            }
            else if (num < middleNum)
            {
                if (num<array[startIndex])
                {
                    return -1;
                }
                return Search(array, startIndex, middle, num);
            }
            else if (num > middleNum)
            {
                if (num>array[endIndex])
                {
                    return -1;
                }
                return Search(array, middle+1, endIndex, num);
            }
            else
            {
                return -1;
            }
        }
    }
}
