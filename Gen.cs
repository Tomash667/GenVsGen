using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genvsgen
{
    class Gen
    {
        List<Hero> heroes = new List<Hero>();
        int turn = 1;

        public void Start()
        {
            for(int i=0; i<10; ++i)
            {
                Hero h = new Hero();
                heroes.Add(h);
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Turn {0}. Heroes {1}.", turn, heroes.Count);

                foreach(Hero h in heroes)
                {
                    switch (h.Think())
                    {
                        case Hero.ThinkResult.GoToCity:
                            Console.WriteLine("{0} goes to city.", h.name);
                            h.in_city = true;
                            break;
                        case Hero.ThinkResult.GoToDungeon:
                            Console.WriteLine("{0} goes to dungeon.", h.name);
                            h.in_city = false;
                            break;
                        case Hero.ThinkResult.Rest:
                            Console.WriteLine("{0} rest in city.", h.name);
                            h.hp += 10;
                            if (h.hp > h.hpmax)
                                h.hp = h.hpmax;
                            break;
                        case Hero.ThinkResult.ExploreDungeon:
                            {
                                int what = Utils.rnd.Next(4);
                                switch(what)
                                {
                                    case 0:
                                        Console.WriteLine("{0} wonders inside dungeon.", h.name);
                                        break;
                                    case 1:
                                        Console.WriteLine("{0} get hurt by trap.", h.name);
                                        h.hp -= Utils.rnd.Next(10, 40);
                                        if(h.hp <= 0)
                                            Console.WriteLine("{0} dies.", h.name);
                                        break;
                                    case 2:
                                    case 3:
                                        {
                                            BaseMonster base_mon = BaseMonster.Monsters[Utils.rnd.Next(BaseMonster.Monsters.Length)];
                                            Monster mon = new Monster(base_mon);
                                            Console.WriteLine("{0} encounters {1}.", h.Name, mon.Name);
                                            if (Combat.Fight(h, mon))
                                                AddExpFor(h, mon.level);
                                        }
                                        break;
                                }
                            }
                            break;
                    }
                }

                heroes.RemoveAll(x => x.hp <= 0);

                bool loop = true;
                while(loop)
                {
                    Console.WriteLine("i-unit info, x-exit");
                    switch(Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.I:
                            {
                                Console.WriteLine("Unit name: ");
                                string name = Console.ReadLine();
                                var hs = heroes.Where(x => x.name == name).ToArray();
                                if (hs.Length == 0)
                                    Console.WriteLine("No units with this name!");
                                else
                                {
                                    foreach (Hero h in hs)
                                        h.Write();
                                }
                            }
                            break;
                        case ConsoleKey.X:
                            return;
                        default:
                            loop = false;
                            break;
                    }
                }
                
                ++turn;
            }
        }

        public void AddExpFor(Hero hero, int level)
        {
            int exp = 1000 + 250 * (level - hero.level);
            if(exp > 0)
            {
                hero.exp += exp;
                while(hero.exp >= hero.exp_need)
                {
                    hero.exp -= hero.exp_need;
                    hero.exp_need += 1000;
                    hero.hp += 5;
                    hero.hpmax += 5;
                    hero.dmg_min++;
                    hero.dmg_max++;
                    hero.level++;
                    Console.WriteLine("{0} gained {1} level.", hero.Name, hero.level);
                }
            }
        }
    }
}
