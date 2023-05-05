using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profect.TextRPG.Myself
{
    internal class Game
    {
        private bool running = true;

        private Scene curScene;
        private MainMenuScene mainMenuScene;

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
            mainMenuScene = new MainMenuScene(this);

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
            Console.WriteLine("게임 시작");
        }

        // 맵으로 씬 이동
        public void Map()
        {
            Console.WriteLine("맵 이동");
        }

        // 게임 종료
        public void GameOver(string text = "")
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
            sb.Append(text);

            Console.WriteLine(sb.ToString());

            running = false;
        }
    }
}
