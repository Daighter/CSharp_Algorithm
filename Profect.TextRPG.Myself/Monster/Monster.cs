using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Profect.TextRPG.Myself
{
    internal abstract class Monster
    {
        protected string name;
        protected string image;
        protected char icon = '▼';
        protected Position pos;
        protected int maxHp;
        protected int curHp;
        protected int ap;
        protected int dp;

        public Monster() { }

        public string Name { get { return name; } }
        public char Icon { get { return icon; } }
        public Position Pos { get { return pos; } set { pos = value; } }
        public int CurHp { get { return curHp; } }
        public int MaxHp { get { return maxHp; } }
        public int AP { get { return ap; } }
        public int DP { get { return dp; } }

        // 이동 추상함수
        public abstract void MoveAction();

        // 이동
        protected void Move(Direction dir)
        {
            Position prevPos = pos;

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

            if (!Data.map[pos.y, pos.x] ||          // 이동한 자리가 벽이거나
                Data.IsObjectInPos(pos))            // 다른 물체가 있을 때
                pos = prevPos;                          // 저장위치로 복귀
        }
    }
}
