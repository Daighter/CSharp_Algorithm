using System;

namespace Hanoi
{
    internal class Program
    {
        const int start = 0;
        const int end = 2;
        static void Main(string[] args)
        {
            Hanoi hanoi = new Hanoi();
            hanoi.Solve();
        }

        internal class Hanoi
        {
            private Stack<int>[] hanoi = new Stack<int>[3];
            private int level;
            public Hanoi()
            {
                Console.Write("하노이 레벨 입력 : ");
                this.level = int.Parse(Console.ReadLine());
            }

            public void Solve()
            {
                SetGame();
                Move(level, start, end);
            }

            private void SetGame()
            {
                for (int i=0; i<3; i++)
                {
                    hanoi[i] = new Stack<int>();
                }
                for (int i = level; i > 0; i--)
                {
                    hanoi[0].Push(i);
                    //Console.WriteLine(hanoi[0].Peek());
                    //Console.WriteLine(hanoi[0].Count);
                }
            }

            private void Move(int num, int start, int end)
            {
                if (num == 1)
                {
                    int plate = hanoi[start].Pop();
                    hanoi[end].Push(plate);
                    Console.WriteLine($"{plate}를 {start}번째에서 {end}번째로 이동");
                    return;
                }

                int another = 3 - start - end;
                Move(num - 1, start, another);
                Move(1, start, end);
                Move(num - 1, another, end);
            }
        }


        
    }
}