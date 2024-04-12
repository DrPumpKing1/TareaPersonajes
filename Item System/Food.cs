using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3.Item_System
{
    internal class Food : Consumable
    {
        private int healthRestore;
        public int Heal { get { return healthRestore; } }

        public Food(string name, int healthRestore) : base(name)
        {
            this.healthRestore = healthRestore;

            tags.Add("food");
        }

        public override Food Clone()
        {
            return new Food(this.name, this.healthRestore);
        }

        public override void Consume(Character character)
        {
            character.Life(healthRestore);
        }
    }
}
