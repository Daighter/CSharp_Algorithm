using System.Threading.Channels;

namespace NandM3
{
    internal class Program
    {
        // 교수님 죄송합니다
        // 변명이지만 계속 붙잡고 있어도 중요한 것을 놓쳤는지 어디서 엮여있는지 햇갈립니다...
        static void Main(string[] args)
        {
            Array array = new Array();
        }

        internal class Array
        {
            private int[] array;
            private int n;
            private int m;
            public Array()
            {
                Console.Write("총 자연수 : ");
                this.n = int.Parse(Console.ReadLine());
                Console.Write("고를 수 : ");
                this.m = int.Parse(Console.ReadLine());
                array = new int[this.m];
                for (int i=0; i<m; i++)
                    array[i] = 1;
            }

            public void Print()
            {
                // 1. m-1 행 n까지 추가
                // 2. m-2 행 1 올리고 m-1행 반복
            }

            // array[a-1]행 1 올리고 반복
            private void UpAndDown(int a)
            {
                if (array[a-1] != n)        // array[a-1]행이 n이 아니면
                    AddNum(a);                  // n까지 반복
            }

            // array[m-1]이 n보다 작으면 m행 AddNum
            private void AddUp(int m)
            {
                array[m]++;
            }
            // array[a]행 n까지 증가
            private void AddNum(int a)
            {
                while (array[a] <= n)
                {
                    foreach (int i in array)
                        Console.WriteLine($", {i}");
                    if (array[a] == n)
                        break;
                    array[a]++;
                }
            }
        }
    }

}