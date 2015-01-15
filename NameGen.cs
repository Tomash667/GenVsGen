using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genvsgen
{
    class NameGen
    {
        static string[] pre = 
        {
            "To",
            "Tom",
            "Ar",
            "Cris",
            "Rad",
            "Me",
            "Da",
            "Pe",
            "Sa"
        };

        static string[] sub =
        {
            "ma",
            "to",
            "mu"
        };

        static string[] post =
        {
            "mash",
            "shu",
            "pher",
            "nold",
            "sun",
            "ow",
            "vid",
            "ter",
            "el"
        };

        static public string GetName()
        {
            string s = pre[Utils.rnd.Next(pre.Length)];

            if (Utils.rnd.Next(2) == 0)
                s += sub[Utils.rnd.Next(sub.Length)];

            s += post[Utils.rnd.Next(post.Length)];
            return s;
        }
    }
}
