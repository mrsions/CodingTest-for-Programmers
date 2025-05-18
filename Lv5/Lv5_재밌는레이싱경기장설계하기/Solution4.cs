///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/68938?language=csharp</source>
///// <resolveTime>14:00~14:23</resolveTime>
///// <summary>
///// 가장 기본적인 경우의 수 케이스 시도.
///// </summary>

using System;

public class Solution4
{
    public class Entry
    {
        public int index;
        public int value;

        public Entry(int index, int value)
        {
            this.index = index;
            this.value = value;
        }
    }

    int collectAnswer = -1;
    public int solution(int[] h)
    {
        //if (h.Length % 2 == 0)
        //{
        //    Array.Sort(h);
        //    int[] rst = new int[h.Length];
        //    int mid = h.Length / 2;
        //    for (int i = 0; i < h.Length; i++)
        //    {
        //        if (i % 2 == 0)
        //        {
        //            rst[i] = h[mid + (i / 2)];
        //        }
        //        else
        //        {
        //            rst[i] = h[(i / 2)];
        //        }
        //    }
        //    return GetValue(rst);
        //}

        //int hlen = h.Length;

        //Entry[] entries = new Entry[hlen];
        //for (int i = 0; i < hlen; i++)
        //{
        //    int v = h[i];

        //    //for (int j = 0; j < hlen; j++)
        //    //{
        //    //    ref var a = ref entries[i, j];
        //    //    a.index = j;
        //    //    a.diff = Math.Abs(v - h[j]);
        //    //}

        //    //Array.Sort(entries[i, ]);
        //}

        //if (h.Length > 5)
        //{
        //    var a = h[0];
        //    var b = h[h.Length / 2];
        //    var c = h[h.Length - 1];

        //    var aa = Math.Abs(b - a);
        //    var bb = Math.Abs(b - c);
        //    return aa < bb ? aa : bb;
        //}

        return -1;
    }
    private static int GetValue(int[] heights)
    {
        int minDiff = int.MaxValue;
        for (int i = 1; i < heights.Length; i++)
        {
            int v = heights[i - 1] - heights[i];
            if (v < 0) v = -v;

            if (v < minDiff)
            {
                minDiff = v;
            }
        }
        return minDiff;
    }
}