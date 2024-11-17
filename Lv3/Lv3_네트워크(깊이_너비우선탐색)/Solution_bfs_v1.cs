
using System.Collections.Generic;

/// <source>https://school.programmers.co.kr/learn/courses/30/lessons/43162?language=csharp</source>
/// <coding>01:02~</coding>
/// <summary>
/// 너비탐색
/// Simple Benchmark 1689 / 4.941s = 29255.457 cpt  || Alloc: 115473.7b
/// </summary>

public class Solution
{
    int networkCount = 0;

    public int solution(int n, int[,] computers)
    {
        int[] networks = new int[n];
        for (int i = 0; i < n; i++)
        {
            if (networks[i] == 0)
            {
                BFS(i, computers, networks);
            }
        }

        return networkCount;
    }

    private void BFS(int start, int[,] computers, int[] networks)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        networks[start] = ++networkCount; // 새로운 네트워크 ID 할당

        while (queue.Count > 0)
        {
            int i = queue.Dequeue();

            for (int j = 0; j < networks.Length; j++)
            {
                // 자기 자신을 제외하고, 아직 방문하지 않았으며 연결된 컴퓨터들을 큐에 추가
                if (i != j && computers[i, j] == 1 && networks[j] == 0)
                {
                    queue.Enqueue(j);
                    networks[j] = networkCount; // 같은 네트워크 ID 할당
                }
            }
        }
    }
}