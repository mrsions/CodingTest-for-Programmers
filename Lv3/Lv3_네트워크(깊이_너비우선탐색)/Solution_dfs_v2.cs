///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/43162?language=csharp</source>
///// <coding>12:20~12:40</coding>
///// <summary>
///// 깊아탐색
///// Simple Benchmark 1480 / 4.946s = 33416.360 cpt  || Alloc: 30691.0b
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