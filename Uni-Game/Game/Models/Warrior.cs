using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    public class Warrior : Hero
    {
        public Warrior(double health, double attack, double armor)
            : base(health, attack, armor)
        {
        }
    }
}
