using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class LinkedListNode<T>
    {
        internal LinkedList<T> list;
        internal LinkedListNode<T> prev;
        internal LinkedListNode<T> next;
        private T item;

        public LinkedList<T> List { get { return list; } }
        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedListNode<T> Next { get { return next; } }
        public T Item { get { return item; } set { item = value; } }

        public LinkedListNode(T value)
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public LinkedListNode<T> First { get { return head; } }
        public LinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            count = 0;
        }

        public LinkedListNode<T> AddFirst(T value)
        {
            // 1. 새로운 노드 생성
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            // 2. 연결구조 바꾸기
            if (head != null)           // 2-1 Head 노드가 있었을 때
            {
                newNode.next = head;        // 새 노드의 다음 노드는 맨앞 노드
                head.prev = newNode;        // 맨앞 노드의 전 노드는 새 노드
            }
            else                        // 2-2 Head 노드가 없을 때
            {
                tail = newNode;             // 끝 노드는 새 노드
            }
            head = newNode;             // 맨앞 도느는 새 노드
            // 3. 갯수 늘리기
            count++;

            return newNode;
        }

        public LinkedListNode<T> AddLast(T value)
        {
            // 1. 새로운 노드 생성
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            // 2. 연결구조 변경
            if (tail != null)           // 2-1 Tail 노드가 있을 때
            {
                newNode.prev = tail;        // 새 노드의 전 노드는 끝 노드
                tail.next = newNode;        // 끝 노드의 다음 노드는 새 노드
            }
            else                        // 2-2 Tail 노드가 없을 때
            {
                head = newNode;             // 맨앞 노드는 새 노드
            }
            tail = newNode;             // 공통으로 끝 노드는 새 노드
            // 3. 카운트 증가
            count++;

            return newNode;
        }

        // 기본 주가시 자동으로 마지막에 추가하도록 하는 함수
        public void Add(T value)
        {
            AddLast(value);
        }

        // 새 노드를 기준 노드의 앞에 추가하는 함수
        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            if (node.list != this)          // 기준 노드의 리스트가 새 노드의 리스트와 다르면 예외처리
                throw new InvalidOperationException();
            if (node == null)               // 기준 노드가 없으면 예외처리
                throw new ArgumentNullException();

            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);     // 새 노드 선언

            newNode.next = node;                    // 새 노드의 다음 노드는 기준 노드
            newNode.prev = node.prev;               // 새 노드의 전 노드는 기준 노드의 전 노드

            node.prev = newNode;                    // 기준 노드의 전 노드는 새 노드
            if (node.prev != null)                  // 기준 노드의 전 노드의가 있으면
                node.prev.next = newNode;               // 기준 노드의 전 노드의 다음 노드는 새 노드
            else
                head = newNode;                         // 기준 노드의 전 노드가 없으면 새 노드가 맨앞 노드 

            count++;                                // 카운트 증가

            return newNode;
        }

        // 새 노드를 기준 노드의 앞에 추가하는 함수
        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            if (node.list != this)          // 기준 노드의 리스트가 새 노드의 리스트와 다르면 예외처리
                throw new InvalidOperationException();
            if (node == null)               // 기준 노드가 없으면 예외처리
                throw new ArgumentNullException();

            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);     // 새 노드 선언

            newNode.next = node.next;               // 새 노드의 다음 노드는 기준노드의 다음 노드
            newNode.prev = node;                    // 새 노드의 전 노드는 기준 노드

            node.next = newNode;                    // 기준 노드의 다음 노드는 새 노드
            if (node.next != null)                  // 기준 노드의 다음 노드가 있으면
                node.next.prev = newNode;               // 기준 노드의 다음 노드의 전 노드는 새 노드
            else
                tail = newNode;                         // 기준노드의 다음 노드가 없으면 새 노드가 끝 노드

            count++;                                // 카운트 증가

            return newNode;
        }

        // 입력받은 노드를 제거하는 함수
        public void Remove(LinkedListNode<T> node)
        {
            if (node.list != this)          // 기준 노드의 리스트가 새 노드의 리스트와 다르면 예외처리
                throw new InvalidOperationException();
            if (node == null)               // 기준 노드가 없으면 예외처리
                throw new ArgumentNullException();

            if (node.prev != null)              // 전 노드가 있으면 이어주고
                node.prev.next = node.next;
            else                                // 없으면 본노드가 head이니 해당 직군 양도
                head = node.next;

            if (node.next != null)              // 앞 노드가 있으면 이어주고
                node.next.prev = node.prev;
            else                                // 없으면 해당 직군 양도
                tail = node.prev;

            // 카운트 증가
            count--;
        }

        // 입력받은 값으로 노드를 제거하는 함수
        public bool Remove(T value)
        {
            LinkedListNode<T> findNode = Find(value);       // 찾은 노드 변수 선언 맟 값으로 노드 찾기
            if (findNode != null)                           // 찾은 노드가 있으면
            {
                Remove(findNode);                               // 그 노드 제거
                return true;                                    // 긍정 반환
            }
            else
            {
                return false;                                   // 없으니 부정 반환
            }
        }

        public void RemoveFirst()
        {
            if (head == null)
                throw new ArgumentNullException();

            // head를 양도하고
            head = head.next;

            // 카운트 감소
            count--;
        }

        // 값으로 노드를 찾는 함수
        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> target = head;                // 목표 노드 변수 선언 및 맨앞 노드러 지정
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;     // 비교클래스 선언 및 초기화

            while (target != null)                          // 목표(검사 노드)가 있으면 반복
            {
                if (comparer.Equals(value, target.Item))        // 비교클래스의 함수를 이용해 입력값과 검사노드의 값이 같으면
                    return target;                                  // 검사노드 반환
                else
                    target = target.next;                           // 없으면 목표를 다음 노드로 변경
            }
            return null;                                    // 마지막 노드까지 검사하도 안나오면 null반환
        }

        public LinkedListNode<T> FindLast(T value)
        {
            LinkedListNode<T> target = tail;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            while (target != null)
            {
                if (comparer.Equals(value, target.Item))
                    return target;
                else
                    target = target.prev;
            }

            return null;
        }

        public void Print(LinkedListNode<T> node)
        {
            Console.WriteLine(node.Item);
            if (node == head)
                Console.WriteLine($"I|'m head");
            if (node == tail)
                Console.WriteLine($"I|'m tail");
        }

        public void Print(T value)
        {
            LinkedListNode<T> findNode = Find(value);

            if (findNode != null)
            {
                Print(findNode);
            }
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
            private LinkedList<T> linkedList;
            private LinkedListNode<T> node;
            private T current;
            private int count;
            
            public T Current { get { return current; } }

            internal Enumerator(LinkedList<T> linkedList)
            {
                this.linkedList = linkedList;
                this.node = linkedList.head;
                this.current = default(T);
                this.count = linkedList.Count;
                
            }

            object IEnumerator.Current
            {
                get
                {
                    if (count < 0 || count >= linkedList.Count)
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
                if (node != null)
                {
                    current = node.Item;            // 먼저 값을 주고 후위증가하여 다음으로 넘어감
                    node = node.next;
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
                node = linkedList.head;
                current = default(T);
                count = 0;
            }
        }
    }
}
