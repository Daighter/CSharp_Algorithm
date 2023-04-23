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

        // 3번째마다 제거하는 함수
        /*
        3
        2	

        4	5	
        1	4	

        6	7	8	
        1	4	7	

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
            int currentNum = 3;                                 // 검사번호
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
