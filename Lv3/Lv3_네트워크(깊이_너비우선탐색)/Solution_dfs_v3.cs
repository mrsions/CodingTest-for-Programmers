///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/43162?language=csharp</source>
///// <coding>12:43~12:44</coding>
///// <summary>
///// 깊아탐색
///// Simple Benchmark 1356 / 4.940s = 36433.909 cpt  || Alloc: 60148.1b
///// </summary>
//public class Solution
//{
//    int networkCount = 0;
//    int[,] computers;
//    int[] networks;

//    public int solution(int n, int[,] computers)
//    {
//        this.computers = computers;
//        this.networks = new int[n];

//        int[] networks = new int[n];
//        for (int i = 0; i < n; i++)
//        {
//            Resolve(i, networks[i]);
//        }

//        return networkCount;
//    }

//    private void Resolve(int i, int netId)
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

//            Resolve(j, netId);
//        }
//    }
//}