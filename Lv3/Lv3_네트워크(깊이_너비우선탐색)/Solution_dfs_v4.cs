///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/43162?language=csharp</source>
///// <summary>
///// Simple Benchmark 1402 / 4.949s = 35299.744 cpt  || Alloc: 30691.7b
///// 깊아탐색
///// </summary>
//public class Solution
//{
//    public int solution(int n, int[,] computers)
//    {
//        int networkCount = 0;
//        int[] networks = new int[n];
//        for (int i = 0; i < n; i++)
//        {
//            Resolve(i, computers, networks, networks[i], ref networkCount);
//        }

//        return networkCount;
//    }

//    private void Resolve(int i, int[,] computers, int[] networks, int netId, ref int networkCount)
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

//            Resolve(j, computers, networks, netId, ref networkCount);
//        }
//    }
//}