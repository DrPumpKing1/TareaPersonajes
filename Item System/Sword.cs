using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3.Item_System
{
    internal class Sword : Weapon
    {
        private int baseAttack;
        private float strengthMulipliter;
        private float dexterityMultiplier;

        public Sword(string name, int baseAttack, float stregthMultiplier, float dexterityMultiplier) : base(name)
        {
            this.baseAttack = baseAttack;
            this.strengthMulipliter = stregthMultiplier;
            this.dexterityMultiplier = dexterityMultiplier;
        }

        public override int GetWeaponDamage(int strength, int dexterity)
        {
            int strengthScaling = (int) Math.Floor((float)strength * strengthMulipliter);
            int dexterityScaling = (int) Math.Floor((float)dexterity * dexterityMultiplier);

            return baseAttack + strengthScaling + dexterityScaling;
        }
    }
}
