using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_TextRPG.Utilitys;

namespace Project_TextRPG
{
    internal class Zomble : Monster
    {
        private Random random = new Random();
        private int moveTurn = 0;
        public Zomble()
        {
            name = "좀비";
            icon = '※';
            curHp = 50;
            maxHp = 50;
            ap = 5;
            dp = 3;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("#####################");
            sb.AppendLine("#                   #");
            sb.AppendLine("#   (엄청난 좀비)   #");
            sb.AppendLine("#  (텍스트 이미지)  #");
            sb.AppendLine("#                   #");
            sb.AppendLine("#####################");
            image = sb.ToString();
        }

        public override void MoveAction()
        {
            if (moveTurn++ < 2)
            {
                return;
            }
            moveTurn = 0;

            List<Position> path;
            if (AStar.Heuristic(new Position(pos.x, pos.y), new Position(Data.player.pos.x, Data.player.pos.y)) < 100)
            {
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
            else
            {
                switch (random.Next(0, 4))
                {
                    case 0:
                        Move(Direction.Up);
                        break;
                    case 1:
                        Move(Direction.Down);
                        break;
                    case 2:
                        Move(Direction.Left);
                        break;
                    case 3:
                        Move(Direction.Right);
                        break;
                }
            }
        }
    }
}
