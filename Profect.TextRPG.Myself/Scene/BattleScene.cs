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
            string input = Console.ReadLine();
        }

        public void StartBattle(Monster monster)
        {
            this.monster = monster;
            Data.monsters.Remove(monster);

            Console.Clear();
            Console.WriteLine($"야생의 {monster.Name}이(가) 나타났다!");
            Thread.Sleep(1000);
        }
    }
}
