using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3.Adventure_System
{
    internal class ChapterConditionIsAlive: Chapter
    {
        private Chapter? altChapter;
        private Character checkCharacter;

        public ChapterConditionIsAlive(string[] text, Chapter? nextChapter, Chapter? altChapter, Character checkCharacter) : base(text, nextChapter)
        {
            this.altChapter = nextChapter;
            this.checkCharacter = checkCharacter;
        }

        public override Chapter? GetNextChapter()
        {
            if(checkCharacter.IsAlive()) return base.GetNextChapter();
            
            return altChapter;
        }
    }
}
