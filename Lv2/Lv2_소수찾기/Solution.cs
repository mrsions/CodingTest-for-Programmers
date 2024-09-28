using System.Collections.Generic;
using System.Linq;

/// <source>https://school.programmers.co.kr/learn/courses/30/lessons/42839?language=csharp</source>
/// <solveTime>30m</solveTime>
/// <summary>
/// 재귀함수 최적화에 오랜 시간이 걸림
/// </summary>
public class Solution
{
    HashSet<int> numbers = new HashSet<int>();

    public int solution(string numbers)
    {
        int[] arr = numbers.Select(v => (int)(v - '0')).ToArray();

        return Collect(arr, 0, 0, arr.Length);
    }

    private int Collect(int[] arr, int v, int s, int end)
    {
        int result = 0;
        if (v > 1)
        {
            if (numbers.Add(v) && IsPrime(v))
            {
                result++;
            }
        }

        if (s != end)
        {
            for (int i = s; i < arr.Length; i++)
            {
                Swap(arr, i, s);
                result += Collect(arr, v * 10 + arr[s], s + 1, end);
                Swap(arr, i, s);
            }
        }
        return result;
    }

    private void Swap(int[] arr, int a, int b)
    {
        var temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }

    private static bool IsPrime(int v)
    {
        if (v < 2) return false;

        int end = v;
        for (int i = 2; i < end; i++)
        {
            if (v % i == 0)
            {
                return false;
            }
            else
            {
                end = v / i;
            }
        }

        return true;
    }
}