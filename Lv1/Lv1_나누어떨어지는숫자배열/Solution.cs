using System.Collections.Generic;

/// <source>https://programmers.co.kr/learn/courses/30/lessons/12910?language=csharp</source>
/// <solveTime>5m</solveTime>
/// <summary>
/// </summary>
public class Solution
{
    public int[] solution(int[] arr, int divisor)
    {
        List<int> answer = new List<int>();
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % divisor == 0)
            {
                answer.Add(arr[i]);
            }
        }
        if (answer.Count > 0)
        {
            answer.Sort();
            return answer.ToArray();
        }
        else
        {
            return new int[] { -1 };
        }
    }
}