using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genvsgen
{
    class Hero : Unit
    {
        public override string Name { get { return name; } }

        public string name;
        public int gold, exp, exp_need;
        public bool in_city;

        public Hero()
        {
            name = NameGen.GetName();
            hp = hpmax = 50;
            dmg_min = 5;
            dmg_max = 15;
            gold = Utils.rnd.Next(10, 20);
            level = 5;
            exp_need = 5000;
            in_city = true;
        }

        public enum ThinkResult
        {
            GoToDungeon,
            GoToCity,
            Rest,
            ExploreDungeon
        };

        public ThinkResult Think()
        {
            if(in_city)
            {
                if(hp != hpmax)
                    return ThinkResult.Rest;
                else
                    return ThinkResult.GoToDungeon;
            }
            else
            {
                if(Hpp > 0.5f)
                    return ThinkResult.ExploreDungeon;
                else
                    return ThinkResult.GoToCity;
            }
        }

        public void Write()
        {
            Console.WriteLine("Name:{0} Lvl:{1} Exp:{2}/{3} Hp:{4}/{5} Dmg:{6}-{7} In city:{8}", name, level, exp, exp_need, hp, hpmax, dmg_min, dmg_max, in_city);
        }
    }
}
