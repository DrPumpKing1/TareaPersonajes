using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaSemana3.Item_System;

namespace TareaSemana3
{
    internal abstract class Item: ICloneable<Item>
    {
        public List<string> tags;

        public string name;

        public Item(string name)
        {
            this.name = name;
            tags = new List<string>();
        }

        public abstract Item Clone();
    }
}
