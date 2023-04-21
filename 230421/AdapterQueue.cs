using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class AdapterQueue<T>
    {
        private const int DefaultCapacity = 4;      // 초기 용량 크기 4로 고정 선언

        private T[] array;                          // 배열기반 선언
        private int head;                           // 선출 변수 선언
        private int tail;                           // 최후입 변수 선언

        public AdapterQueue()                       // 생성자
        {
            array = new T[DefaultCapacity + 1];         // 빈 상태와 가득 찬 상태의 구분을 위한 +1
            head = 0;
            tail = 0;
        }

        public int Count                            // property get 저장용량
        {
            get
            {
                if (head <= tail)                       // 배열에서 head가 tail보다 왼쪽에 있거나 같을 때
                    return tail - head;
                else                                    // 배열에서 head가 tail보다 오른쪽에 있을 때
                    return (array.Length - head) + tail;    // head부터 배열 끝까지 + 배열 처음부터 tail까지
            }
        }

        private void MoveNext(ref int index)        // 다음으로 이동시키는 함수 (이동시킬 배겨변수를 변경하도록 ref)
        {
            index = (index == array.Length - 1) ? 0 : index + 1;    // 배열 마지막 항이 차있으면 0, 아니면 다음으로 이동
        }

        public void Enqueue(T item)                 // Queue 항 (최전방에)추가
        {
            if (IsFull())                               // 배열이 가득 찼으면
                Grow();                                     // 배열 확장

            array[tail] = item;                         // 아니면 tail항에 추가하고
            MoveNext(ref tail);                         // tail 다음칸으로 이동
        }

        public T Dequeue()                          // Queue 항(최전방) 반환 후 head 이동
        {
            if (IsEmpty())                              // 배열이 비어있으면 예외처리
                throw new InvalidOperationException();

            T result = array[head];                     // 배열의 head부분 전달
            MoveNext(ref head);                         // head 다음으로 이동 (다음에 덮어써질 것이므로 지울 필요 없음)
            return result;                              // 전달부 반환
        }

        public T Peek()                             // 현재 최전방 반환
        {
            if (IsEmpty())                              // 배열이 비어있으면 예외처리
                throw new InvalidOperationException();

            return array[head];                     // 배열의 head 반환
        }

        private void Grow()                         // 배열 증설
        {
            int newCapacity = array.Length * 2;         // 새 배열의 용량은 2배
            T[] newArray = new T[newCapacity + 1];      // 용량 2배+1(빈 상태와 가득 찬상태 구별용) 새 배열
            if (!IsEmpty())                             // 비어있지 않다면 (옮기기)
            {
                if (head < tail)                            // 배열에서 head가 tail보다 왼쪽에 있다면
                    Array.Copy(array, head, newArray, 0, tail);                 // 원본배열의 head부터 tail만큼을 증설배열의 처음부터 복사
                                                                                // array.     head,    tail,      newArray,  0
                else                                        // 배열에서 head가 tail보다 오른쪽에 있으면
                {
                    Array.Copy(array, head, newArray, 0, array.Length - head);  // 원본배열의 head부터 배열의 끝까지를   증설배열의 처음부터 복사
                                                                                // array,     head, array.Length - head, newArray,  0
                    Array.Copy(array, 0, newArray, array.Length - head, tail);  // 원본배열의 처음부터 tail까지를 증설배열의 복사한 뒷자리부터 추가복사
                                                                                // array,     0,       tail,      newArray,  array.Length - head
                }
            }

            array = newArray;                           // 원본배열을 증설한 배열로 갱신
            tail = Count;
            head = 0;
        }

        private bool IsEmpty()                          // 비어있는지 판별
        {
            return head == tail;                            // 비어있을 때만 겹침
        }

        private bool IsFull()                           // 가득 찼는지 판별
        {
            if (head > tail)                                // 배열에서 head가 tail보다 왼쪽에 있을 때
            {
                return head == tail + 1;                        // tail이 한칸 움직였을 때 head와 겹치면 true 아니면 false
            }
            else                                            // 배열에서 head가 tail보다 오른쪽에 있을 때
            {
                return head == 0 && tail == array.Length - 1;   // 배열의 0번째가 차있고 tail이 배열의 마지막에 가있으면(+ 1의 역할) true 아니면 false
            }
        }

        public void Clear()                             // 초기화 함수
        {
            array = new T[DefaultCapacity + 1];
            head = 0;
            tail = 0;
        }
    }
}
