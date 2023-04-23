using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230421
{
    internal class FastToStart
    {
        private Queue<string> players = new Queue<string>();
        public FastToStart() { }

        public void AddPlayer(Player player)
        {
            players.Enqueue(player.Name);
            Console.WriteLine($"대기열에 {player.Name} 추가");
        }

        public void StartFastestPlayer()
        {
            Console.WriteLine($"유저 {players.Dequeue()} 실행");
        }

        public void CurrentFastestPlayer()
        {
            Console.WriteLine($"다음 차례는 {players.Peek()}님 입니다.");
        }

        public void NumberOfWaiting()
        {
            Console.WriteLine($"현재 {players.Count}명 대기중 입니다.");
        }
    }

    internal class Player
    {
        private string name;
        public Player(string name)
        {
            this.name = name;
        }
        public string Name
        { get { return name; } }
    }
}
