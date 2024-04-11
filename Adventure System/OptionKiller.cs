using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3.Adventure_System
{
    internal class OptionKiller : Option
    {
        private Character entityToKill;

        public OptionKiller(string[] text, Chapter? nextChapter, Character entityToKill) : base(text, nextChapter)
        {
            this.entityToKill = entityToKill;
        }

        public override void Consequences()
        {
            entityToKill.Life(-int.MaxValue);
        }
    }
}
