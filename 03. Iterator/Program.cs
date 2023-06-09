﻿using System;

namespace _03._Iterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Array Sort
            int[] array = new int[10];
            Random random = new Random();
            for (int i = 0; i < 10; i++) { array[i] = random.Next(-100, 100); }
            foreach (int i in array)
            {
                Console.Write(i);
                Console.Write(", ");
            }
            Console.WriteLine();

            Specifier.Specifier.Sort(array);

            // List 반복기
            Iterator.List<int> list = new Iterator.List<int>();
            /*for (int i = 1; i <= 5; i++) list.Add(i*i);

            list.Average(list);

            list.Remove(2);
            
            foreach (int i in list) Console.WriteLine(i);       // (Iterator.)list에 IEnumerable 있으니 가능한 부분
            */
            /*Random random2 = new Random();
            for (int i = 0; i < 10; i++) { list.Add(random2.Next(-100, 100)); }

            IEnumerator<int> listIter = list.GetEnumerator();

            Console.WriteLine();
            Console.WriteLine(listIter.Current);
            while (listIter.MoveNext())                             // foreach와 같은 기능
            {
                Console.Write(listIter.Current);
                Console.Write(", ");
            }
            Console.WriteLine();
            listIter.Dispose();

            list.Sort(list);*/

            /*
            // LinkedList 반복기
            Iterator.LinkedList<int> linkedList = new Iterator.LinkedList<int>();
            for (int i = 1; i <= 5; i++) linkedList.AddLast(i*i);

            linkedList.Average(linkedList);

            linkedList.Remove(3);

            foreach (int i in linkedList) Console.WriteLine(i);

            IEnumerator<int> linkedListIter = linkedList.GetEnumerator();

            Console.WriteLine();
            Console.WriteLine(linkedListIter.Current);
            while (linkedListIter.MoveNext())
            {
                Console.WriteLine(linkedListIter.Current);
            }
            Console.WriteLine(linkedListIter.Current);
            linkedListIter.Dispose();*/
        }

        /******************************************************
		 * 반복기 (Enumerator(Iterator))
		 * 
		 * 자료구조에 저장되어 있는 요소들을 순회하는 인터페이스
		 ******************************************************/

        void Iterator()
        {
            // 대부분의 자료구조가 반복기를 지원함
            // 반복기를 이용한 기능을 구현할 경우, 그 기능은 대부분의 자료구조를 호환할 수 있음
            List<int> list                  = new List<int>();
            LinkedList<int> linkedList      = new LinkedList<int>();

            Stack<int> stack                = new Stack<int>();
            Queue<int> queue                = new Queue<int>();
            SortedList<int, int> sList      = new SortedList<int, int>();
            SortedSet<int> set              = new SortedSet<int>();
            SortedDictionary<int, int> map  = new SortedDictionary<int, int>();
            Dictionary<int, int> dic        = new Dictionary<int, int>();

            // 반복기를 이용한 순회
            // foreach 반복문은 데이터집합의 반복기를 통해서 단계별로 반복
            // 즉, 반복기가 있다면 foreach 반복문으로 순회 가능
            foreach (int i in list) { }
            foreach (int i in linkedList) { }
            foreach (int i in stack) { }
            foreach (int i in queue) { }
            foreach (int i in set) { }
            foreach (KeyValuePair<int, int> i in sList) { }
            foreach (KeyValuePair<int, int> i in map) { }
            foreach (KeyValuePair<int, int> i in dic) { }
            foreach (int i in IterFunc()) { }

            // 반복기 직접조작
            List<string> strings = new List<string>();
            for (int i = 0; i < 5; i++) strings.Add($"{i}데이터");

            IEnumerator<string> iter = strings.GetEnumerator();
            iter.MoveNext();                // 반환형 bool
            Console.WriteLine(iter.Current);    // output : 0데이터
            iter.MoveNext();
            Console.WriteLine(iter.Current);    // output : 1데이터

            iter.Reset();                       // Current를 처음을 향하도록 변경
            while (iter.MoveNext())                 // iter.Movenext가 true(값이 있을 때)일 때까지
            {
                Console.WriteLine(iter.Current);
            }
        }

        static void FindInt(IEnumerable<int> container, int value)
        {
            IEnumerator<int> iter = container.GetEnumerator();

            iter.Reset();
            while (iter.MoveNext())
            {
                if (iter.Current == value)
                    Console.WriteLine("찾았음");
            }
            iter.Dispose();
            Console.WriteLine("못찾음");
        }

        IEnumerable<int> IterFunc()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
    }
}