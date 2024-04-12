using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaSemana3.Character_System;
using TareaSemana3.Item_System;

namespace TareaSemana3.Adventure_System
{
    internal class OptionEatFromInventory : Option
    {
        string itemName;
        int amount;
        Food[] food;

        public OptionEatFromInventory(string[] text, Chapter? nextChapter, string itemName, int amount) : base(text, nextChapter)
        {
            this.itemName = itemName;
            this.amount = amount;
            food = new Food[amount];
        }

        public override void Consequences()
        {
            for(int i = 0; i < food.Length; i++)
            {
                Console.WriteLine($"{StoryTeller.instance.player.Name} eats {food[i].name} and restores {food[i].Heal} health points");
                food[i].Consume(StoryTeller.instance.player);
                StoryTeller.instance.player.RemoveItem(food[i]);
            }
        }

        public override bool Requirement()
        {
            List<Item> inventoryFilteredByFood = StoryTeller.instance.player.GetInventory(new List<string>() { "consumable", "food" }, itemName);

            if (inventoryFilteredByFood.Count < amount) return false;

            for (int i = 0; i < amount; i++)
            {
                try
                {
                    food[i] = (Food)inventoryFilteredByFood[i];
                }

                catch 
                {
                    return false;
                }
            }

            return true;
        }
    }
}
