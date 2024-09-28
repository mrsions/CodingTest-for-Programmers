using System;

/// <source>https://programmers.co.kr/learn/courses/30/lessons/77484?language=csharp</source>
/// <solveTime>7m</solveTime>
/// <summary>
/// </summary>
public class Solution
{
    public int[] solution(int[] lottos, int[] win_nums)
    {
        int[] answer = new int[] { };

        int unkownNumbers = 0;
        int matchNumbers = 0;

        for (int i = 0; i < lottos.Length; i++)
        {
            int num = lottos[i];
            if (num == 0)
            {
                unkownNumbers++;
            }
            else
            {
                for (int j = 0; j < win_nums.Length; j++)
                {
                    if (win_nums[j] == num)
                    {
                        matchNumbers++;
                        break;
                    }
                }
            }
        }

        return new int[]
        {
            Math.Min(6, 7 - matchNumbers - unkownNumbers),
            Math.Min(6, 7 - matchNumbers)
        };
    }
}