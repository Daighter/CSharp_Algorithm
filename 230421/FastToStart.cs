using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230421
{
    internal class FastToStart
    {
        private Queue<string> players = new Queue<string>();            // 문자열 형식을 저장하는 Queue 클래스 인스턴스 선언
        public FastToStart() { }                                        // 생성자

        public void AddPlayer(Player player)                            // 대기열에 플레이어 추가 함수
        {
            players.Enqueue(player.Name);
            Console.WriteLine($"대기열에 {player.Name} 추가");
        }

        public void StartFastestPlayer()                                // 대기열의 최전방 플레이어 실행 후 제거
        {
            Console.WriteLine($"유저 {players.Dequeue()} 실행");
        }

        public void CurrentFastestPlayer()                              // 대기열의 최전방 플레이어 확인
        {
            Console.WriteLine($"다음 차례는 {players.Peek()}님 입니다.");
        }

        public void NumberOfWaiting()                                   // 대기열의 대기자 수 출력
        {
            Console.WriteLine($"현재 {players.Count}명 대기중 입니다.");
        }
    }

    internal class Player                                           // 플레이어 클래스 추가
    {
        private string name;                                            // 플레이어 이름 변수
        public Player(string name)                                      // 생성자
        {
            this.name = name;
        }
        public string Name                                          // property get
        { get { return name; } }
    }
}
