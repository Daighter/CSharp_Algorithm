using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _03._Iterator.Specifier;

namespace Iterator                                 // 기존 List와의 구분을 위한 데임스페이스
{
    internal class List<T> : IEnumerable<T>                                 // List<일반화> 선언
    {
        private const int DefaultCapacity = 4;                  // 기본 용량 4

        private T[] items;                                      // 배열명 items 선언
        private int size;                                       // List의 Count 역할 변수 선언

        public List()                                           // 생성자
        {
            items = new T[DefaultCapacity];                         // 배열 items = new 인스턴스 일반화[기본용량]
            size = 0;                                               // 초기 크기는 0
        }

        public int Capacity { get { return items.Length; } }    // property 접근
        public int Count { get { return size; } }               // property 접근

        public T this[int index]                                // 자신의 반환형과 이름[인덱스] 호출 함수 
        {
            get                                                     // property get
            {
                if (index < 0 || index >= size)                         // 인덱스가 0보다 작거나 카운트보다 크면
                    throw new IndexOutOfRangeException();                   // 예외처리

                return items[index];                                    // 배열의 인덱스값 반환
            }
            set                                                     // property set
            {
                if (index < 0 || index >= size)                         // 인덱스가 0보다 작거나 카운트보다 크면
                    throw new IndexOutOfRangeException();                   // 예외처리

                items[index] = value;                                   // 배열의 인덱스값을 value로 덮어쓰기
            }
        }

        // 리스트 항 추가 함수
        public void Add(T item)
        {
            if (size < items.Length)            // 배열의 길이가 카운트보다 작으면
            {
                items[size++] = item;               // 카운트 중가시키고 항 추가
            }
            else                                // 배열의 길이가 카운트보다 크거나 같으면
            {
                Grow();                             // Grow 함수 호출
                items[size++] = item;               // 카운트 증가시키고 항 추가
            }
        }

        // 기본 용량 증가 함수
        private void Grow()
        {
            int newCapacity = items.Length * 2;         // 새 변수는 배열의 길이 X2
            T[] newItems = new T[newCapacity];          // 새 배열은 새 인스턴스 자료형 이어받고[새 변수]
            Array.Copy(items, 0, newItems, 0, size);    // 새 배열에 기존의 배열을 처음부터 끝까지 복사 
            items = newItems;                           // 지정자 변경(기존 배열 인스턴스 삭제)
        }

        // 리스트 항 제거 함수
        public bool Remove(T item)
        {
            int index = IndexOf(item);                  // 인덱스 변수는 배개변수의 인덱스
            if (index >= 0)                             // 변수의 값이 0보다 크거나 같으면
            {
                RemoveAt(index);                            // RemoveAt 함수 호출
                return true;                                // true 반환
            }
            return false;                               // 변수의 값이 0보다 작으면 false 반환
        }

        // 리스트 항 제거 함수(본체)
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)                             // 매개변수의 값이 0보다 작거나 카운트보다 크거나 같으면
                throw new IndexOutOfRangeException();                       // 예외처리

            // 아니면 있다는 거니까
            size--;                                                     // 카운트 줄이고 
            Array.Copy(items, index + 1, items, index, size - index);   // 배열의 삭제할 인덱스 다음항 부터 끝까지를
                                                                        // 배열의 삭제할 안덱스항 부터 붙여넣는다
        }

        // 호출시 델리게이트 match의 값이 배열의 자료형과 같으면 인덱스값을 반환하는 함수 
        public T? Find(Predicate<T> match)
        {
            if (match == null) throw new ArgumentNullException();       // 함수 match의 반환값이 없으면 예외처리

            for (int i = 0; i < size; i++)                              // 배열의 크기만큼 반복
            {
                if (match(items[i]))                                        // match(배열의 항)가 true면(있으면)
                    return items[i];                                        // 그 항 반환
            }

            return default(T);                                          // 없으면 디폴트 반환
        }

        // 호출시 델리게이트 match의 값이 배열의 자료형과 같으면 반환하는 함수 
        public int FindIndex(Predicate<T> match)
        {
            return FindIndex(0, size, match);               // 처음부터 끝까지 중에 match 함수의 조건은 만족하는 값의 인덱스 반환
        }

        // 호출시 델리게이트 match의 값이 배열의 자료형과 같으면 반환하는 함수 (본체)
        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            if (startIndex > size)                              // 시작지점이 배열의 크기보다 크면
                throw new ArgumentOutOfRangeException();
            if (count < 0 || startIndex > size - count)         // 갯수가 0보다 작거나 시작지점이 남은 탐색할 인덱스의 수 보다 크면
                throw new ArgumentOutOfRangeException();
            if (match == null)                                  // match 함수의 값이 없으면
                throw new ArgumentNullException();                  // 모두 예외처리

            int endIndex = startIndex + count;                  // 탐색 끝 지점은 시작지점 + 카운트
            for (int i = startIndex; i < endIndex; i++)         // 시작지점부터 끝지점까지 반복
            {
                if (match(items[i])) return i;                      // // match(배열의 항)가 true면(있으면) 값의 인덱스 반환
            }
            return -1;                                          // 없으면 -1 반환
        }

        // 매개변수의 인덱스를 구하는 함수
        public int IndexOf(T item)
        {
            return Array.IndexOf(items, item, 0, size);     // 원래있는 Array.IndexOf(배열, 애개변수, 처음부터, 끝까지)함수를 사용
            // 있으면 값의 인덱스, 없으면 -1 반환
        }

        // 초기화 함수
        public void Clear()
        {
            items = new T[DefaultCapacity];         // 배열은 새 인스턴스 지료형 이어받고[기본 용량]
            size = 0;                               // 카운트는 0
        }

        // 정렬 함수
        public delegate int Compare(T left, T right);
        public static void Sort(List<T> list, Compare compare)
        {
            // 정렬알고리즘 Bubble Sort
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i; j < list.Count; j++)
                {
                    if (compare(list[i], list[j]) > 0)
                    {
                        T temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

        // 오름차순 정렬
        public static int AscendingOrder(int left, int right)
        {
            if (left > right)
                return 1;
            else if (left < right)
                return -1;
            else
                return 0;
        }

        // 내림차순 정렬
        public static int DescendingOrder(int left, int right)
        {
            if (left < right)
                return 1;
            else if (left > right)
                return -1;
            else
                return 0;
        }

        // ************************ 이하 반복기 부분 ***********************

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private List<T> list;
            private T current;
            private int index;
            
            public T Current { get { return current; } }

            internal Enumerator(List<T> list)
            {
                this.list = list;
                this.current = default(T);
                this.index = 0;
                
            }

            object IEnumerator.Current
            {
                get
                {
                    if (index < 0 || index >= list.Count)
                        throw new InvalidOperationException();
                    return current;
                }
            }

            public void Dispose()
            {
                Console.WriteLine("끝");
            }

            public bool MoveNext()
            {
                if (index < list.Count)
                {
                    current = list[index++];            // 먼저 값을 주고 후위증가하여 다음으로 넘어감
                    return true;
                }
                else
                {
                    current = default(T);
                    return false;
                }
            }

            public void Reset()
            {
                this.current = default(T);
                index = 0;
            }
        }
    }
}
