using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Labyrinth
{
    class Launcher
    {
        static char[][] labyrinth;
        static Stack<char> symbols = new Stack<char>();

        static void Main()
        {
            ReadLabyrinth();
            
            SolvePath(0, 0,' ');
        }

        private static void ReadLabyrinth()
        {
            var rows = int.Parse(Console.ReadLine());
            var columns = int.Parse(Console.ReadLine());

            labyrinth = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                var line = Console.ReadLine()
                    .ToCharArray();

                labyrinth[i]=line;
            }
        }

        private static void SolvePath(int row,int col,char direction)
        {
            if (IsOutSideTheLabyrinth(row,col))
            {
                return;
            }

            symbols.Push(direction);

            if (IsOnExitPoint(row,col))
            {
                PrintResult();
            }
            else if (IsPassable(row,col))
            {
                labyrinth[row][col] = 'x';

                SolvePath(row + 1, col,'D');//Down
                SolvePath(row - 1, col,'U');//Up
                SolvePath(row, col+1, 'R');//Right
                SolvePath(row, col-1, 'L');//Left

                labyrinth[row][col] = '-';
            }

            symbols.Pop();
        }

        private static bool IsPassable(int row, int col)
        {
            if (labyrinth[row][col] == 'x' ||
                labyrinth[row][col] == '*') 
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void PrintResult()
        {
            Console.WriteLine(string.Join("",symbols.Reverse()).Trim());
        }

        private static bool IsOnExitPoint(int row, int col)
        {
            return labyrinth[row][col] == 'e';
        }

        private static bool IsOutSideTheLabyrinth(int row, int col)
        {
            if (row < 0 || col >= labyrinth[0].Length ||
                row >= labyrinth.GetLength(0) || col < 0) 
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
