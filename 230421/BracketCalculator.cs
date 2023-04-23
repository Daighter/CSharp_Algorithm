using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230421
{
    internal class BracketCalculator
    {
        Stack<char> stack = new Stack<char>();      // char 형식을 저장하는 stack 클래스 인스턴스 생성
        private bool correct = false;               // 계산 결과 bool 변수 선언
        public BracketCalculator() {  }             // 생성자

        public void Result()                        // 계산 함수
        {
            Console.Write("괄호 입력 : ");
            Input(Console.ReadLine());              // Input 함수에 입력값 전달
            Console.WriteLine(correct);             // 결과 출력
        }

        // 문자열을 받아서 결과를 correct에 반영하는 함수
        public void Input(string str)
        {
            stack.Clear();                          // 스택 초기화
            stack.Push('0');                        // 항이 없으면 확인 시에 예외가 발생하기에 헛 항으로 0 추가
            for (int i=0; i<str.Length; i++)        // 문자열의 길이만큼 반복
            {
                if (str[0] == ')' || str[0] == '}' || str[0] == ']')    // 첫 입력이 괄호의 닫는부분이면
                    break;                                                  // 탈출

                switch (str[i])
                {
                    case '(':                                               // 괄호의 여는 부분이면
                        stack.Push(str[i]);                                     // 스택에 추가
                        break;
                    case '{':
                        stack.Push(str[i]);
                        break;
                    case '[':
                        stack.Push(str[i]);
                        break;
                    case ')':                                               // 괄호의 닫는 부분이면
                        if (stack.Peek() == '(')                                // 자기 짝 확인하고
                            stack.Pop();                                        // 맞으면 삭제
                        break;
                    case '}':
                        if (stack.Peek() == '{')
                            stack.Pop();
                        break;
                    case ']':
                        if (stack.Peek() == '[')
                            stack.Pop();
                        break;
                }
            }
            if (stack.Peek() == '0')                                    // 괄호가 없으면
                correct = true;                                             // 참 반영
        }
    }

    
}
