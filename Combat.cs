using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genvsgen
{
    class Combat
    {
        public static bool Fight(Unit u1, Unit u2)
        {
            Unit active = Utils.rnd.Next(2) == 0 ? u1 : u2;
            Unit enemy = (active == u1 ? u2 : u1);

            //int round = 

            while(true)
            {
                if (Utils.rnd.Next(1, 20) > 10)
                {
                    int dmg = Utils.rnd.Next(active.dmg_min, active.dmg_max);
                    enemy.hp -= dmg;
                    string s = string.Format("{0} attacked {1} for {2} dmg.", active.Name, enemy.Name, dmg);
                    if (enemy.hp > 0)
                    {
                        if (enemy.Hpp < 0.25f)
                            s += string.Format(" {0} is very hurt.", enemy.Name);
                        else if (enemy.Hpp < 0.5f)
                            s += string.Format(" {0} is hurt.", enemy.Name);
                        else if (enemy.Hpp < 0.75f)
                            s += string.Format(" {0} is lightly hurt.", enemy.Name);
                    }
                    else
                        s += string.Format(" {0} dies.", enemy.Name);
                    Console.WriteLine(s);

                    if (enemy.hp <= 0)
                        return (active == u1);
                }
                else
                    Console.WriteLine("{0} tries to attack {1} but misses.", active.Name, enemy.Name);

                Unit tmp = active;
                active = enemy;
                enemy = tmp;
            }
        }
    }
}
