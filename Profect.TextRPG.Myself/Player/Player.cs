using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Profect.TextRPG.Myself
{
    internal abstract class Player
    {
        protected string name;
        protected string job;
        protected string image;
        protected char icon = '★';
        protected Position pos;
        protected int maxHp;
        protected int curHp;
        protected int ap;
        protected int dp;
        protected int maxMp;
        protected int curMp;

        public Player(string name)
        {
            this.name = name;
            this.maxHp = 100;
            this.curHp = maxHp;
            this.ap = 10;
            this.dp = 5;
            this.maxMp = 100;
            this.curMp = maxMp;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("####################");
            sb.AppendLine("#                  #");
            sb.AppendLine("# 　( 플레이어 )　 #");
            sb.AppendLine("#  (텍스트이미지)  #");
            sb.AppendLine("#                  #");
            sb.AppendLine("####################");
            image = sb.ToString();
        }

        public string Name { get { return name; } }
        public string Job { get { return job; } }
        public string Image { get { return image; } }
        public char Icon { get { return icon; } }
        public Position Pos { get { return pos; } set { pos = value; } }
        public int CurHp { get { return curHp; } }
        public int MaxHp { get { return maxHp; } }
        public int AP { get { return ap; } }
        public int DP { get { return dp; } }
        public int MaxMp { get { return maxMp; } }
        public int CurMp { get { return curMp; } }

        // 이동
        public void Move(Direction dir)
        {
            Position prevPos = pos;             // 현재 위치 저장
            switch (dir)
            {
                case Direction.Up:
                    pos.y--;
                    break;
                case Direction.Down:
                    pos.y++;
                    break;
                case Direction.Left:
                    pos.x--;
                    break;
                case Direction.Right:
                    pos.x++;
                    break;
            }

            if (!Data.map[pos.y, pos.x])        // 이동한 곳이 false이면
            {
                pos = prevPos;                  // 저장위치로 복귀
            }
        }
    }
}
