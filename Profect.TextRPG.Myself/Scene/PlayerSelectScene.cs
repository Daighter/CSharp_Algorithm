using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profect.TextRPG.Myself
{
    internal class PlayerSelectScene : Scene
    {
        public PlayerSelectScene(Game game) : base(game) { }

        // Scene 오버라이드
        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("직업 : 번호                직업 보너스 :              페널티 :");
            sb.AppendLine("전사 : 1                   추가 기초 체력, 방어력     낮은 마나");
            sb.AppendLine();
            sb.Append("직업을 선택하세요 : ");

            Console.Write(sb.ToString());
        }

        // Scene 오버라이드
        public override void Update()
        {
            ConsoleKeyInfo input;           // 키 입력 변수

            while (true)
            {
                input = Console.ReadKey();      // 입력 받고

                if (input.Key == ConsoleKey.Escape ||                               // 입력 키가 ESC나
                    input.Key == ConsoleKey.D1 || input.Key == ConsoleKey.NumPad1)  // 1번(넘패드 포함)일 때
                    break;                                                              // 아니면 반복
                Console.WriteLine();
                Console.WriteLine("잘못 입력 하셨습니다");
                Thread.Sleep(1000);

                Console.Clear();
                this.Render();

            }

            if (input.Key == ConsoleKey.Escape)
            {
                game.MainMenu();
            }
            else if (input.Key == ConsoleKey.D1 || input.Key == ConsoleKey.NumPad1)
                game.GameStart();
        }
    }
}
