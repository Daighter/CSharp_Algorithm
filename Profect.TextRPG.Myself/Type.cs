using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profect.TextRPG.Myself
{
    public enum Direction { Up, Down, Left, Right, LeftUp, RightUp, LeftDown, RightDown }         // 방향 열거형

    public struct Position                                  // 좌표 구조체
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
