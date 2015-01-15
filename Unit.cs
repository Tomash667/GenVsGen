using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genvsgen
{
    class Unit
    {
        virtual public string Name { get; }
        public int hp, hpmax, dmg_min, dmg_max;
    }
}
