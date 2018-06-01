using Game.Models;
using System;

namespace Game
{
    public class GameEngine
    {
        private Hero player1;
        private Hero player2;

        public GameEngine(Hero player1, Hero player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public void Run()
        {
            while (true)
            {
                player1.Attack(player2);

                if (player1.IsDead())
                {
                    PrintWinner(player2);
                    break;
                }

                player2.Attack(player1);

                if (player2.IsDead())
                {
                    PrintWinner(player1);
                    break;
                }
            }
        }

        private void PrintWinner(Hero player1)
        {
            Console.WriteLine("Winner: "+player1.GetType().Name);
        }
    }
}
