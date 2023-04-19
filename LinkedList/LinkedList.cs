using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
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

    public class LinkedList<T>
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
            if (tail != null)       // 2-1 Tail 노드가 있을 때
            {
                newNode.prev = tail;    // 새 노드의 전 노드는 끝 노드 
                tail.next = newNode;    // 끝 노드의 다음 노드는 새 노드
            }
            else                    // 2-2 Tail 노드가 없을 때
            {
                head = newNode;         // 맨앞 노드는 새 노드
            }
            tail = newNode;         // 공틍으로 끝 노드는 새 노드
            // 3. 카운트 증가
            count++;

            return newNode;
        }
    }
}
