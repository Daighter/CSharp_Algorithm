using System.Threading.Channels;

namespace _230421
{
    internal class Program
    {
        static void Main(string[] args)
        {/*
            // 괄호 계산기
            BracketCalculator bracketCalculator = new BracketCalculator();
            bracketCalculator.Result();

            // 대기열 함수
            FastToStart waiting = new FastToStart();
            Player player1 = new Player("김철수");
            Player player2 = new Player("박영희");
            Player player3 = new Player("정영수");

            waiting.AddPlayer(player1);
            waiting.AddPlayer(player3);

            waiting.CurrentFastestPlayer();
            waiting.NumberOfWaiting();

            waiting.AddPlayer(player2);

            waiting.CurrentFastestPlayer();
            waiting.NumberOfWaiting();

            waiting.StartFastestPlayer();
            waiting.StartFastestPlayer();

            waiting.CurrentFastestPlayer();
            waiting.NumberOfWaiting();*/

            // 요세푸스 순열
            Josephus_permutation lastOne = new Josephus_permutation();
            Console.Write("참가 인원 입력 : ");
            // lastOne.OneAliveOneKill(Console.ReadLine());
            lastOne.TwoAliveOneKill(Console.ReadLine());
        }
    }
}