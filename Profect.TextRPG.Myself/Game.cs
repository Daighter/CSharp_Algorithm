using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Profect.TextRPG.Myself
{
    internal class Game
    {
        private bool running = true;

        private Scene curScene;
        private MainMenuScene mainMenuScene;
        private MapScene mapScene;

        public void Run()
        {
            Init();                 // 초기화

            while (running)         // 실행 후 반복
            {
                Render();               // 출력

                Update();               // 갱신
            }

            Release();              // 마무리
        }

        // 게임 초기화
        private void Init()
        {
            Data.Init();
            mainMenuScene = new MainMenuScene(this);
            mapScene = new MapScene(this);

            curScene = mainMenuScene;
        }

        // 게임 출력
        private void Render()
        {
            Console.Clear();
            curScene.Render();
        }

        // 게임 갱신
        private void Update()
        {
            curScene.Update();
        }

        // 게임 마무리
        private void Release()
        {

        }

        // 게임 시작
        public void GameStart()
        {
            curScene = mapScene;
            mapScene.GenerateMap();
        }

        // 맵으로 씬 이동
        public void Map()
        {
            curScene = mapScene;
        }

        // 게임 종료
        public void GameOver()
        {
            Console.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("   ***    *   *   * *****       ***  *   * ***** ****   ");
            sb.AppendLine("  *      * *  ** ** *          *   * *   * *     *   *  ");
            sb.AppendLine("  * *** ***** * * * *****      *   * *   * ***** ****   ");
            sb.AppendLine("  *   * *   * *   * *          *   *  * *  *     *  *   ");
            sb.AppendLine("   ***  *   * *   * *****       ***    *   ***** *   *  ");
            sb.AppendLine();

            sb.AppendLine();
            sb.AppendLine("다시 하시겠습니까?");
            sb.AppendLine("다시 시작 : 1");
            sb.AppendLine("종료      : 0");

            Console.WriteLine(sb.ToString());

            string input = Console.ReadLine();

            int command;
            if (!int.TryParse(input, out command))
            {
                Console.WriteLine("잘못 입력 하셨습니다.");
                Thread.Sleep(1000);
                return;
            }
            
            switch (command)
            {
                case 1:
                    this.Run();
                    break;
                case 0:
                    running = false;
                    break;
                default:
                    Console.WriteLine("잘못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    break;
            }
            
        }
    }
}
