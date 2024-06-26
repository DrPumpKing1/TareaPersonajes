﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaSemana3.Item_System;

namespace TareaSemana3
{
    internal abstract class Consumable : Item
    {
        public Consumable(string name) : base(name) 
        {
            tags.Add("consumable");
        }

        public abstract void Consume(Character character);
    }
}
