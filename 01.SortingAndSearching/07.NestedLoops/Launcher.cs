using System;

namespace _07.NestedLoops
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());

            var array = new int[num];
            
            DrawFigure(array,0);
        }

        private static void DrawFigure(int[] array,int index)
        {
            if (index>array.Length-1)
            {
                Console.WriteLine(string.Join(" ",array));
                return;
            }
            for (int i = 1; i <= array.Length; i++)
            {
                array[index] = i;
                DrawFigure(array,index+1);
            }
        }
    }
}
