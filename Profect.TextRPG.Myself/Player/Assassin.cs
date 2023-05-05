using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profect.TextRPG.Myself
{
    internal class Assassin : Player
    {
        public Assassin(string name) : base(name)
        {
            this.name = name;
            this.job = "암살자";
            this.maxHp = 100;
            this.curHp = maxHp;
            this.ap = 20;
            this.dp = 5;
            this.maxMp = 100;
            this.curMp = maxMp;
        }
    }
}
