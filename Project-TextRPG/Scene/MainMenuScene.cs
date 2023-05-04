using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class MainMenuScene : Scene
    {
        private static bool canParse = false;
        public MainMenuScene(Game game) : base(game)
        {
        }

        public static bool CanParse { set { canParse = value; } }

        // 메인메뉴 표현 구현
        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            
            if (!canParse)
            {
                sb.AppendLine("1. 게임시작");
                sb.AppendLine("2. 게임종료").AppendLine();
            }
            else
            {
                sb.AppendLine("1. 게임재시작");
                sb.AppendLine("2. 게임종료");
                sb.AppendLine("3. 계속하기").AppendLine();
            }
            sb.Append("메뉴를 선택하세요 : ");

            Console.Write(sb.ToString());
        }

        // 메인메뉴 갱신 구현
        public override void Update()
        {
            string input = Console.ReadLine();

            int command;
            if (!int.TryParse(input, out command))      // 입력값이 정수형인지 판단
            {
                Console.WriteLine("잘못 입력 하셨습니다.");
                Thread.Sleep(1000);
                return;
            }

            switch (command)
            {
                case 1:
                    game.GameStart();
                    break;
                case 2:
                    game.GameOver("게임을 종료했습니다.");
                    break;
                case 3:
                    if (canParse)
                        game.Map();
                    else
                    {
                        Console.WriteLine("잘못 입력 하셨습니다.");
                        Thread.Sleep(1000);
                    }
                    break;
                default:                                        // 입력값이 정수 중 1,2가 아닐 때
                    Console.WriteLine("잘못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}
