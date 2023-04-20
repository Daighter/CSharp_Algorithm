using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._Iterator
{
    internal class Specifier
    {
        public delegate int Compare(int left, int right);

        // <대리자의 지정자로서 사용>
        // 델리게이트를 지정자로 사용하여 미완성 상태의 함수를 구성
        // 매개변수로 전달한 델리게이트를 기준으로 함수를 완성하여 호출함
        public static void Sort(int[] array, Compare compare)
        {
            // 정렬알고리즘 Bubble Sort
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (compare(array[i], array[j]) > 0)
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public static void Test()
        {
            int[] array = { 3, -2, 1, -4, 9, -8, 7, -6, 5 };

            Sort(array, AscendingOrder);    // { -8, -6, -4, -2, 1, 3, 5, 7, 9 }
            Sort(array, DescendingOrder);   // { 9, 7, 5, 3, 1, -2, -4, -6, -8 }
            Sort(array, AbsoluteOrder);     // { 1, -2, 3, -4, 5, -6, 7, -8, 9 }
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

        // 절대값 정렬
        public static int AbsoluteOrder(int left, int right)
        {
            if (Math.Abs(left) > Math.Abs(right))
                return 1;
            else if (Math.Abs(left) < Math.Abs(right))
                return -1;
            else
                return 0;
        }
    }
}
