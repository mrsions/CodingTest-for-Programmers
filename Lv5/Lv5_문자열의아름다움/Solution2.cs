///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/68938?language=csharp</source>
///// <read>01:02~01:05</read>
///// <solveTime>01:06~01:13</solveTime>
///// <summary>
///// 
///// </summary>

//using System;

//public class Solution
//{
//    struct Node
//    {
//        public int alpha;
//        public int length;
//    };

//    Node[] stNode = new Node[300000];
//    int NodeCnt;

//    struct Entry
//    {
//        public int Length;
//        public int Count;
//    };

//    Entry[,] stTable = new Entry[26, 300000];
//    int[] EntryCnt = new int[26];

//    long Calc(int s_len, int e_len)
//    {
//        int N, K;
//        if (s_len > e_len)
//        {
//            N = e_len;
//            K = s_len;
//        }
//        else
//        {
//            N = s_len;
//            K = e_len;
//        }

//        if (N == 1) return N * K;

//        return ((N + K + 1) * (N + 1) * N / 2) - ((N + 1) * N * (2 * N + 1) / 3);
//    }

//    long MaxBeauty(long size)
//    {
//        if (size == 1)
//            return 0;

//        return ((size * size * (size - 1)) / 2) - (size * (size - 1) * ((2 * size) - 1) / 6);
//    }

//    public long solution(string s)
//    {
//        long answer = 0;

//        answer = MaxBeauty(s.Length);

//        int len = 1;
//        stNode[NodeCnt].alpha = s[0];

//        for (int i = 1; i < s.Length; i++)
//        {
//            if (stNode[NodeCnt].alpha == s[i])
//            {
//                len++;
//            }
//            else
//            {
//                stNode[NodeCnt++].length = len;
//                stNode[NodeCnt].alpha = s[i];
//                len = 1;
//            }
//        }
//        stNode[NodeCnt++].length = len;

//        if (NodeCnt == 1) return 0;

//        for (int i = 0; i < NodeCnt; i++)
//        {
//            int idx = stNode[i].alpha - 'a';

//            answer -= MaxBeauty(stNode[i].length);

//            for (int j = 0; j < EntryCnt[idx]; j++)
//            {
//                answer -= (stTable[idx,j].Count * Calc(stTable[idx,j].Length, stNode[i].length));
//            }

//            int cur = 0;
//            while (true)
//            {
//                if (stTable[idx,cur].Count == 0)
//                {
//                    stTable[idx,cur].Length = stNode[i].length;
//                    stTable[idx,cur].Count++;
//                    EntryCnt[idx]++;
//                    break;
//                }

//                if (stTable[idx,cur].Length == stNode[i].length)
//                {
//                    stTable[idx,cur].Count++;
//                    break;
//                }

//                cur++;
//            }
//        }

//        return answer;
//    }
//}