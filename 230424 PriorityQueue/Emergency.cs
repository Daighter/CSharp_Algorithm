using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230424_PriorityQueue
{
    internal class Emergency
    {
        private PriorityQueue<string, int> curePriority = new PriorityQueue<string, int>();
        private List<int> goldenTimes = new List<int>();
        public Emergency() { }
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

        // 랜덤 골든타임 생성
        internal int Random()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }
    }
}
