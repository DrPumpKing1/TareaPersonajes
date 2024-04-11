using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3.Character_System
{
    internal class Enemy : NeutralCharacter
    {
        private int damage;
        private int mitigation;
        private int lootMoney;

        public int Damage { get { return damage; } }
        public int Mitigation { get { return mitigation; } }
        public int Loot {  get { return lootMoney; } }

        public Enemy(int damage, int mitigation, string characterName, int lootMoney, int maxHealth, Armor? armor, Weapon? weapon, List<Item> inventory) : base(characterName, maxHealth, armor, weapon, inventory)
        {
            this.damage = damage;
            this.mitigation = mitigation;
            this.lootMoney = lootMoney;
        }

        public override int CalculateAttack()
        {
            int attack = damage;

            if (weapon == null) return attack;

            attack += weapon.GetWeaponDamage(0, 0);

            return attack;
        }

        public override int CalculateArmor()
        {
            if (armor == null) return mitigation;

            return mitigation + armor.GetArmorMitigation(0);
        }
    }
}
