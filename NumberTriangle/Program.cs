namespace NumberTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        
        internal class TriAngle
        {
            private int[,] input = new int[5,5]
            {
                { 7, 0, 0, 0, 0},
                { 3, 8, 0, 0, 0},
                { 8, 1, 0, 0, 0},
                { 2, 7, 4, 4, 0},
                { 4, 5, 2, 6, 5}
            };
            private int n;
            private int[,] answer;
            public TriAngle()
            {
                this.n = 5;
                answer = new int[5,5];
            }
            // answer[2^(n-1), n-1] 이 아니고 전 현재 검사 항의 양쪽 위의 수 중 더 큰 수를 더해준다
        }
    }
}