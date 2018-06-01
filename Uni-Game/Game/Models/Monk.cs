using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    public class Monk : Hero
    {
        public Monk(double health, double attack, double armor) 
            : base(health, attack, armor)
        {
        }

        protected override void ReduceHealth(double attackPoints)
        {
            random = new Random();

            var percent = random.Next(1, 101);

            if (percent <= 30)
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
