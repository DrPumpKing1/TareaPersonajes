using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3
{
    internal class Character : IHealth
    {
        protected string characterName;
        protected int maxHealth;
        protected int health;

        public string Name { get { return characterName; } }
        public int Health { get { return health; } }

        public Character(string characterName, int maxHealth)
        {
            this.characterName = characterName;
            this.maxHealth = maxHealth;
            this.health = maxHealth;
        }

        protected virtual void Kill()
        {
            Console.WriteLine($"{characterName} died!");
        }

        public virtual void Life(int life)
        {
            health = Math.Clamp(health + life, 0, maxHealth);

            if (health > 0) return;

            Kill();
        }

        public virtual bool IsAlive()
        {
            return health > 0;
        }
    }
}
