using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportStructure
{
    //              모든 자료형<키, 데이터> : 키의 자료형은 비교확인을 위해 제한 
    internal class Dictionary<TKey, TValue> where TKey : IEquatable<TKey>
    {
        private const int DefaultCapacity = 1000;           // 초기 테이블 용량

        private struct Entry                                // 등록 구조체
        {
            public enum State { None, Using, Deleted }          // 상태 열거형 { 비어있음, 사용중, 삭제됨(중복 데이터의 위치 추적을 위함) }

            public State state;                                 // 상태
            public int hashCode;                                // 해시코드
            public TKey key;                                    // 키
            public TValue value;                                // 데이터
        }

        private Entry[] table;                              // 등록 배열

        public Dictionary()                                 // 생성자
        {
            table = new Entry[DefaultCapacity];             // 배열[초기 용량]
        }

        public TValue this[TKey key]                        // 키로 데이터를 찾는 property
        {
            get
            {
                int index = Math.Abs(key.GetHashCode() % table.Length); // 1. key를 index로 해싱

                while (table[index].state == Entry.State.Using)         // 2. index 자리가 사용중이면
                {
                    if (key.Equals(table[index].key))                       // 3-1. 동일한 키값일 때
                    {
                        return table[index].value;                              // 반환
                    }
                    if (table[index].state != Entry.State.Using)            // 3-2. index 자리가 비어있을 때
                    {
                        break;                                                  // 예외처리를 위해 탈출
                    }

                    index = index >= table.Length - 1 ? index + 1 : 0;      // 3-3. 다음 index으로 이동 (선형탐사)
                    // index가 해시테이블의 용량보다 크면 0으로 감
                }

                throw new KeyNotFoundException();                       // 예외처리
            }
            set
            {
                int index = Math.Abs(key.GetHashCode() % table.Length); // 1. key를 index로 해싱

                while (table[index].state == Entry.State.Using)         // 2. index 자리가 사용중이면
                {
                    if (key.Equals(table[index].key))                       // 3-1. 동일한 키값일 때
                    {
                        table[index].value = value;                             // 덮어쓰기
                    }
                    if (table[index].state != Entry.State.Using)            // 3-2. index 자리가 비어있을 때
                    {
                        break;                                                  // 예외처리를 위해 탈출
                    }

                    index = index >= table.Length - 1 ? index + 1 : 0;      // 3-3. 다음 index으로 이동 (선형탐사)
                    // index가 해시테이블의 용량보다 크면 0으로 감
                }
            }
        }

        // 등록 함수
        public void Add(TKey key, TValue value)
        {
            int index = Math.Abs(key.GetHashCode() % table.Length); // 1. key를 index로 해싱

            while (table[index].state == Entry.State.Using)         // 2. index 자리가 사용중이면
            {
                if (key.Equals(table[index].key))                       // 3-1. 동일한 키값일 때
                {
                    throw new ArgumentException();                          // 예외처리 (C# Dictionary는 중복 키를 허용하지 않음)
                }

                index = index >= table.Length - 1 ? index + 1 : 0;      // 3-3. 다음 index으로 이동 (선형탐사)
                // index가 해시테이블의 용량보다 크면 0으로 감
            }

            table[index].hashCode = key.GetHashCode();              // 3. 사용중이 아닌 index를 발견한 경우 그 위치에 저★장
            table[index].key = key;
            table[index].value = value;
            table[index].state = Entry.State.Using;
        }

        // 제거 함수
        public bool Remove(TKey key)
        {
            int index = Math.Abs(key.GetHashCode() % table.Length); // 1. key를 index로 해싱

            while (table[index].state == Entry.State.Using)         // 2. index 자리가 사용중이면
            {
                if (key.Equals(table[index].key))                       // 3-2. 동일한 키값알 때
                {
                    table[index].state = Entry.State.Deleted;               // 지운상태로 표시
                }
                if (table[index].state == Entry.State.None)             // 3-2. index 자리가 비어있을 때 (오류)
                {
                    break;                                                  // 에외처리를 위해 탈출
                }

                index = index >= table.Length - 1 ? index + 1 : 0;      // 3-3. 다음 index으로 이동 (선형탐사)
                // index가 해시테이블의 용량보다 크면 0으로 감
            }

            throw new InvalidOperationException();                  // 예외처리
        }
    }
}
