using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3
{
    internal abstract class Equipment : Item
    {
        public Equipment(string name) : base(name) 
        {
            tags.Add("equipment");
        }
    }
}
