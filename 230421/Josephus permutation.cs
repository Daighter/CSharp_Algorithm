using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230421
{
    internal class Josephus_permutation
    {
        private int lastNumber;
        public Josephus_permutation() { }

        // 1번부터 살리고 => 죽이고 반복
        public void LastAliver(string str)
        {
            int totalPeople = int.Parse(str);
            int defaultNum = 2;
            while(true)
            {
                if (totalPeople - defaultNum > defaultNum)
                    defaultNum *= 2;
                else
                    break;
            }
            // 확인용 출력
            Console.WriteLine(defaultNum);
            lastNumber = defaultNum + 1;
            Console.WriteLine($"최후의 생존자 : {lastNumber}번");
        }
    }
}
