using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportStructure
{
    //                            <요소,      int>
    internal class PriorityQueue<TElement, TPriority>
    {
        private struct Node                 // 노드 구조체 선언
        {
            public TElement element;            // 초가화
            public int priority;
        }

        private List<Node> nodes;           // 노드를 리스트화
        private IComparer<int> comparer;    // 비교가능 

        public PriorityQueue()              // 생성자
        {
            this.nodes = new List<Node>();
            this.comparer = Comparer<int>.Default;
        }

        public PriorityQueue(IComparer<int> comparer)  // 생성자 오버로딩
        {
            this.nodes = new List<Node>();
            this.comparer = comparer;
        }

        public int Count { get { return nodes.Count; } }            // property get
        public IComparer<int> Comparer { get { return comparer; } } // property get

        // 요소의 우선순위 int를 받고 추가
        public void Enqueue(TElement element, int priority)
        {
            Node newNode = new Node() { element = element, priority = priority };   // 새 노드 인스턴스 생성

            // 1. 가장 뒤에 데이터 추가
            nodes.Add(newNode);                     // 리스트 맨 뒤에 새 노드 추가
            int newNodeIndex = nodes.Count - 1;     // 새 노드의 인덱스 변수 할당

            // 2. 새로운 노드를 
            while (newNodeIndex > 0)                // 새 노드가 2번째 이상이면 반복
            {
                // 2-1. 부모 노드 확인
                int parentIndex = GetParentIndex(newNodeIndex);     // 부모의 인덱스를 구하는 함수호출
                Node parentNode = nodes[parentIndex];               // 리스트에서 새 부모노드로 북사

                if (newNode.priority < parentNode.priority)         // 부모노드 보다 새 노드의 우선순위가 높으면(숫자가 작으면)
                {
                    nodes[newNodeIndex] = parentNode;                   // 부모노드와 자리를 바꾼다
                    nodes[parentIndex] = newNode;
                    newNodeIndex = parentIndex;
                }
                else { break; }                                     // 아니면 반복을 끝낸다
            }
        }

        // 자식 인덱스 매개변수로 부모 인덱스를 구하는 함수
        private int GetParentIndex(int childIndex)              //            0
        {                                                      //       1            2
            return (childIndex - 1) / 2;                    //      3       4      5      6
        }                                                   //   7  8    9 10   11 12   13 14

        // 요소 제거
        public TElement Dequeue()
        {
            Node rootNode = nodes[0];                   // 근본노드 = 맨위의 노드

            // 1. 가장 마지막 노드를 최상단으로 위치
            Node lastNode = nodes[nodes.Count - 1];     // 라스트 노드 = 리스트의 마지막 노드
            nodes[0] = lastNode;                        // 맨위 노드 = 라스트 노드
            nodes.RemoveAt(nodes.Count - 1);            // 리스트의 마지막 노드 제거

            // 힙 상태로 정렬작업
            int index = 0;                              // 현재 인덱스 0부터 시작
            while (index < nodes.Count)                 // 노드갯수만큼 반복
            {
                if (nodes.Count == 0)                       // 노드가 하나도 없으면 예외처리
                    throw new InvalidOperationException();

                int leftChildeIndex = GetLeftChildIndex(index);     // 왼쪽자식의 인덱스
                int rightChildeIndex = GetRightChildIndex(index);   // 오른쪽자식의 인덱스

                // 2-1. 자식이 둘다 있는 경우
                if (rightChildeIndex < nodes.Count)          // 검사노드의 오른쪽 자식이 있으면
                {
                    // 2-1-1. 왼쪽 자식과 오른쪽 자식 우선순위를 비교하여 높은 쪽을 lessChildeIndex에 전달
                    int lessChildeIndex = nodes[leftChildeIndex].priority < nodes[rightChildeIndex].priority
                        ? leftChildeIndex : rightChildeIndex;

                    // 2-1-2. 더 우선순위가 높은 자식과 부모 노드를 비교하여 자식의 우선순위가 더 높은 경우 바꾸기
                    if (nodes[lessChildeIndex].priority < nodes[index].priority) // 자식의 우선순위가 더 높으면
                    {
                        nodes[index] = nodes[lessChildeIndex];                      // 부모와 서로 위치변경
                        nodes[lessChildeIndex] = lastNode;
                        index = lessChildeIndex;                                    // 부모로 온 자식의 인덱스를 검사대상으로 지정
                    }
                    else                                                                    // 아니면 탈출
                        break;
                }
                // 2-2. 자식이 하나만 있는 경우 == 왼쪽 자식만 있는 경우
                else if (leftChildeIndex < nodes.Count)     // 오른쪽 자식이 없고 왼쪽 자식이 있으면
                {
                    if (nodes[leftChildeIndex].priority < nodes[index].priority) // 자식의 우선순위가 더 높으면
                    {
                        nodes[index] = nodes[leftChildeIndex];                      // 부모와 서로 위치변경
                        nodes[leftChildeIndex] = lastNode;
                        index = leftChildeIndex;                                    // 부모로 온 자식의 인덱스를 검사대상으로 지정
                    }
                    else                                                         // 아니면 탈출
                        break;
                }
                // 2-3. 자식이 없는 경우
                else                                                        // 그냥 탈출         
                    break;
            }
            return rootNode.element;                        // 최상위 노드(였던 것) 반환
        }

        // 부모 인덱스 매개변수로 왼쪽 자식의 인덱스를 구하는 함수
        private int GetLeftChildIndex(int parentIndex)              //                    0
        {                                                           //            1               2
            return parentIndex * 2 + 1;                             //       3      4          5        6
        }                                                           //    7   8   9    10    11  12    13  14
        // 부모 인덱스 매개변수로 오른쪽 자식의 인덱스를 구하는 함수
        private int GetRightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }

        // 현재 최우선순위 노드 반환
        public TElement Peek()
        {
            if (nodes.Count == 0)                       // 노드가 하나도 없으면 예외처리
                throw new InvalidOperationException();

            return nodes[0].element;                    // 최상단 요소 반환
        }
    }
}
