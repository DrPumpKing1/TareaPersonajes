using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3
{
    internal abstract class Weapon : Equipment
    {
        public Weapon(string name) : base(name) 
        {
            tags.Add("weapon");
        }

        public abstract int GetWeaponDamage(int strength, int dexterity);
    }
}
