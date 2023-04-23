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
            int defaultNum = 1;                                 // 초기 제곱수 변수
            int needKill = 0;                                   // 2의 제곱수가 남기까지 필요한 제거 수 변수
            if (totalPeople >= 2)                               // 참가인원이 2명 이상일 때
            {
                for (int i = 0; defaultNum < totalPeople; i++)      // 반복 (2의 i승)
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
            else                                                // 참가인원이 1명일 때
                Console.WriteLine($"참가인원이 부족합니다");
        }

        public void TwoAliveOneKill(string str)
        {
            int totalPeople = int.Parse(str);                   // 참가인원 int형으로 형변환
            int currentNum = 3;                                 // 현재검사번호
            int lastNumber = 2;                                 // 참가인원을 안넘는 3을 추가하는 수
            // 현재검사번호 - 라스트원번호

            if (totalPeople < 3)                                // 참가인원이 2명 이하일 때
                Console.WriteLine($"참가인원이 부족합니다");
            else if (totalPeople == 3)                          // 참가인원이 3명일 때
                Console.WriteLine($"최후의 생존자 : {lastNumber}번");
            else                                                // 참가인원 4명 이상부터
            {
                // 검사번호 +1
                // 라스트원 +3

                // 검사번호 - 라스트원 값이 0 이하일 때
                    // 1일 경우
                        // 1부터 시작
                    // 같을 경우
                        // 2부터 시작

                while (currentNum - lastNumber > 2)
                {
                    switch (lastNumber)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                    }
                }
            }
        }
    }
}
