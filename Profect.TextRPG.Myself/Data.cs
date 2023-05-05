using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Profect.TextRPG.Myself
{
    internal static class Data
    {
        public static bool[,] map;
        public static Player player;

        public static void Init()
        {

        }

        public static void SetPlayer(ConsoleKeyInfo input, string name)
        {
            switch (input.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    player = new Warrior(name);
                    break;
            }
        }

        public static void LoadLevel1()
        {
            map = Stage1.map;

            player.Pos = new Position(2, 2);
        }
    }
}
