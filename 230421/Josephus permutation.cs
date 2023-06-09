﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        // 3번째마다 제거하는 함수
        /*
        3   // 참가 인원(검사번호)
        2	// 라스트 원

        4	5	    6
        1	4	    7

        6	7	8	    9
        1	4	7	    10

        9	10	11	12	13
        1	4	7	10	13

        14	15	16	17	18	19	20
        2	5	8	11	14	17	20

        21	22	23	24	25	26	27	28	29	30
        2	5	8	11	14	17	20	23	26	29

        31	32	33	34	35	36	37	38	39	40	41	42	43	44	45	46
        1	4	7	10	13	16	19	22	25	28	31	34	37	40	43	46

        47	48	49	50	51	52	53	54	55	56	57	58	59	60	61	62	63	64	65	66	67	68	69
        2	5	8	11	14	17	20	23	26	29	32	35	38	41	44	47	50	53	56	59	62	65	68

        70	71	72	73	74	75	76	77	78	79	80	81	82	83	84	85	86	87	88	89	90	91	92	93	94	95	96	97	98	99	100	101	102	103	104
        1	4	7	10	13	16	19	22	25	28	31	34	37	40	43	46	49	52	55	58	61	64	67	70	73	76	79	82	85	88	91	94	97	100	103

        105	106	107	108	109	110	111	112	113	114	115	116	117	118	119	120	121	122	123	124	125	126	127	128	129	130	131	132	133	134	135	136	137	138	139	140	141	142	143	144	145	146	147	148	149	150	151	152	153	154	155	156	157
        1	4	7	10	13	16	19	22	25	28	31	34	37	40	43	46	49	52	55	58	61	64	67	70	73	76	79	82	85	88	91	94	97	100	103	106	109	112	115	118	121	124	127	130	133	136	139	142	145	148	151	154	157

        158
        2
         */
        public void TwoAliveOneKill(string str)
        {
            int totalPeople = int.Parse(str);                   // 참가인원 int형으로 형변환
            int currentNum = 3;                                 // 최소인원 (이하 검사번호)
            int lastNumber = 2;                                 // 최후의 1인 (이하 라스트원)
            int subtracted;                                     // 검사번호 - 라스트원

            if (totalPeople < currentNum)                       // 참가인원이 3명 미만일 때
                Console.WriteLine($"참가인원이 부족합니다");
            else if (totalPeople == currentNum)                 // 참가인원이 3명일 때
                Console.WriteLine($"최후의 생존자 : {lastNumber}번");
            else                                                // 참가인원 4명 이상부터
            {
                currentNum++;
                while (currentNum <= totalPeople)                   // 참가인원까지 반복
                {
                    lastNumber += 3;
                    subtracted = currentNum - lastNumber;
                    switch (subtracted)
                    {
                        case -1:
                            lastNumber = 1;
                            break;
                        case -2:
                            lastNumber = 2;
                            break;

                    }
                    // 확인용 출력
                    //Console.Write($"{currentNum}, ");
                    //Console.WriteLine(lastNumber);

                    currentNum++;
                    
                }
                Console.WriteLine($"최후의 생존자 : {lastNumber}번");
            }
        }

        // 3번째마다 제거하는 요세푸스 Queue로 작성
        public void TwoAliveOneKillQueue(string str, string num)
        {
            Queue<int> TwoAOneK = new Queue<int>();         // Queue 클래스 인스턴스 선언
            int totalPeople = int.Parse(str);               // 참가인원 int형변환
            int targetPerson = int.Parse(num);              // 목표번째 int형변환
            List<int> josephus = new List<int>();
            for (int i=1; i<=totalPeople; i++)              // Queue에 참가인원만큼 추가
                TwoAOneK.Enqueue(i);

            while(TwoAOneK.Count != 1)                      // Queue안에서 최후의 1인이 될때까지 반복
            {
                int moveTail;                                   // 옮기는 용도의 변수
                for (int i=1; i<=targetPerson; i++)             // 목표번째 만큼씩 반복
                {
                    if (i < targetPerson)
                    {
                        moveTail = TwoAOneK.Dequeue();                  // 최전방에서 지우고
                        TwoAOneK.Enqueue(moveTail);                     // 뒤로 옮기기
                    }
                    else
                    {
                        josephus.Add(TwoAOneK.Dequeue());
                        //Console.WriteLine($"{TwoAOneK.Dequeue()}는 임포스터 였습니다."); // 나가리
                    }
                }
            }
            foreach (int i in josephus)
                Console.Write($"{i}, ");
            Console.WriteLine();
            // 최후의 1인 출력
            Console.WriteLine(TwoAOneK.Peek());
        }
    }
}
