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
                    h.Tick();
                    if(h.hp <= 0)
                        Console.WriteLine("{0} dies.", h.name);
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
    }
}
