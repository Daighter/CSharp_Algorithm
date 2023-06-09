﻿using Profect.TextRPG.Myself.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Profect.TextRPG.Myself
{
    internal abstract class Monster : IAttackablePlayer, IHitable
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
        public string Image { get { return image; } }
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
                case Direction.LeftUp:
                    pos.x--;    pos.y--;
                    break;
                case Direction.RightUp:
                    pos.x++;    pos.y--;
                    break;
                case Direction.LeftDown:
                    pos.x--;    pos.y++;
                    break;
                case Direction.RightDown:
                    pos.x++;    pos.y++;
                    break;
            }

            if (!Data.map[pos.y, pos.x] ||          // 이동한 자리가 벽이거나
                Data.IsObjectInPos(pos))            // 다른 물체가 있을 때
                pos = prevPos;                          // 저장위치로 복귀
        }

        public void Attack(Player player)
        {
            Console.WriteLine($"{name}이(가) {player.Name}을(를) 공격합니다.");
            Thread.Sleep(2000);
            player.TakeDamage(ap);
        }

        public void TakeDamage(int ap)
        {
            if (ap - dp > 0)
            {
                Console.WriteLine($"{name}은(는) {ap - dp}의 데미지를 받았다.");
                curHp -= ap - dp;
            }
            else
                Console.WriteLine($"공격은 {name}에게 먹히지 않았다.");
            Thread.Sleep(2000);

            if (curHp <= 0)
            {
                Console.WriteLine($"{name}은(는) 쓰러졌다!");
                Thread.Sleep(2000);
            }
        }
    }
}
