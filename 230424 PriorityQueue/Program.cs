namespace _230424_PriorityQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Emergency emergency = new Emergency();
            emergency.EnQueuePatient(new Patient("김철수"));
            emergency.EnQueuePatient(new Patient("박영희"));
            emergency.EnQueuePatient(new Patient("다니엘잭"));

            emergency.curePriority.Peek();

            while (pq2.Count > 0)
                Console.WriteLine(pq2.Dequeue()); // 우선순위가 높은 순서대로 데이터 출력
        }
    }
}