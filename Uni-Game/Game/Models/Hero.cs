using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    public abstract class Hero
    {
        protected Random random;
        public double HealthPoints { get; protected set; }
        public double AttackPoints { get; protected set; }
        public double ArmorPoints { get; protected set; }

        protected Hero(double health, double attack, double armor)
        {
            this.HealthPoints = health;
            this.AttackPoints = attack;
            this.ArmorPoints = armor;
        }

        public void Attack(Hero enemy)
        {
            var attackPoints = GetAttackPoints();
            enemy.Defend(attackPoints);
        }

        protected virtual double GetAttackPoints()
        {
            random = new Random();
            return random.Next(80, 121) / 100.0 * this.AttackPoints;
        }

        private void Defend(double attackPoints)
        {
            random = new Random();
            var armorPoints = random.Next(80, 121) / 100.0 * this.ArmorPoints;

            attackPoints -= armorPoints;

            if (attackPoints<=0)
            {
                return;
            }
            else
            {
                ReduceHealth(attackPoints);
            }
        }

        protected virtual void ReduceHealth(double attackPoints)
        {
            this.HealthPoints -= attackPoints;
        }

        public bool IsDead()
        {
            return this.HealthPoints <= 0;
        }
    }
}
