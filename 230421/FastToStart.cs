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
        }

        public void StartFastestPlayer()
        {
            Console.WriteLine(players.Dequeue());
        }

        public void CurrentFastestPlayer()
        {
            Console.WriteLine(players.Peek());
        }

        public void NumberOfWaiting()
        {
            Console.WriteLine(players.Count);
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
