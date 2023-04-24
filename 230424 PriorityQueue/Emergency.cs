using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230424_PriorityQueue
{
    internal class Emergency
    {
        public PriorityQueue<string, int> curePriority = new PriorityQueue<string, int>();
        public Emergency() { }

        public void EnQueuePatient(Patient patient)
        {
            curePriority.Enqueue(patient.Name, patient.GoldenTime);
            Console.WriteLine($"환자명 : {patient.Name}, 우선순위 : {patient.GoldenTime}");
        }
    }

    public class Patient
    {
        private string name;
        private int goldenTime;
        public Patient(string name)
        {
            this.name = name;
            this.goldenTime = Random();
        }

        public string Name { get { return name; } }
        public int GoldenTime { get { return goldenTime; } }

        // 랜덤 골든타임 생성
        internal int Random()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }
    }
}
