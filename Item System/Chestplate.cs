using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3.Item_System
{
    internal class Chestplate : Armor
    {
        private int baseMitigation;
        private float strengthMulipliter;

        public Chestplate(string name, int baseMitigation, float stregthMultiplier) : base(name)
        {
            this.baseMitigation = baseMitigation;
            this.strengthMulipliter = stregthMultiplier;
        }

        public override Chestplate Clone()
        {
            return new Chestplate(this.name, this.baseMitigation, this.strengthMulipliter);
        }

        public override int GetArmorMitigation(int strength)
        {
            int scaling = (int)Math.Floor((float)strength * strengthMulipliter);

            return baseMitigation + scaling;
        }
    }
}
