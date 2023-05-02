using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230502
{
    internal class Dijkstra
    {
        /******************************************************
		 * 다익스트라 알고리즘 (Dijkstra Algorithm)
		 * 
		 * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
		 * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
		 * 해당 노드를 거쳐 다른 노드로 가는 비용 계산
		 ******************************************************/

        const int INF = 99999;       // INF 연산시에 오버플로우를 방지하기 위해 int.MaxValue사용을 안함 

        public static void ShortestPath(in int[,] graph, in int start, out int[] distance, out int[] path)
        {
            int size = graph.GetLength(0);                      // 전체 정점 갯수
            bool[] visited = new bool[size];                    // 방문 여부 2차원 배열

            distance = new int[size];                           // 출력 전용 거리 변수 선언
            path = new int[size];                               // 지나온 정점 선언

            // 현재 정점과 연결된 정점을 찾는 반복문
            for (int i = 0; i < size; i++)                      // 전체 정점 수만큼 반복
            {
                distance[i] = graph[start, i];                      // (start부터 i)의 거리는 graph(start부터 i)의 거리(가중치)
                path[i] = graph[start, i] < INF ? start : -1;       // 지나온 정점 = i가 연결 되어있으면 start, 아니면 -1
            }

            // 연결된 정점 중 가장 가까운 정점을 찾는 반복문
            for (int i = 0; i < size; i++)                      // 전체 정점 수만큼 반복
            {
                // 1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
                int next = -1;                                  // 다음정점 초기화
                int minCost = INF;                              // 최소거리 초기화
                for (int j = 0; j < size; j++)                  // 전체 정점 수만큼 반복
                {
                    if (!visited[j] &&                              // 방문하지 않았고
                        distance[j] < minCost)                      // 연결되어 있으면
                    {
                        next = j;                                       // 다음 정점을 설정
                        minCost = distance[j];                          // 최소거리 = (start부터 i)의 거리
                    }
                }
                if (next < 0)                                       // 다음 정점이 없으면 탈출
                    break;

                // 2. 직접연결된 거리보다 거쳐서 더 짧아진다면 갱신.
                for (int j = 0; j < size; j++)                  // 전체 정점 수만큼 반복
                {
                    // distance[j] : 목적지까지 직접 연결된 거리
                    // distance[next] : 탐색중인 정점까지 거리
                    // graph[next, j] : 탐색중인 정점부터 목적지의 거리
                    if (distance[j] > distance[next] + graph[next, j])  // (start부터 j)의 거리 > (start부터 next) + (next부터 next바로다음(j))
                    {                                                       // (다이렉트로 가는 것 보다 거쳐가는 것이 더 빠르면)
                        distance[j] = distance[next] + graph[next, j];  // (start부터 j)의 거리를 거쳐가는 거리로 갱신
                        path[j] = next;                                 // 지나온 정점 설정
                    }
                }
                visited[next] = true;                           // 지나온 정점을 방문여부 배열에 입력
            }
        }
    }
}