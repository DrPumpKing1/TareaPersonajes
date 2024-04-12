using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3.Adventure_System
{
    internal class ChapterAffectStats : Chapter
    {
        private int strengthDelta;
        private int dexterityDelta;

        public ChapterAffectStats(string[] text, Chapter? nextChapter, int strengthDelta, int dexterityDelta) : base(text, nextChapter)
        {
            this.strengthDelta = strengthDelta;
            this.dexterityDelta = dexterityDelta;
        }

        private void AffectPlayerStats()
        {
            StoryTeller.instance.player.AddStats(strengthDelta, dexterityDelta);
        }

        public override Chapter? GetNextChapter()
        {
            AffectPlayerStats();
            return base.GetNextChapter();
        }
    }
}
