using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profect.TextRPG.Myself
{
    internal class MapScene : Scene
    {
        public MapScene(Game game) : base(game) { } 

        // Scene 오버라이드
        public override void Render()
        {
            PrintMap();                         // 맵 출력
            PrintMenu();                        // 인터페이스 출력
            PrintInfo();                        // 현재 정보 출력
        }

        // Scene 오버라이드
        public override void Update()
        {
            ConsoleKeyInfo input;

            while (true)
            {
                input = Console.ReadKey();

                if (input.Key == ConsoleKey.UpArrow ||
                    input.Key == ConsoleKey.DownArrow ||
                    input.Key == ConsoleKey.LeftArrow ||
                    input.Key == ConsoleKey.RightArrow)
                    break;
            }

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    Data.player.Move(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    Data.player.Move(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    Data.player.Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Data.player.Move(Direction.Right);
                    break;
            }
        }

        // 맵 출력
        private void PrintMap()
        {
            StringBuilder sb = new StringBuilder();             // 스트링 빌더
            Console.ForegroundColor = ConsoleColor.White;       // 커서 색 : 화이트
            for (int y = 0; y < Data.map.GetLength(0); y++)     // y행 반복
            {
                for (int x = 0; x < Data.map.GetLength(1); x++)     // x열 반복
                {
                    if (Data.map[y, x])                                 // 맵이 bool형이므로 true면
                        sb.Append('　');                                     // '　' 출력
                    else                                                // false면
                        sb.Append('▩');                                     // '▩' 출력
                }
                sb.AppendLine();                                    // 출바꿈
            }
            Console.WriteLine(sb.ToString());

            // 플레이어 출력
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(Data.player.Pos.x * 2, Data.player.Pos.y);
            Console.Write(Data.player.Icon);
        }

        // 인터페이스 출력
        private void PrintMenu()
        {
            
        }

        // 현재 정보 출력
        private void PrintInfo()
        {

        }

        // 맵 할당
        public void GenerateMap()
        {
            Data.LoadLevel1();
        }
    }
}
