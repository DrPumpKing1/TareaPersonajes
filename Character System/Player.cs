using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaSemana3.Adventure_System;

namespace TareaSemana3.Character_System
{
    internal class Player : NeutralCharacter
    {
        private int strength;
        private int dexterity;
        private int money;

        public int Strength { get { return strength; } }
        public int Dexterity { get { return dexterity; } }

        public Player(int strength, int dexterity, string characterName, int maxHealth, Armor? armor, Weapon? weapon, List<Item> inventory) : base(characterName, maxHealth, armor, weapon, inventory)
        {
            this.strength = strength;
            this.dexterity = dexterity;

            money = 0;
        }

        public override int CalculateAttack()
        {
            int attack = strength;
            
            if(weapon == null) return attack;

            attack += weapon.GetWeaponDamage(strength, dexterity);
        
            return attack;
        }

        public override int CalculateArmor()
        {
            if (armor == null) return 0;

            return armor.GetArmorMitigation(strength);
        }

        protected override void Kill()
        {
            base.Kill();
            StoryTeller.instance?.PlayerDeath();
        }

        public void SetArmor(Armor armor)
        {
            this.armor = armor;
        }

        public void SetWeapon(Weapon weapon)
        {
            this.weapon = weapon;
        }

        public void GiveMoney(int amount)
        {
            money += amount;
            Console.WriteLine($"{StoryTeller.instance.player.Name} received {amount} dracmas");
        }

        public void SpendMoney(int cost)
        {
            money = Math.Max(money - cost, 0);
            Console.WriteLine($"{StoryTeller.instance.player.Name} spennt {cost} dracmas");
        }
    }
}
