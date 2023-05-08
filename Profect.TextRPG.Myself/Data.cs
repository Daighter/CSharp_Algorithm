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
        public static List<Monster> monsters;

        public static void Init()
        {
            monsters = new List<Monster>();
        }

        public static void SetPlayer(ConsoleKeyInfo input, string name)
        {
            switch (input.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    player = new Warrior(name);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    player = new Assassin(name);
                    break;
            }
        }

        public static void LoadLevel1()
        {
            map = Stage1.map;

            player.Pos = new Position(2, 2);

            monsters.Clear();                   // 리스트<몬스터> 초기화

            Slime slime1 = new Slime();         // 슬라임 생성
            slime1.Pos = new Position(3, 5);    // 슬라임 좌표
            monsters.Add(slime1);               // 리스트<몬스터>에 추가

            Dragon dragon1 = new Dragon();      // 드래곤 생성
            dragon1.Pos = new Position(3, 10);  // 드래곤 좌표
            monsters.Add(dragon1);              // 리스트<몬스터>에 추가
        }

        // 매개변수 좌표에 몬스터가 없으면 true
        public static bool IsObjectInPos(Position pos)
        {
            return MonsterInPos(pos) == null;
        }

        // 매개변수 자리에 몬스터가 있으면 몬스터 반환
        public static Monster MonsterInPos(Position pos)
        {
            foreach (Monster monster in monsters)           // 모든 리스트<몬스터> 검사
            {
                if (monster.Pos.x == pos.x &&                   // 몬스터의 좌표와 같으면
                    monster.Pos.y == pos.y)
                    return monster;                                 // 몬스터 반환
            }
            return null;                                    // 없으면 null 반환
        }
    }
}
