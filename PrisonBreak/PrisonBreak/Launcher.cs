using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonBreak
{
    class Launcher
    {
        private static readonly int BOARD_SIZE = 15;
        private static int[,] board;
        private static bool isFound = false;
        private static List<Point> points = new List<Point>();
        private static List<Point> blockingDoors = new List<Point>();

        static void Main(string[] args)
        {
            // Get random board
            board = PrisonBreakTools.GetNewMaze(BOARD_SIZE);
            PrintMaze();

            // Get random staring point
            Random rand = new Random();
            int startX, startY;
            do
            {
                startX = rand.Next(0, BOARD_SIZE);
                startY = rand.Next(0, BOARD_SIZE);
            }
            while (board[startX, startY] != TileTypes.EMPTY || startX == 0 || startY == 0 || startX == BOARD_SIZE - 1 || startY == BOARD_SIZE - 1);

            Console.WriteLine("Start: {0} {1}", startX, startY);

            // Your output goes here

            var stack = new Stack<Point>();

            FindPath(stack, startX, startY);//if there is a path the coordinates are stored in List<Point> points

            if (!points.Any())//no path
            {
                Console.WriteLine("No path.");
            }
            else// there is a path
            {
                //Console.WriteLine("Exit: " + string.Join(", ", points));
                Console.WriteLine("Exit: " + points.Last().ToString());

                var doors = GetDoorsFromPath();

                if (!doors.Any())
                {
                    Console.WriteLine("No blocking doors.");
                }
                else
                {
                    GetBlockingDoors(doors, startX, startY);

                    if (!blockingDoors.Any())
                    {
                        Console.WriteLine("No blocking doors!");
                    }
                    else
                    {
                        Console.WriteLine("Blocking doors: ");
                        Console.WriteLine(string.Join(Environment.NewLine, blockingDoors));
                    }
                }
            }
            Console.ReadKey();
        }

        private static void GetBlockingDoors(List<Point> doors, int startX, int startY)
        {
            foreach (var door in doors)
            {
                //reset data
                isFound = false;
                points.Clear();
                var stack = new Stack<Point>();

                board[door.X, door.Y] = TileTypes.WALL;

                FindPath(stack, startX, startY);

                if (!points.Any())
                {
                    blockingDoors.Add(new Point(door.X, door.Y));
                }

                board[door.X, door.Y] = TileTypes.DOOR;
            }
        }

        private static List<Point> GetDoorsFromPath()
        {
            var doors = new List<Point>();

            foreach (var p in points)
            {
                if (board[p.X, p.Y].Equals(TileTypes.DOOR))
                {
                    doors.Add(new Point(p.X, p.Y));
                }
            }

            return doors;
        }

        private static void FindPath(Stack<Point> stack, int startX, int startY)
        {
            //Ensures that if found only 1 valid path will be returned
            //If you want to see all legit paths remove it
            if (isFound)
            {
                return;
            }

            stack.Push(new Point(startX, startY));

            if (IsOnExitPoint(startX, startY))
            {
                points.AddRange(stack.Reverse());
                isFound = true;
            }
            else if (IsPassable(startX, startY))
            {
                var symbol = board[startX, startY];
                board[startX, startY] = TileTypes.TEMP;

                FindPath(stack, startX - 1, startY);//up
                FindPath(stack, startX, startY + 1);//right
                FindPath(stack, startX + 1, startY);//down
                FindPath(stack, startX, startY - 1);//left

                board[startX, startY] = symbol;
                stack.Pop();
            }
            else
            {
                stack.Pop();
            }
        }

        private static void PrintMaze()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static bool IsOnExitPoint(int startX, int startY)
        {
            if (startY.Equals(0) || startY.Equals(BOARD_SIZE - 1) || startX.Equals(0) || startX.Equals(BOARD_SIZE - 1))
            {
                if (board[startX, startY].Equals(TileTypes.EMPTY) || board[startX, startY].Equals(TileTypes.DOOR))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        private static bool IsPassable(int startX, int startY)
        {
            if (board[startX, startY].Equals(TileTypes.EMPTY) || board[startX, startY].Equals(TileTypes.DOOR))
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