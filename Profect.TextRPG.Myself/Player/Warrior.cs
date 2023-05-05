﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profect.TextRPG.Myself
{
    internal class Warrior : Player
    {
        public Warrior(string name) : base(name)
        {
            this.name = name;
            this.job = "전사";
            this.maxHp = 120;
            this.curHp = maxHp;
            this.ap = 10;
            this.dp = 15;
            this.maxMp = 50;
            this.curMp = maxMp;
        }
    }
}
