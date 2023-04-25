using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportStructure
{
    internal class BinarySearchTree<T> where T : IComparable<T>             // 비교가 가능한 자료형만
    {
        private Node root;                          // 노드기반 자료구조

        public BinarySearchTree()                   // 생성자
        {
            this.root = null;
        }

        // 중복 추가 여부 확인을 위한 bool 리턴
        public bool Add(T item)                         
        {
            Node newNode = new Node(item, null, null, null);    // 새 노드는 데이터만 갖고있음

            if (root == null)                               // 기준노드가 없으면
            {
                root = newNode;                                 // 재 노드가 기준노드
                return true;                                    // 성공 반환
            }

            Node current = root;                            // 트리배치를 위한 현재(기준)노드
            while (current != null)                         // 항이 하나라도 있으면
            {
                
                if (item.CompareTo(current.Item) < 0)       // 새노드의 데이터가 기준노드의 데이터보다 작은 경우
                {
                    if (current.Left != null)                   // 기준노드의 왼쪽 자식이 있을 때
                    {
                        current = current.Left;                     // 왼쪽 자식과 또 비교하기 위해 current 왼쪽자식으로 설정
                    }
                    else                                        // 기준노드의 왼쪽 자식이 없을 때
                    {
                        current.Left = newNode;                     // 그 자리가 지금 추가될 자리
                        newNode.Parent = current;
                        break;
                    }

                }
                else if (item.CompareTo(current.Item) > 0)  // 새노드의 데이터가 기준노드의 데이터보다 큰 경우
                {
                    if (current.Right != null)                  // 기준노드의 오른쪽 자식이 있을 때
                    {
                        current = current.Right;                    // 오른쪽 자식과 또 비교하기 위해 current 오른쪽자식으로 설정
                    }
                    else                                        // 기준노드의 오른쪽 자식이 없을 때       
                    {
                        current.Right = newNode;                    // 그 자리가 지금 추가될 자리
                        newNode.Parent = current;
                        break;
                    }
                }
                else                                        // 동일한 데이터가 들어온 경우
                    return false;                           // 실패사유 : 중복
            }
            return true;                                // 성공
        }

        // 노드가 존재하는지 찾는 함수
        private Node FindNode(T item)
        {
            if (root == null)                           // 항이 하나도 없으면
                return null;                                // null 반환

            Node current = root;                        // 기준(현재)노드는 최상위노드
            while (current != null)                     // 기준노드가 있으면
            {
                if (item.CompareTo(current.Item) < 0)       // 현재노드의 데이터값이 찾고자 하는 값보다 작은 경우
                {
                    current = current.Left;                     // 왼쪽 자식부터 다시 찾기 시작
                }
                else if (item.CompareTo(current.Item) > 0)  // 현재노드의 데이터값이 찾고자 하는 값보다 큰 경우
                {
                    current = current.Right;                    // 오른쪽 자식부터 다시 찾기 시작
                }
                else                                        // 현재노드의 값이 찾고자 하는 값과 같은 경우
                    return current;                             // 찾음
            }
            return null;                        // 못찾았으면 null 반환
        }

        // cutValue변수로 값 추출 함수 (성공여부 bool)
        public bool TryGetValue(T item, out T outValue)
        {
            if (root == null)                       // 항이 하나도 없을 때
            {
                outValue = default(T);                  // 기본값(null)과 false 반환
                return false;
            }

            Node findNode = FindNode(item);         // 찾기 시도
            if (findNode == null)                   // 없으면
            {
                outValue = default(T);                  // 기본값(null)과 false 반환
                return false;
            }
            else                                    // 있으면
            {
                outValue = findNode.Item;               // 찾은노드의 값과 true 반환
                return true;
            }
        }

        // Remove함수를 위한 지우기 함수
        private void EraseNode(Node node)
        {
            if (node.HasNoChild)                                // 1. 자식노드가 없는 노드일 경우
            {
                if (node.IsLeftChild)                                   // 자신이 왼쪽자식일 때
                    node.Parent.Left = null;                                // 부모노드의 왼쪽자식(자신)을 지운다
                else if (node.IsRightChild)                             // 자신이 오른쪽자식일 때
                    node.Parent.Right = null;                               // 부모노드의 오른쪽자식(자신)을 지운다
                else                                                    // 자신의 자식노드가 없고 자신이 자식노드가 이니므로 본노드는 root노드
                    root = null;                                            // 본(root)노드 제거 
            }
            else if (node.HasLeftChild || node.HasRightChild)   // 2. 자식노드가 1개인 노드일 경우 ; (1,0) or (0,1) 이므로 (1,1)은 불가능
            {
                Node parent = node.Parent;                              // 부모노드 인스턴스 설정
                Node child = node.HasLeftChild ? node.Left : node.Right;// 자식노드 설정(자신의 자식노드가 왼쪽노드면 왼쪽노드 아니면 오른쪽노드)

                if (node.IsLeftChild)                                   // 자신이 왼쪽 자식일 때
                {
                    parent.Left = child;                                    // 자신의 자식노드를 자신의 위치로 변경
                    child.Parent = parent;                                  // 자식노드의 부모노드를 연결
                }
                else if (node.IsRightChild)                             // 자신이 오른쪽 자식일 때
                {
                    parent.Right = child;                                   // 자신의 자식노드를 자신의 위치로 변경
                    child.Parent = parent;                                  // 자식노드의 부모노드를 연결
                }
                else                                                    // 자식노드가 1개이고 부모노드가 없으면 본노드는 root노드                               
                {
                    root = child;                                           // 자식노드를 자신의 위치로 변경
                    child.Parent = null;                                    // 왕위를 계승했으므로 자식노드의 윗사람은 없음
                }
            }
            else                                                // 1. 자식노드가 2개인 노드일 경우
            {
                Node replaceNode = node.Left;                           // 계승자 노드는 왼쪽 노드 (첫 설정)
                while (replaceNode.Right != null)                           // 처음 왼쪽 노드의 가장 오른쪽 노드까지 반복
                    replaceNode = replaceNode.Right;                        // (계승자 노드 값의 바로 다음으로 큰 값)
                node.Item = replaceNode.Item;                           // 값 가져오기
                /* 위의 코드와 원리는 같음
                Node replaceNode = node.Right;
                while (replaceNode.Left != null)
                    replaceNode = replaceNode.Left;
                node.Item = replaceNode.Item;
                */
                EraseNode(replaceNode);                                 // 가져온 노드의 원래위치 제거 (본 함수의 1번으로 갑)
            }
        }

        // 제거 함수
        public bool Remove(T item)
        {
            if (root == null)                           // 항이 하나도 없으면 실패
                return false;

            Node findNode = FindNode(item);             // 찾기 시도
            if (findNode == null)                           // 없으면
                return false;                                   // 실패
            else                                            // 있으면
            {
                EraseNode(findNode);                            // 제거
                return true;                                    // 성공 반환
            }
        }

        // 해당노드부터 출력 (오름차순)
        public void Print(Node node)
        {
            if (node.Left != null)              // 왼쪽 자식노드가 있으면
                Print(node.Left);                   // 왼쪽 자식노드 기준으로 본함수 호출

            Console.WriteLine(node.Item);       // 왼쪽 먼저 출력 후 오른쪽 설정(왼쪽이 없으면 전에 설정한 오른쪽 노드값이 출력)

            if (node.Right != null)             // 오른쪽 자식노드가 있으면
                Print(node.Right);                  // 오른쪽 자식노드 기준으로 본함수 호출
        }
        // 전체 출력 함수
        public void Print()
        {
            Print(root);                                // 해당노드 = root노드
        }

        internal class Node
        {
            private T item;             // 값 데이터
            private Node parent;        // 부모노드
            private Node left;          // 왼쪽 자식노드
            private Node right;         // 오른쪽 자식노드

            public Node(T item, Node parent, Node left, Node right)         // 생성자
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }

            // 노드 Property
            public T Item { get { return item; } set { item = value; } }
            public Node Parent { get { return parent; } set { parent = value; } }
            public Node Left { get { return left; } set { left = value; } }
            public Node Right { get { return right; } set { right = value; } }

            // 노드의 포지션 참거짓 여부
            public bool IsRootNode { get { return parent == null; } }
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }
            public bool IsRightChild { get { return parent != null && parent.right == this; } }

            // 자식노드 존재여부
            public bool HasNoChild { get { return left == null && right == null; } }
            public bool HasLeftChild { get { return left != null && right == null; } }
            public bool HasRightChild { get { return left == null && right != null; } }
            public bool HasBothChild { get { return left != null && right != null; } }
        }
    }
}
