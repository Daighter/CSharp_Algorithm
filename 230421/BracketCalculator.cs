using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230421
{
    internal class BracketCalculator
    {
        private int openCount = 0;
        private int closeCount = 0;
        private bool correct = false;
        public BracketCalculator() {  }

        public void Result()
        {
            Console.Write("괄호 입력 : ");
            Input(Console.ReadLine());
            Console.WriteLine(correct);
        }

        public void Input(string str)
        {
            foreach (char c in str)
            {
                switch (c)
                {
                    case '(':
                    case '{':
                    case '[':
                        openCount++;
                        break;
                    case ')':
                    case '}':
                    case ']':
                        closeCount++;
                        break;
                }
                if (c == str[0] && closeCount == 1)
                    correct = false;
            }

            if (openCount == closeCount)
                correct = true;
            else
                correct = false;
        }
    }

    
}
