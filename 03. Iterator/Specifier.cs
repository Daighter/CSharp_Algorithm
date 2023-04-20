using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specifier
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
            foreach (int i in array)
            {
                Console.Write(i);
                Console.Write(", ");
            }
            Console.WriteLine();
        }

        public static void Sort(int[] array)
        {
            Console.WriteLine();
            Sort(array, AscendingOrder);
            Console.WriteLine();
            Sort(array, DescendingOrder);
            Console.WriteLine();
            Sort(array, AbsoluteOrder);
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
