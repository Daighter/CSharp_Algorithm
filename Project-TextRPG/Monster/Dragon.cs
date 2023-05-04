using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_TextRPG.Utilitys;

namespace Project_TextRPG
{
    public class Dragon : Monster
    {
        private Random random = new Random();
        private int moveTurn = 0;

        public Dragon()
        {
            name = "드래곤";
            icon = '◈';
            curHp = 100;
            maxHp = 100;
            ap = 15;
            dp = 10;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("####################");
            sb.AppendLine("#                  #");
            sb.AppendLine("#  (엄청난 드래곤)  #");
            sb.AppendLine("#  (텍스트 이미지)  #");
            sb.AppendLine("#                  #");
            sb.AppendLine("####################");
            image = sb.ToString();
        }

        public override void MoveAction()
        {
            if (moveTurn++ < 1)
            {
                return;
            }
            moveTurn = 0;

            List<Position> path;
            if (!AStar.PathFinding(in Data.map, new Position(pos.x, pos.y), new Position(Data.player.pos.x, Data.player.pos.y), out path))
                return;

            if (path[1].x == pos.x)
            {
                if (path[1].y == pos.y - 1)
                    Move(Direction.Up);
                else
                    Move(Direction.Down);
            }
            else
            {
                if (path[1].x == pos.x - 1)
                    Move(Direction.Left);
                else
                    Move(Direction.Right);
            }
        } 
    }
}