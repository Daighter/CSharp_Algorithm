using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Project_TextRPG
{
    public class Game
    {
        private bool running = true;

        private Scene curScene;
        private MainMenuScene mainMenuScene;
        private MapScene mapScene;
        private InventoryScene inventoryScene;
        private BattleScene battleScene;

        public void Run()
        {
            // 초기화
            Init();

            // 게임 루프
            while (running)
            {
                // 표현
                Render();
                // 갱신
                Update();
            }

            // 마무리
            Release();
        }

        private void Init()
        {
            //Console.CursorVisible = false;

            Data.Init();
            mainMenuScene = new MainMenuScene(this);
            mapScene = new MapScene(this);
            inventoryScene = new InventoryScene(this);
            battleScene = new BattleScene(this);

            curScene = mainMenuScene;
        }

        private void Render()
        {
            Console.Clear();
            curScene.Render();
        }

        private void Update()
        {
            curScene.Update();
        }

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

        private void Release()
        {

        }

        public void MainMenu()
        {
            curScene = mainMenuScene;
        }

        public void Map()
        {
            curScene = mapScene;
        }

        public void Battle(Monster monster)
        {
            curScene = battleScene;
            battleScene.StartBattle(monster);
        }

        public void Inventory()
        {
            curScene = inventoryScene;
        }

        public void GameStart()
        {
            curScene = mapScene;
            mapScene.GenerateMap();
        }
    }
}