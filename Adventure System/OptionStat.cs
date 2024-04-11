using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaSemana3.Character_System;

namespace TareaSemana3.Adventure_System
{
    internal class OptionStat : Option
    {
        public enum RequirementType
        {
            strength,
            health,
            dexterity
        }

        protected RequirementType requirementType;
        protected int requirementAmmount;

        public OptionStat(string[] text, Chapter? nextChapter, RequirementType requirementType, int requirementAmmount) : base(text, nextChapter)
        {
            this.requirementType = requirementType;
            this.requirementAmmount = requirementAmmount;
        }

        public override void Read()
        {
            string requirementFeedback;

            switch (requirementType)
            {
                case RequirementType.strength:
                    requirementFeedback = $" <STRENGTH:{requirementAmmount}> ";
                    break;

                case RequirementType.health:
                    requirementFeedback = $" <HEALTH:{requirementAmmount}> ";
                    break;

                case RequirementType.dexterity:
                    requirementFeedback = $" <DEXTERITY:{requirementAmmount}> ";
                    break;

                default:
                    requirementFeedback = string.Empty;
                    break;
            }

            Console.WriteLine("(" + number + ") " + requirementFeedback + text[0]);
        }

        public override bool Requirement()
        {
            switch (requirementType)
            {
                case RequirementType.strength:
                    return StoryTeller.instance.player.Strength >= requirementAmmount;

                case RequirementType.health:
                    return StoryTeller.instance.player.Health >= requirementAmmount;

                case RequirementType.dexterity:
                    return StoryTeller.instance.player.Dexterity >= requirementAmmount;

                default:
                    return false;
            }
        }
    }
}
