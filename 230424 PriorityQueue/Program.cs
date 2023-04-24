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

            while (emergency.curePriority.Count > 0)
            {
                Console.WriteLine(emergency.curePriority.Dequeue()); // 우선순위가 높은 순서대로 데이터 출력
            }
        }
    }
}