using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profect.TextRPG.Myself
{
    internal class Dragon : Monster
    {
        public Dragon()
        {
            name = "드래곤";
            icon = '※';
            curHp = 100;
            maxHp = 100;
            ap = 30;
            dp = 15;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("#####################");
            sb.AppendLine("#                   #");
            sb.AppendLine("#  (엄청난 드래곤)  #");
            sb.AppendLine("#  (텍스트 이미지)  #");
            sb.AppendLine("#                   #");
            sb.AppendLine("#####################");
            image = sb.ToString();
        }

        private int moveTurn = 1;
        public override void MoveAction()
        {
            Position player = new Position(Data.player.Pos.x, Data.player.Pos.y);   // 플레이어 좌표
            List<Position> path;                                                    // 최단거리 리스트

            if (AStar.Heuristic(pos, player) <= 30)                                 // 플레이어가 반경 2칸 안에 들어오면
            {
                if (!AStar.PathFinding(in Data.map, pos, player, out path))             // 갈이 막혔으면 함수 탈출
                    return;

                switch ((path[1].x - this.pos.x) + (path[1].y - this.pos.y))            // 다음최단좌표의 두 좌표값의 합이
                {
                    case 2:                                                                 // 제 1사분면
                        Move(Direction.RightDown);
                        break;
                    case -2:                                                                // 제 3사분면
                        Move(Direction.LeftUp);
                        break;
                    case 1:                                                                 // 양의 X or Y 축
                        if (path[1].x == this.pos.x)                                            // x좌표가 같으면
                            Move(Direction.Down);                                                     // 상
                        else                                                                    // x좌표가 다르면
                            Move(Direction.Right);                                                  // 우
                        break;
                    case 0:                                                                 // 제 2 or 3사분면
                        if (path[1].x == this.pos.x - 1)                                        // 다음 최단x좌표가 왼쪽이면
                            Move(Direction.LeftDown);                                                 // 좌상 
                        else                                                                    // 다음 최단x좌표가 오른쪽이면
                            Move(Direction.RightUp);                                              // 우하
                        break;
                    case -1:                                                                // 음의 X or Y 축
                        if (path[1].x == this.pos.x)                                            // x좌표가 같으면
                            Move(Direction.Up);                                                   // 하
                        else                                                                     // x좌표가 다르면
                            Move(Direction.Left);                                                   // 좌
                        break;
                        default: break;
                }
            }
        }
    }
}
