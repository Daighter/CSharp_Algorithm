using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230421
{
    internal class FastToStart
    {
    }

    public class Player
    {
        private string name;
        private int speed;
        public Player(string name)
        {
            AddPlayer();
        }

        public void AddPlayer()
        {
            Random setSpeed = new Random();
            speed = setSpeed.Next(1, 10);
        }
    }
}
