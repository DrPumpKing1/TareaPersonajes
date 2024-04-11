using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaSemana3.Character_System;

namespace TareaSemana3.Adventure_System
{
    internal class OptionStatDamaging : OptionStat
    {
        protected int damage;

        public OptionStatDamaging(string[] text, Chapter nextChapter, RequirementType requirementType, int requirementAmmount, int damage) : base( text, nextChapter, requirementType, requirementAmmount)
        {
            this.damage = damage;
        }

        public override void Consequences()
        {
            Console.WriteLine($"{StoryTeller.instance.player.Name}'s been damaged");
            StoryTeller.instance.player.Life(-damage);
        }
    }
}
