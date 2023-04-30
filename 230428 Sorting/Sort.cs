using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportStructure
{
    internal class Sort
    {
        /******************************************************
		 * 선형 정렬
		 * 
		 * 1개의 요소를 재위치시키기 위해 전체를 확인하는 정렬
		 * n개의 요소를 재위치시키기 위해 n개를 확인하는 정렬
		 * 시간복잡도 : O(N^2)
		 ******************************************************/

        // <선택정렬>
        // 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
        public static void SelectionSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)            // 매개변수 리스트의 자료 수 만큼 반복
            {
                int minIndex = i;                               // 최솟값의 인덱스 변수
                for (int j = i + 1; j < list.Count; j++)        // i와 i+1부터 끝까지 비교
                {
                    if (list[j] < list[minIndex])                   // 매개변수 리스트의 검사항이 현재 최솟값보다 작으면
                        minIndex = j;                               // 갱신
                }
                Swap(list, i, minIndex);                        // 매개변수 리스트의 i자리와 최솟값자리를 서로 바꿈
            }
            // 구동 원리
            // 처음부터 끝까지 탐색하고 제일 작은 자료를 앞으로 빼는걸 반복
        }

        // <삽입정렬>
        // 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
        // 역순일 때 최악의 경우
        public static void InsertionSort(IList<int> list)
        {
            for (int i = 1; i < list.Count; i++)                // 매개변수 리스트의 두번째부터 끝까지 반복
            {
                int key = list[i];                              // 옮길항
                int j;                                          // 비교 항 변수
                for (j = i - 1; j >= 0 && key < list[j]; j--)   // 옮길항의 바로 전항 부터 하나씩 내려가며 0이상이고 옮길항보다 크면 반복
                {
                    list[j + 1] = list[j];                          // 다음항에 현재 검사항 복사하고
                                                                    // (구조상 검사항 앞에는 보다 큰항이 1개만 있음)
                }
                list[j + 1] = key;                              // j-- 해주고 다음항(원래 j자리)에 옮길 항 복사

                // 1 2 3 9 5 4
                // 1 2 3 9 9 4  key = 5
                // 1 2 3 5 9 4
            }
            // 구동 원리
            // 두번째부터 올라가며 탐색중 바로전항보다 작은항이 나오면 내려가며 같거나 작은게 나오면 멈춤을 반복
        }

        // <버블정렬>
        // 서로 인접한 데이터를 비교하여 정렬
        public static void BubbleSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)        // 매개변수 리스트의 처음부터 끝까지 반복(횟수 ; i값 안씀)
            {
                for (int j = 1; j < list.Count; j++)        // 매개변수 리스트의 두번째무터 끝까지 반복 j = 검사
                {
                    if (list[j - 1] > list[j])                  // j바로전항이 j항보다 크면
                        Swap(list, j - 1, j);                       // 자리바꿈(큰게 계속 뒤로 감)
                }
            }
            // 구동 원리
            // 처음부터 끝까지 제일 큰거만 올라감
        }

        /******************************************************
		 * 분할정복 정렬
		 * 
		 * 1개의 요소를 재위치시키기 위해 전체의 1/2를 확인하는 정렬
		 * n개의 요소를 재위치시키기 위해 n/2개를 확인하는 정렬
		 * 시간복잡도 : O(NlogN)
		 ******************************************************/

        // <힙정렬>
        // 힙을 이용하여 우선순위가 가장 높은 요소부터 가져와 정렬
        // 자료를 정렬할때 원본 배열속의 같은 크기의 자료들의 순서가 바뀔(깨질) 수 있다
        public static void HeapSort(IList<int> list)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            for (int i = 0; i < list.Count; i++)    // 매개변수 리스트의 처음부터 끝까지 반복
            {
                pq.Enqueue(list[i], list[i]);           // 우선순위큐에 데이터==우선순위 추가
            }

            for (int i = 0; i < list.Count; i++)    // 매개변수 리스트의 처음부터 끝까지 반복
            {
                list[i] = pq.Dequeue();                 // 우선순위 높은 순으로 재배치
            }
            // 구동 원리
            // 우선순위큐에 리스트 배열의 데이터를 추가하며 정렬하고
            // Dequeue를 사용해서 기존 리스트에 재정렬
        }

        // <합병정렬>
        // 데이터를 2분할하여 정렬 후 합병
        // 추가적인 메모리가 더 필요하다
        public static void MergeSort(IList<int> list, int left, int right)  // left = 시작 인덱스, right = List.Length-1
        {
            if (left == right) return;              // 처음과 끝이 같으면 종료

            int mid = (left + right) / 2;           // 중간 인덱스 계산
            MergeSort(list, left, mid);             // 재귀(처음부터 중간까지)
            MergeSort(list, mid + 1, right);        // 재귀(중간+1부터 끝까지)
            Merge(list, left, mid, right);          // 합병

            // 구동 원리
            // 전체 배열의 절반부분을 나누는 것을 반복하다 분할된 데이터가 1개가 되는 지점에서
            // 직전에 분할한 두 부분의 최솟값을 비교하며 새 리스트에 추가하고
            // 이렇게 나온 새 리스트를 원래 부분에 덮어쓰는 것을 반복하며 전제 배열을 정렬한다 
        }

        // 합병 함수
        public static void Merge(IList<int> list, int left, int mid, int right)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = left;                           // 처음부터
            int rightIndex = mid + 1;                       // 중간이후부터

            // 분할 정렬된 List를 병합
            while (leftIndex <= mid && rightIndex <= right)
            {
                if (list[leftIndex] < list[rightIndex])         // 왼쪽 값이 더 작으면
                    sortedList.Add(list[leftIndex++]);              // 왼쪽값 추가하고 왼쪽인덱스 증가
                else                                            // 오른쪽 값이 더 크거나 같으면
                    sortedList.Add(list[rightIndex++]);             // 오른쪽 값 추가하고 오른쪽인덱스
            }

            if (leftIndex > mid)    // 왼쪽 List가 먼저 소진 됐을 경우
            {
                for (int i = rightIndex; i <= right; i++)       // 끊긴 시점부터 끝까지(오른쪽)
                    sortedList.Add(list[i]);                        // 추가
            }
            else  // 오른쪽 List가 먼저 소진 됐을 경우
            {
                for (int i = leftIndex; i <= mid; i++)          // 끊긴 시점부터 중간까지(왼쪽)
                    sortedList.Add(list[i]);                        // 추가
            }

            // 정렬된 sortedList를 list로 재복사
            for (int i = left; i <= right; i++)             // 처음부터 끝까지
            {
                list[i] = sortedList[i - left];             // i - left = 0(sortedList의 첫항)
            }
        }

        // <퀵정렬>
        // 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
        /* HDD/SSD(창고), RAM(책상), CPU-CASH(손), 배열(책장), 배열일부(책 1권)
         * CASH의 특성상 자료를 가져올 때 자료가 포함된 배열의 일정 범위를 한번에 가져와 사용하는데
         * 우선순위(완전2진트리)큐 정렬은 다음으로 큰 자료가 멀리 떨어져있는 경우가 많기 때문에
         * 다음으로 큰 자료가 CASH가 가져온 배열의 범위안에 없는 경우가 많아 다시 가져와야 하므로 속도가 느려진다
         * (최악의 경우 O(n^2)까지 소요된다
         */
        public static void QuickSort(IList<int> list, int start, int end)
        {
            if (start >= end) return;           // 검사 처음지점과 끝지점이 반대이면 종료

            int pivotIndex = start;             // 피벗을 첫 항으로 지정
            int leftIndex = pivotIndex + 1;     // 검사 왼쪽 시작지점 = 피벗 다음항
            int rightIndex = end;               // 검사 오른쪽 시작지점 = 끝지점

            while (leftIndex <= rightIndex) // 엇갈릴때까지 반복
            {
                // pivot보다 큰 값을 만날때까지
                while (list[leftIndex] <= list[pivotIndex] && leftIndex < end)          // 검사왼쪽지점이 검사오른쪽지점 이히이고 끝지점보다 작으면 반복
                    leftIndex++;                                                            // 계속 올라감

                while (list[rightIndex] >= list[pivotIndex] && rightIndex > start)      // 검사 오른쪽지점이 검사왼쪽지점 이상이고 시작지점보다 크면 반복
                    rightIndex--;                                                           // 계속 내려감

                if (leftIndex < rightIndex)                                             // 엇갈리지 않았다면
                    Swap(list, leftIndex, rightIndex);                                      // 서로 자리바꾸기
                else                                                                    // 엇갈렸다면
                    Swap(list, pivotIndex, rightIndex);                                     // 피벗과 오른쪽지점 자리바꾸기
                // 5 1 3 2 4 8 6 9 7
                // 4 1 3 2 5 8 6 9 7
            }                                                                       // 피벗이 중간에 들어오면 while 탈출
                                                                                    // 현재 rightIndex는 피벗
            QuickSort(list, start, rightIndex - 1);                                 // 재귀(들어온 피벗보다 왼쪽 부분 재귀)
            // 4 1 3 2
            // 1 3 2 4
            QuickSort(list, rightIndex + 1, end);                                   // 재귀(들어온 피벗보다 오른쪽 부분 재귀)
                                                                                    // 8 6 9 7
                                                                                    // 

            // 맨앞을 피벗으로 삼고 뒤의 배열중 처음부터 올라가는 왼쪽지점과 맨끝부터 내려오는 오른쪽지점을 만들고
            // 왼쪽 지점에서는 피벗보다 큰 데이터를 발견하고, 오른쪽지점에서는 피벗보다 작은 데이터를 발견하면
            // 각 지점의 데이터를 서로 교체하는 것을 반복하다 두 지점이 엇갈리면(정렬 완료되면)
            // 오른쪽지점의 마지막 지점(피벗보다 바로 아래의 작은 수)과 피벗의 자리를 바꾸고
            // 바뀐 피벗의 자리를 기준으로 양 쪽의 배열을 재귀함수로 정렬 한다
        }

        // 두 자리 교체 함수
        private static void Swap(IList<int> list, int left, int right)
        {
            int temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }
}