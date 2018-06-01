using Game.Models;
using System;

namespace Game.App
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var knight = new Knight(100,20,10);
            var assasin = new Assasin(800,10,5);

            var engine = new GameEngine(knight, assasin);
            engine.Run();
        }
    }
}
