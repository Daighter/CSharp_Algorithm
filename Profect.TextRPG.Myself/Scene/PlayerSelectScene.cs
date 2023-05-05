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

            sb.AppendLine("직업   : 번호                    직업 보너스 :              페널티 :");
            sb.AppendLine("전사   : 1                       추가 기초 체력, 방어력     낮은 마나");
            sb.AppendLine("암살자 : 2                       추가 공격력                낮은 방어력");
            sb.AppendLine("메인메뉴로 돌아가기 : ESC");
            sb.AppendLine();
            sb.Append("직업을 선택하세요 : ");

            Console.Write(sb.ToString());
        }

        // 이름 입력 안내 문구
        private void RenderSetName()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.Append("이름을 입력하세요 : ");

            Console.Write(sb.ToString());
        }

        // Scene 오버라이드
        public override void Update()
        {
            ConsoleKeyInfo input;           // 키 입력 변수
            ConsoleKeyInfo charactor;

            while (true)                                                    // 캐릭터 선택 OR ESC 아니면 반복
            {
                input = Console.ReadKey();      // 입력 받고

                if (input.Key == ConsoleKey.Escape ||                                       // 입력 키가 ESC나
                    input.Key == ConsoleKey.D1 || input.Key == ConsoleKey.NumPad1 ||        // 1번(넘패드 포함)일 때
                    input.Key == ConsoleKey.D2 || input.Key == ConsoleKey.NumPad2)          // 2번(넘패드 포함)일 때
                    break;                                                                      // 탈출

                Console.WriteLine();                                                        // 잘못 입력했을 때
                Console.WriteLine("잘못 입력 하셨습니다");
                Thread.Sleep(1000);

                Console.Clear();                                                            // 싹 지우고
                this.Render();                                                              // 선택지 출력
            }

            if (input.Key == ConsoleKey.Escape)                                         // ESC이면
            {
                Console.SetCursorPosition(0, 0);                                            // ESC 깨짐 방지
                Console.WriteLine("1");
                game.MainMenu();                                                            // 메인메뉴로
            }
            else if (input.Key == ConsoleKey.D1 || input.Key == ConsoleKey.NumPad1 ||   // 1번(넘패드 포함)일 때
                     input.Key == ConsoleKey.D2 || input.Key == ConsoleKey.NumPad2)     // 2번(넘패드 포함)일 때
            {
                charactor = input;
                RenderSetName();                                                            // 이름 입력 문구 출력
                string name = Console.ReadLine();                                               // 입력 받고
                Thread.Sleep(1000);

                Console.WriteLine();
                Console.WriteLine($"정말 '{name}'(으)로 하시겠습니까? ");
                Console.WriteLine("Next To Press Enter.");
                Console.WriteLine("Cancel To Press ESC.");

                while (true)
                {
                    input = Console.ReadKey();

                    if (input.Key == ConsoleKey.Enter ||                                   // 입력 키가 ESC나
                        input.Key == ConsoleKey.Escape)
                        break;
                }

                if (input.Key == ConsoleKey.Enter)
                {
                    Data.SetPlayer(charactor, name);
                    game.GameStart();
                }
                else if (input.Key == ConsoleKey.Escape)
                {
                    Console.Clear();                                                        // 싹 지우고
                    this.Render();                                                          // 선택지 출력
                }
            }
        }
    }
}
