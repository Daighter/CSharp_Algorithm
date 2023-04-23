using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230421
{
    internal class Josephus_permutation
    {
        private int lastAliver;                             // 최후의 1인 변수 선언
        public Josephus_permutation() { }                   // 생성자

        // 1번부터 살리고 => 죽이고 반복
        public void OneAliveOneKill(string str)
        {
            int totalPeople = int.Parse(str);                   // 참가인원 int형으로 형변환
            int defaultNum = 2;                                 // 초기 제곱수 변수
            int needKill = 0;                                   // 2의 제곱수가 남기까지 필요한 제거 수 변수
            for (int i=1; defaultNum<totalPeople; i++)          // 반복 (2의 i승)
            {
                if (totalPeople - defaultNum > defaultNum)          // 참가인원 - 현재 제곱수 값이 현재 제곱수 값보다 크면
                    defaultNum *= 2;                                    // 제곱수 승 증가
                else if (totalPeople - defaultNum == defaultNum)    // 참가인원 - 현재 제곱수 값이 현재 제곱수 값과 같다면
                {
                    lastAliver = 1;                                     // 참가인원이 제곱수 이므로 1번째가 생존자
                    break;
                }
                else                                                // 참가인원 - 현재 제곱수 값이 현재 제곱수 값보다 작으면
                {
                    needKill = totalPeople - defaultNum;                // 필요한 제거 수는 참가인원 - 현재 제곱수
                    lastAliver = needKill * 2 + 1;                      // 생존자는 제거 수 다음 번째
                    break;
                }
            }
            // 확인용 출력
            //Console.WriteLine(defaultNum);
            Console.WriteLine($"최후의 생존자 : {lastAliver}번");
        }
    }
}
