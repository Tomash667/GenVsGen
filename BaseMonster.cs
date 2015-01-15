using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genvsgen
{
    class BaseMonster
    {
        public string name;
        public int hp, dmg_min, dmg_max;

        BaseMonster(string _name, int _hp, int _dmg_min, int _dmg_max)
        {
            name = _name;
            hp = _hp;
            dmg_min = _dmg_min;
            dmg_max = _dmg_max;
        }

        static public BaseMonster[] Monsters =
        {
            new BaseMonster("rat", 10, 1, 4),
            new BaseMonster("goblin", 20, 2, 6),
            new BaseMonster("wolf", 30, 3, 8),
            new BaseMonster("orc", 50, 5, 15)
        };
    }
}
