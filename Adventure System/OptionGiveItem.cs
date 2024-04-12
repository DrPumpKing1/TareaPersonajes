using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3.Adventure_System
{
    internal class OptionGiveItem : Option
    {
        private string itemName;

        private Item item;

        public OptionGiveItem(string[] text, Chapter? nextChapter, string itemName) : base(text, nextChapter)
        {
            this.itemName = itemName;
        }

        public override void Read()
        {
            Console.WriteLine($"({number}) <Give {itemName}> {text[0]}");
        }

        public override void Consequences()
        {
            StoryTeller.instance.player.RemoveItem(item);
        }

        public override bool Requirement()
        {
            List<Item> items = StoryTeller.instance.player.GetInventory(new List<string>(), itemName);

            if (items.Count <= 0) return false;

            item = items[0];

            return true;
        }
    }
}
