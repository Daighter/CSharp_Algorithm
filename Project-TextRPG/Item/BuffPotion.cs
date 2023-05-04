using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    internal class BuffPotion : Item
    {
        private int InhenceAP;
        public BuffPotion()
        {
            name = "공격력 강화포션";
            description = $"플레이어의 공격력이 {InhenceAP} 상승합니다.";
            weight = 1;
        }
        public override void Use()
        {

        }
    }
}
