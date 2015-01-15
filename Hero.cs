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
        public int gold;
        public bool in_city;

        public Hero()
        {
            name = NameGen.GetName();
            hp = hpmax = 50;
            dmg_min = 5;
            dmg_max = 15;
            gold = Utils.rnd.Next(10, 20);
            in_city = true;
        }

        float GetHpp()
        {
            return ((float)hp)/hpmax;
        }

        enum ThinkResult
        {
            GoToDungeon,
            GoToCity,
            Rest,
            ExploreDungeon
        };

        ThinkResult Think()
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
                if(GetHpp() > 0.5f)
                    return ThinkResult.ExploreDungeon;
                else
                    return ThinkResult.GoToCity;
            }
        }

        public void Tick()
        {
            switch(Think())
            {
                case ThinkResult.GoToCity:
                    Console.WriteLine("{0} goes to city.", name);
                    in_city = true;
                    break;
                case ThinkResult.GoToDungeon:
                    Console.WriteLine("{0} goes to dungeon.", name);
                    in_city = false;
                    break;
                case ThinkResult.Rest:
                    Console.WriteLine("{0} rest in city.", name);
                    hp += 10;
                    if(hp > hpmax)
                        hp = hpmax;
                    break;
                case ThinkResult.ExploreDungeon:
                    if(Utils.rnd.Next(2) == 0)
                        Console.WriteLine("{0} wonders inside dungeon.", name);
                    else
                    {
                        Console.WriteLine("{0} get hurt by trap.", name);
                        hp -= Utils.rnd.Next(10, 40);
                    }
                    break;
            }
        }

        public void Write()
        {
            Console.WriteLine("Name:{0} Hp:{1}/{2} In city:{3}", name, hp, hpmax, in_city);
        }
    }
}
