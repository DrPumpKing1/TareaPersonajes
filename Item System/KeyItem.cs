using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3.Item_System
{
    internal class KeyItem : Item
    {
        public KeyItem(string name) : base(name)
        {
            tags.Add("key");
        }

        public override Item Clone()
        {
            return new KeyItem(name);
        }
    }
}
