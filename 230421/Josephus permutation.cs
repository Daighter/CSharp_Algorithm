using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230421
{
    internal class Josephus_permutation
    {
        private int lastNumber;                             // 최후의 1인 변수 선언
        public Josephus_permutation() { }                   // 생성자

        // 1번부터 살리고 => 죽이고 반복
        public void LastAliver(string str)
        {
            int totalPeople = int.Parse(str);                   // 참가인원 int로 면환
            int defaultNum = 2;                                 // 2의 제곱수
            int needKill = 0;
            for (int i=1; defaultNum<totalPeople; i++)          // 반복(2의 i승)
            {
                if (totalPeople - defaultNum > defaultNum)          // 참가인원 - 현재 제곱수 값이 제곱수 보다 크면
                    defaultNum *= 2;                                    // 제곱수 2배 증가
                else if (totalPeople - defaultNum == defaultNum)     // 참가인원 - 현재 제곱수 값이 제곱수 보다 작거나 같으면
                {
                    lastNumber = 1;
                    break;
                }
                else
                {
                    needKill = totalPeople - defaultNum;
                    lastNumber = needKill * 2 + 1;
                    break;
                }
            }
            // 확인용 출력
            Console.WriteLine(defaultNum);
            Console.WriteLine($"최후의 생존자 : {lastNumber}번");
        }
    }
}
