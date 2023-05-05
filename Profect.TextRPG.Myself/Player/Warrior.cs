using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profect.TextRPG.Myself
{
    internal class Warrior : Player
    {
        private char icon = '★';

        public Warrior(string name) : base(name)
        {
            this.name = name;
            this.maxHp = 100;
            this.curHp = maxHp;
            this.ap = 10;
            this.dp = 10;
            this.maxMp = 50;
            this.curMp = maxMp;
        }
    }
}
