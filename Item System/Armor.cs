using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3
{
    internal abstract class Armor : Equipment
    {
        public Armor(string name) : base(name)
        {
            tags.Add("armor");
        }

        public abstract int GetArmorMitigation(int strength);
    }
}
