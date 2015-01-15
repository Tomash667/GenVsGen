using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genvsgen
{
    class Monster : Unit
    {
        BaseMonster base_mon;

        public Monster(BaseMonster _base_mon)
        {
            base_mon = _base_mon;
            hp = hpmax = base_mon.hp;
            dmg_min = base_mon.dmg_min;
            dmg_max = base_mon.dmg_max;
        }
    }
}
