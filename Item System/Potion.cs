using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaSemana3.Adventure_System;

namespace TareaSemana3.Item_System
{
    internal class Potion : Consumable
    {
        private int strengthDelta;
        private int dexterityDelta;

        public int Strength { get { return strengthDelta; } }
        public int Dexterity { get { return dexterityDelta; } }

        public Potion(string name, int strengthDelta, int dexterityDelta) : base(name)
        {
            this.strengthDelta = strengthDelta;
            this.dexterityDelta = dexterityDelta;

            tags.Add("potion");
        }

        public override Potion Clone()
        {
            return new Potion(name, strengthDelta, dexterityDelta);
        }

        public override void Consume(Character character)
        {
            if (character != StoryTeller.instance.player) return;

            StoryTeller.instance.player.AddStats(strengthDelta, dexterityDelta);
        }
    }
}
