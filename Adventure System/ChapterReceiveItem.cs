using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaSemana3.Character_System;

namespace TareaSemana3.Adventure_System
{
    internal class ChapterReceiveItem : Chapter
    {
        private Item item;
        private int amount;

        public ChapterReceiveItem(string[] text, Chapter? nextChapter, Item item, int amount) : base(text, nextChapter)
        {
            this.item = item;
            this.amount = amount;
        }

        public override Chapter? GetNextChapter()
        {
            StoryTeller.instance.player.ReceiveItem(item, amount);
            return base.GetNextChapter();
        }
    }
}
