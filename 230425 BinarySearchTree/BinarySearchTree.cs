using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportStructure
{
    internal class BinarySearchTree<T> where T : IComparable<T>             // 비교가 가능한 자료형만
    {
        private Node root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        public bool Add(T item)                     // 중복 추가 여부 확인을 위한 bool 리턴
        {
            Node newNode = new Node(item, null, null, null);

            if (root == null)
            {
                root = newNode;
                return true;
            }

            Node current = root;
            while (current != null)
            {
                // 비교해서 더 작은 경우 왼쪽으로 감
                if (item.CompareTo(current.Item) < 0)
                {
                    // 비교노드가 왼쪽 자식이 있는 경우
                    if (current.Left != null)
                    {
                        // 왼쪽 자식과 또 비교하기 위해 current 왼쪽자식으로 설정
                        current = current.Left;
                    }
                    // 비교노드가 왼쪽 자식이 없는 경우
                    else
                    {
                        // 그 자리사 지금 추가될 자리
                        current.Left = newNode;
                        newNode.Parent = current;
                        break;
                    }

                }
                // 비교해서 더 큰 경우 오른쪽으로 감
                else if (item.CompareTo(current.Item) > 0)
                {
                    // 비교노드가 오른쪽 자식이 있는 경우
                    if (current.Right != null)
                    {
                        // 오른쪽 자식과 또 비교하기 위해 current 오른쪽자식으로 설정
                        current = current.Right;
                    }
                    // 비교노드가 오른쪽 자식이 없는 경우
                    else
                    {
                        // 그 자리사 지금 추가될 자리
                        current.Right = newNode;
                        newNode.Parent = current;
                        break;
                    }
                }
                // 동일한 데이터가 들어온 경우
                else
                    return false;
            }
            return true;
        }

        private Node FindNode(T item)
        {
            if (root == null)               // 항이 하나도 없으면
                return null;                    // null 반환

            Node current = root;            // 기준(현재)노드는 최상위노드
            while (current != null)         // 기준노드가 있으면
            {
                // 현재노드의 값이 찾고자 하는 값모다 작은 경우
                if (item.CompareTo(current.Item) < 0)
                {
                    // 왼쪽 자식부터 다시 찾기 시작
                    current = current.Left;
                }
                // 현재노드의 값이 찾고자 하는 값모다 큰 경우
                else if (item.CompareTo(current.Item) > 0)
                {
                    // 오른쪽 자식부터 다시 찾기 시작
                    current = current.Right;
                }
                // 현재노드의 값이 찾고자 하는 값과 같은 경우
                else
                    return current;     // 찾음
            }
            return null;                        // 못찾았으면 null 반환
        }

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

        private void EraseNode(Node node)
        {
            // 1. 자식노드가 없는 노드일 경우
            if (node.HasNoChild)
            {
                if (node.IsLeftChild)                       // 왼쪽자식일 때
                    node.Parent.Left = null;                    // 부모노드의 왼쪽자식을 지운다
                else if (node.IsRightChild)                 // 오른쪽자식일 때
                    node.Parent.Right = null;                   // 부모노드의 오른쪽자식을 지운다
                else                                        // 
                    root = null;
            }
            // 1. 자식노드가 1개인 노드일 경우
            else if (node.HasLeftChild || node.HasRightChild)
            {
                Node parent = node.Parent;
                Node child = node.HasLeftChild ? node.Left : node.Right;

                if (node.IsLeftChild)
                {
                    parent.Left = child;
                    child.Parent = parent;
                }
                else if (node.IsRightChild)
                {
                    parent.Right = child;
                    child.Parent = parent;
                }
                else
                {
                    root = child;
                    child.Parent = null;
                }
            }
            // 1. 자식노드가 2개인 노드일 경우
            else
            {
                Node replaceNode = node.Left;
                while (replaceNode.Right != null)
                {
                    replaceNode = replaceNode.Right;
                }
                node.Item = replaceNode.Item;
                /* 위의 코드와 원리는 같음
                Node replaceNode = node.Right;
                while (replaceNode.Left != null)
                {
                    replaceNode = replaceNode.Left;
                }
                node.Item = replaceNode.Item;
                */
                EraseNode(replaceNode);
            }
        }

        public bool Remove(T item)
        {
            if (root == null)
                return false;

            Node findNode = FindNode(item);
            if (findNode == null)
            {
                return false;
            }
            else
            {
                EraseNode(findNode);
                return true;
            }
        }

        public void Print()
        {
            Print(root);
        }
        public void Print(Node node)
        {
            if (node.Left != null)
                Print(node.Left);
            Console.WriteLine(node.Item);
            if (node.Right != null)
                Print(node.Right);
        }
        internal class Node
        {
            private T item;
            private Node parent;
            private Node left;
            private Node right;

            public Node(T item, Node parent, Node left, Node right)
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }

            public T Item { get { return item; } set { item = value; } }
            public Node Parent { get { return parent; } set { parent = value; } }
            public Node Left { get { return left; } set { left = value; } }
            public Node Right { get { return right; } set { right = value; } }

            public bool IsRootNode { get { return parent == null; } }
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }
            public bool IsRightChild { get { return parent != null && parent.right == this; } }

            public bool HasNoChild { get { return left == null && right == null; } }
            public bool HasLeftChild { get { return left != null && right == null; } }
            public bool HasRightChild { get { return left == null && right != null; } }
            public bool HasBothChild { get { return left != null && right != null; } }
        }
    }
}
