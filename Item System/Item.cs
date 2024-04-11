using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3
{
    internal abstract class Item
    {
        public List<string> tags;

        public string name;

        public Item(string name)
        {
            this.name = name;
            tags = new List<string>();
        }
    }
}
