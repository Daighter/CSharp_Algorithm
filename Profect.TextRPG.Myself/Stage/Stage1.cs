using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profect.TextRPG.Myself
{
    internal class Stage1
    {
        public static bool[,] map = new bool[,]
        {
            { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            { false,  true,  true,  true,  true,  true, false,  true,  true,  true,  true,  true,  true,  true, false },
            { false,  true,  true,  true,  true,  true, false,  true,  true,  true,  true, false, false,  true, false },
            { false,  true,  true,  true,  true,  true, false,  true,  true,  true,  true, false,  true,  true, false },
            { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true,  true, false },
            { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
            { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
            { false,  true,  true,  true, false, false, false, false,  true,  true,  true,  true,  true,  true, false },
            { false,  true,  true,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
            { false, false, false, false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
            { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
            { false,  true,  true, false, false, false,  true, false, false,  true,  true, false,  true,  true, false },
            { false,  true,  true,  true,  true, false,  true,  true, false, false, false, false,  true,  true, false },
            { false,  true,  true,  true,  true, false,  true,  true, false,  true,  true,  true,  true,  true, false },
            { false,  true,  true,  true,  true, false,  true,  true,  true,  true,  true,  true,  true,  true, false },
            { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
        };
    }
}
