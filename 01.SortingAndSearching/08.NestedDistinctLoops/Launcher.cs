using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.NestedDistinctLoops
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var arraySize = int.Parse(Console.ReadLine());

            var array = new int[arraySize];

            DrawFigure(array, 0 ,num,1);
        }

        private static void DrawFigure(int[] array,int index,int num,int startNum)
        {
            if (index>array.Length-1)
            {
                if (array.Distinct().Count()!=array.Length)
                {
                    return;
                }
                Console.WriteLine(string.Join(" ",array));
                return;
            }
            for (int i = startNum; i <= num; i++)
            {
                array[index] = i;
                DrawFigure(array,index+1,num,i);
            }
        }
    }
}
