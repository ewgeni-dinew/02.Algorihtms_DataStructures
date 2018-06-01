using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    public class Knight : Hero
    {
        public Knight(double health, double attack, double armor) 
            : base(health, attack, armor)
        {
        }

        protected override double GetAttackPoints()
        {
            random = new Random();

            var percent = random.Next(1, 101);

            if (percent <= 10)
            {
                return this.AttackPoints * 2;
            }
            else
            {
                return base.GetAttackPoints();
            }
        }

        protected override void ReduceHealth(double attackPoints)
        {
            random = new Random();

            var percent = random.Next(1, 101);

            if (percent <= 20)
            {
                return;
            }
            else
            {
                base.ReduceHealth(attackPoints);
            }
        }
    }
}
