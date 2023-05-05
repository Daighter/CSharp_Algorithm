using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profect.TextRPG.Myself
{
    internal class MainMenuScene : Scene
    {
        private bool canParse = false;                  // 일시정지 (메인메뉴 이어하기 선택지 구분용)

        public MainMenuScene(Game game) : base(game)
        {

        }

        // Scene 오버라이드
        public override void Render()
        {
            StringBuilder sb = new StringBuilder();     // 스트링 빌더

            if (!canParse)                              // 일시정지 상태가 아니면
            {
                sb.AppendLine("1. 게임시작");
                sb.AppendLine("0. 게임종료").AppendLine();
            }
            else
            {
                sb.AppendLine("1. 처음부터 재시작");
                sb.AppendLine("2. 이어하기");
                sb.AppendLine("0. 게임종료").AppendLine();
            }
            sb.Append("메뉴를 선택하세요 : ");

            Console.Write(sb.ToString());
        }

        // Scene 오버라이드
        public override void Update()
        {
            string input = Console.ReadLine();

            int command;
            if (!int.TryParse(input, out command))              // 입력 값이 정수형이 아니면
            {
                Console.WriteLine("잘못 입력 하셨습니다.");
                Thread.Sleep(1000);
                return;
            }

            switch (command)                                    // 정수형이면
            {
                case 1:
                    game.PlayerSelect();
                    break;
                case 2:
                    if (canParse)                                       // 일시정지 상태일 때만
                        game.Map();                                         // 맵으로 이동
                    else                                                // 아니면 선택지 없음            
                    {
                        Console.WriteLine("잘못 입력 하셨습니다");
                        Thread.Sleep(1000);
                    }
                    break;
                case 0:
                    game.GameOver();
                    break;
                default:                                            // 0, 1, 2가 아니면
                    Console.WriteLine("잘못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    break;

            }
        }
    }
}
