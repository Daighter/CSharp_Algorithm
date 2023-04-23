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
    }

    internal class Player
    {
        private string name;
        public Player(string name)
        {
            this.name = name;
        }
    }
}
