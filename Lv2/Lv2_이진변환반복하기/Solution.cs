using System.Collections.Generic;
using System.Linq;

/// <source>https://school.programmers.co.kr/learn/courses/30/lessons/70129?language=csharp</source>
/// <solveTime>30m</solveTime>
/// <summary>
/// </summary>
public class Solution
{
    public int[] solution(string s)
    {
        int procTime = 1;
        int removeCount = FirstRemove(s);
        int length = s.Length - removeCount;

        while (length > 1)
        {
            procTime++;
            removeCount += RemoveZeroBit(length, out length);
        }

        return new int[] { procTime, removeCount };
    }

    private int FirstRemove(string s)
    {
        int removeCount = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '0')
            {
                removeCount++;
            }
        }
        return removeCount;
    }

    private int RemoveZeroBit(int numb, out int length)
    {
        int max = 0;
        length = 0;
        for (int i = 0; i < 32; i++)
        {
            if ((numb & (1 << i)) != 0)
            {
                length++;
                if (i > max) max = i;
            }
        }
        return (max + 1) - length;
    }
}