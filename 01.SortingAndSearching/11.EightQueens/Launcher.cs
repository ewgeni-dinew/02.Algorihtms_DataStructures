using System;

namespace ConsoleApp1
{
    class Launcher
    {
        static char[][] field = new char[8][];

        static void Main(string[] args)
        {
            InitializeField();
            if (CheckQueensMethod(0, 0, 1))
            {
                PrintField();
            }
        }

        private static bool CheckQueensMethod(int x, int y, int move)
        {
            field[x][y] = 'Q';

            if (move >= 8)
            {
                return true;
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (CanPlaceQueen(i, j))
                    {
                        var flag = CheckQueensMethod(i, j, move + 1);

                        if (flag)
                        {
                            return true;
                        }
                    }
                }
            }

            field[x][y] = '-';
            return false;
        }

        private static bool CanPlaceQueen(int x, int y)
        {
            if (field[x][y] == 'Q')
            {
                return false;
            }

            for (int i = 0; i < 8; i++)
            {
                if (field[i][y] == 'Q' || field[x][i] == 'Q')
                {
                    return false;
                }
                else if (!DiagonalContainsQueen(x, y))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool DiagonalContainsQueen(int row, int col)
        {
            for (int i = row - 1, j = col + 1; i >= 0 && j < 8; i--, j++)
            {
                if (field[i][j] == 'Q')
                {
                    return false;
                }
            }
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (field[i][j] == 'Q')
                {
                    return false;
                }
            }
            for (int i = row + 1, j = col - 1; i < 8 && j >= 0; i++, j--)
            {
                if (field[i][j] == 'Q')
                {
                    return false;
                }
            }
            for (int i = row + 1, j = col + 1; i < 8 && j < 8; i++, j++)
            {
                if (field[i][j] == 'Q')
                {
                    return false;
                }
            }
            return true;
        }

        private static void PrintField()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(string.Join("", field[i]));
            }
            Console.WriteLine();

        }

        private static void InitializeField()
        {
            for (int i = 0; i < 8; i++)
            {
                field[i] = "--------".ToCharArray();
            }
        }

    }
}
