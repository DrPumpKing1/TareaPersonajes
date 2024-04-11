using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3
{
    interface IAttacker
    {
        int Attack { get; }

        void Damage(Character character);
    }
}
