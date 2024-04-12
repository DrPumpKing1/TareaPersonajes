using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaSemana3.Item_System;

namespace TareaSemana3.Adventure_System
{
    internal class OptionDrinkPotionFromInventory : Option
    {
        string itemName;
        Potion potion;

        public OptionDrinkPotionFromInventory(string[] text, Chapter? nextChapter, string itemName) : base(text, nextChapter)
        {
            this.itemName = itemName;
        }

        public override void Consequences()
        {
            Console.WriteLine($"{StoryTeller.instance.player.Name} drinks {potion.name} and gains {potion.Strength} strength and {potion.Dexterity} dexterity");
            potion.Consume(StoryTeller.instance.player);
            StoryTeller.instance.player.RemoveItem(potion);
        }

        public override bool Requirement()
        {
            List<Item> inventoryFilteredByPotion = StoryTeller.instance.player.GetInventory(new List<string>() { "consumable", "potion" }, itemName);

            if (inventoryFilteredByPotion.Count <= 0) return false;

            try
            {
                potion = (Potion)inventoryFilteredByPotion[0];
            }

            catch
            {
                return false;
            }

            return true;
        }
    }
}
