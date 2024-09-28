using System.Linq;

/// <source>https://programmers.co.kr/learn/courses/30/lessons/86051?language=csharp</source>
/// <solveTime>3m</solveTime>
/// <summary>
/// </summary>
public class Solution
{
    public int solution(int[] numbers)
    {
        return Enumerable.Range(1, 9).Except(numbers).Sum();
    }
}