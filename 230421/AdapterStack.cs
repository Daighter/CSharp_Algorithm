using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportStructure
{
    public class AdapterStack<T>
    {
        private List<T> container;          // 리스트 기반 변수 선언

        public AdapterStack()               // 생성자
        {
            container = new List<T>();
        }

        public void Push(T value)           // Stack 항 (최상단으로)추가
        {
            container.Add(value);           // 리스트의 Add함수 이용
        }

        public T Pop()                      // Stack 항(최상단) 반환 후 제거
        {
            T value = container[container.Count - 1];   // value에 현재 최전방 항 전해주고
            container.RemoveAt(container.Count - 1);    // 최전방 항 제거
            return value;                               // value 반환
        }

        public T Peek()                     // Stack 최전방 항 반환
        {
            return container[container.Count - 1];
        }
    }
}
