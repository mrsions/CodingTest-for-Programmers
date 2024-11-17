///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/43162?language=csharp</source>
///// <reading>11:30~11:37</reading>
///// <coding>11:38~11:58</coding>
///// <summary>
///// 깊아탐색
///// Simple Benchmark 349 / 1.926s = 55193.352 cpt  || Alloc: 9470466.7b
///// </summary>

//public class Solution
//{
//    int networkCount = 0;

//    public int solution(int n, int[,] computers)
//    {
//        int[] networks = new int[n];
//        for (int i = 0; i < n; i++)
//        {
//            Resolve(i, computers, networks, networks[i]);
//        }

//        return networkCount;
//    }

//    private void Resolve(int i, int[,] computers, int[] networks, int netId)
//    {
//        if (networks[i] != 0) return;

//        if (netId == 0)
//        {
//            netId = ++networkCount;
//        }

//        networks[i] = netId;

//        for (int j = 0; j < networks.Length; j++)
//        {
//            if (i == j || computers[i, j] == 0) continue;

//            Resolve(j, computers, networks, netId);
//        }
//    }
//}