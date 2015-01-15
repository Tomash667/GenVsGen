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
            Unit[] u = new Unit[] { u1, u2 };
            int active = Utils.rnd.Next(2);
            int enemy = (active == 0 ? 1 : 0);

            //int round = 

            while(true)
            {


                int tmp = active;
                active = enemy;
                enemy = tmp;
            }

            return false;
        }
    }
}
