///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/68938?language=csharp</source>
///// <resolveTime>13:07~13:18</resolveTime>
///// <summary>
///// 짝수 케이스에만 맞고, 홀수 케이스에는 실패한다.
///// </summary>

using System;

public class Solution2
{
    public static int GetValue(ReadOnlySpan<int> heights)
    {
        int lenM1 = heights.Length - 1;
        int half = (heights.Length / 2) - (heights.Length % 2) + 1;

        int minLength = int.MaxValue;

        for (int i = 0; i < half; i++)
        {
            int a = heights[i];
            int b = heights[lenM1 - i];
            int c = b - a;

            if (c < minLength)
            {
                minLength = c;
            }
        }

        return minLength;
    }

    public int solution(int[] heights)
    {
        Array.Sort(heights);

        var span = new ReadOnlySpan<int>(heights);

        int a = GetValue(span);
        int b = GetValue(span.Slice(1));
        int c = GetValue(span.Slice(0, span.Length - 1));

        if (a > b && a > c)
        {
            return a;
        }
        else if (b > a && b > c)
        {
            return b;
        }
        else
        {
            return c;
        }
    }
}