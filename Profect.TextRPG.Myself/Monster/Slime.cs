﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profect.TextRPG.Myself
{
    internal class Slime : Monster
    {
        private Random random = new Random();

        public Slime()
        {
            name = "슬라임";
            curHp = 20;
            maxHp = 20;
            ap = 3;
            dp = 0;

            // 슬라임 이미지
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                       .B               ");
            sb.AppendLine("                      :QQ7              ");
            sb.AppendLine("                    .PE: .KJ            ");
            sb.AppendLine("                   IZur:.. dL           ");
            sb.AppendLine("               .rISvr7v7ri. iIr         ");
            sb.AppendLine("          .vrI2sr.:rs177ri:.  r2L.      ");
            sb.AppendLine("      :LU2vii.::i7u5XJvri::ii:  iYSr    ");
            sb.AppendLine("    72r:  .irsj22S5Xuvi:::::::..  .rI   ");
            sb.AppendLine("  r5i.JZgvuUUJUjUusL7:.   . .        IE ");
            sb.AppendLine(" :Q .Br.RB7v7vvLvL7i.v1Jr             QE");
            sb.AppendLine("7I..rBv:BQi7i:riri::QB7:BB.         . iE");
            sb.AppendLine("B: :LYPRKi:gPS.Ei..:BE  qBr        ... E");
            sb.AppendLine("B. iuvY::iiiSbZP:...7BZSB7  ... ..:i:. E");
            sb.AppendLine("B. :JuLririr:::..:..  ..   . . .   .:. E");
            sb.AppendLine("Zv .rYjvrrriri:..................  .: .E");
            sb.AppendLine(" 71 .vu1v7rrrrri::.....:.:.:.::i72si..BE");
            sb.AppendLine("  S7  rY1Jsv77v77ri:i:::::iir7Ysur: iPr ");
            sb.AppendLine("   :1i ..rvuujsuJJ7L7v7v7v7777r:...IJ   ");
            sb.AppendLine("     iI77...::irv7Yvvvv7ri:..:::j2S.    ");
            sb.AppendLine("         ii::ir7.::::::::7rrrii:        ");
            image = sb.ToString();
        }

        private int moveTurn = 1;           // 턴 변수
        // 이동 오버라이드
        public override void MoveAction()
        {
            if (moveTurn++ < 4)                 // 4턴째가 아니면 
                return;                             // 함수 탈출
            moveTurn = 1;                       // 4턴째에 턴수 초기화

            switch (random.Next(0, 4))          // 이동 시작
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
