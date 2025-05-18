///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/68938?language=csharp</source>
///// <resolveTime>14:00~14:23</resolveTime>
///// <summary>
///// 가장 기본적인 경우의 수 케이스 시도.
///// </summary>

using System;
using System.Collections.Generic;

public class Solution
{
    int collectAnswer = -1;
    public List<int[]> solutions = new();
    public bool print;

    public int solution(int[] heights)
    {
        int answer = 0;
        collectAnswer = -1;
        GetValueRecursive(heights, 0, ref answer);

        if (print)
        {
            //Array.Sort(heights);
            //Console.WriteLine(string.Join(" ", heights));
            //Console.WriteLine("------");
            solutions.Clear();
            collectAnswer = answer;
            GetValueRecursive(heights, 0, ref answer);
        }
        return answer;
    }

    private void GetValueRecursive(int[] heights, int depth, ref int answer)
    {
        if (depth == heights.Length)
        {
            int diff = GetValue(heights);
            if (answer < diff || diff == collectAnswer)
            {
                answer = diff;

                if (diff == collectAnswer)
                {
                    solutions.Add((int[])heights.Clone());
                    //Console.WriteLine(string.Join(" ", heights));
                }
            }
        }

        for (int i = depth; i < heights.Length; i++)
        {
            (heights[i], heights[depth]) = (heights[depth], heights[i]);
            GetValueRecursive(heights, depth + 1, ref answer);
            (heights[i], heights[depth]) = (heights[depth], heights[i]);
        }
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