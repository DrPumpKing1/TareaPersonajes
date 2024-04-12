using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3
{
    internal abstract class NeutralCharacter : Character, IAttacker, IArmored
    {
        public int Attack { get => CalculateAttack(); }

        public int Armor { get => CalculateArmor(); }

        public List<Item> inventory;

        public Armor? armor;
        public Weapon? weapon;

        protected NeutralCharacter(string characterName, int maxHealth, Armor? armor, Weapon? weapon, List<Item> inventory) : base(characterName, maxHealth)
        {
            this.weapon = weapon;
            this.armor = armor;
            this.inventory = inventory;
        }

        public override void Life(int life)
        {
            if(life < 0)
            {
                int mitigation = CalculateArmor();
                base.Life(Math.Min(life + mitigation, 0));
                return;
            }

            base.Life(life);
        }

        public void Damage(Character character)
        {
            character.Life(-Attack);
        }

        public abstract int CalculateAttack();

        public abstract int CalculateArmor();

        public Weapon? GetWeapon()
        {
            return weapon;
        }

        public Armor? GetArmor()
        {
            return armor;
        }

        public List<Item> GetInventory()
        {
            return inventory;
        }

        public List<Item> GetInventory(List<string> filterTags)
        {
            return inventory.FindAll(item => {
                bool valid = true;
                filterTags.ForEach(itemTag =>
                {
                    valid &= item.tags.Contains(itemTag);
                });
                return valid;
            });
        }

        public List<Item> GetInventory(List<string> filterTags, string name)
        {
            return inventory.FindAll(item => {
                bool valid = true;
                filterTags.ForEach(itemTag =>
                {
                    valid &= item.tags.Contains(itemTag);
                });
                valid &= item.name == name;
                return valid;
            });
        }
    }
}
