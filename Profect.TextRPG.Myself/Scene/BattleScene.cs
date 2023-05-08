using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profect.TextRPG.Myself
{
    internal class BattleScene : Scene
    {
        private Monster monster;                        // 상대 몬스터
        public BattleScene(Game game) : base(game) { }

        public override void Render()
        {
            Console.WriteLine();
            Console.WriteLine($"{monster.Name}    {monster.CurHp,3}/{monster.MaxHp,3}");
            Console.WriteLine();
            Console.WriteLine(monster.Image);
            Console.WriteLine();
            Console.WriteLine(Data.player.Image);
            Console.WriteLine();
            Console.WriteLine("플레이어");
            Console.Write($"HP : {Data.player.CurHp,3}/{Data.player.MaxHp,3}\t");
            Console.Write($"MP : {Data.player.CurMp,3}/{Data.player.MaxMp,3}");
            Console.WriteLine();
        }

        public override void Update()
        {
            Console.WriteLine("1. 공격하기");
            Console.WriteLine();
            Console.Write("명령을 입력하세요 : ");

            string input = Console.ReadLine();

            int index;
            if (!int.TryParse(input, out index))
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                return;
            }
            if (index < 1 || index > 1)
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                return;
            }
            else
                Data.player.Attack(monster);

            // 플레이어 공격 후
            if (monster.CurHp <= 0)
            {
                EndBattle();
                return;
            }

            // 몬스터 턴
            monster.Attack(Data.player);

            // 몬스터 공격 후
            if (Data.player.CurHp <= 0)
            {
                game.GameOver("몬스터에게 패배했습니다.");
                return;
            }
        }

        public void StartBattle(Monster monster)
        {
            this.monster = monster;
            Data.monsters.Remove(monster);

            Console.Clear();
            Console.WriteLine($"야생의 {monster.Name}이(가) 나타났다!");
            Thread.Sleep(1000);
        }

        public void EndBattle()
        {
            Console.Clear();
            Console.WriteLine("전투에서 승리했다!");

            Thread.Sleep(2000);
            game.Map();
        }
    }
}
