using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    public class Assasin : Hero
    {
        public Assasin(double health, double attack, double armor)
            : base(health, attack, armor)
        {
        }

        protected override double GetAttackPoints()
        {
            random = new Random();

            var percent = random.Next(1, 101);

            if (percent <= 30)
            {
                return this.AttackPoints * 3;
            }
            else
            {
                return base.GetAttackPoints();
            }
        }
    }
}
