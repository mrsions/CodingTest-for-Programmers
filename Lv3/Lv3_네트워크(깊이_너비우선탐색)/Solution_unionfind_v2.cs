
///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/43162?language=csharp</source>
///// <coding>12:08~12:15</coding>
///// <summary>
///// union-find 알고리즘
///// Simple Benchmark 1714 / 4.937s = 28805.673 cpt  || Alloc: 30689.5b
///// </summary>
//public class Solution
//{
//    public int solution(int n, int[,] computers)
//    {
//        int answer = 0;
//        int lastNetId = 0;
//        int[] netIds = new int[n];
//        for (int i = 0; i < n; i++)
//        {
//            int netId = netIds[i];
//            if (netId == 0)
//            {
//                netId = ++lastNetId;
//                netIds[i] = netId;
//                answer++;
//            }

//            for (int j = 0; j < n; j++)
//            {
//                if (i == j) continue;

//                if (computers[i, j] == 1)
//                {
//                    int tid = netIds[j];
//                    if (tid == 0)
//                    {
//                        netIds[j] = netId;
//                    }
//                    else if (tid != netId)
//                    {
//                        for (int k = 0; k < netIds.Length; k++)
//                        {
//                            int tnets = netIds[k];
//                            if (netIds[k] == tid)
//                            {
//                                netIds[k] = netId;
//                            }
//                        }
//                        answer--;
//                    }
//                }
//            }
//        }

//        return answer;
//    }
//}