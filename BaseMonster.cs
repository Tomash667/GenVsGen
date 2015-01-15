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
        public int hp, dmg_min, dmg_max, level;

        BaseMonster(string _name, int _hp, int _dmg_min, int _dmg_max, int _level)
        {
            name = _name;
            hp = _hp;
            dmg_min = _dmg_min;
            dmg_max = _dmg_max;
            level = _level;
        }

        static public BaseMonster[] Monsters =
        {
            new BaseMonster("Rat", 10, 1, 4, 1),
            new BaseMonster("Goblin", 20, 2, 6, 2),
            new BaseMonster("Wolf", 30, 3, 8, 3),
            new BaseMonster("Orc", 50, 5, 15, 5)
        };
    }
}
