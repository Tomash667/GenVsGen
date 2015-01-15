using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genvsgen
{
    abstract class Unit
    {
        public abstract string Name { get; }
        public float Hpp { get { return ((float)hp) / hpmax; } }
        public int hp, hpmax, dmg_min, dmg_max, level;
    }
}
