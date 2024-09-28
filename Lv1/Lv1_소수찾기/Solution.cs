/// <source>https://school.programmers.co.kr/learn/courses/30/lessons/12921?language=csharp</source>
/// <solveTime>30m</solveTime>
/// <summary>
/// 이해도 부족으로 오래 걸림
/// </summary>
public class Solution
{
    public int solution(int n)
    {
        int answer = 0;

        for (int i = 2; i <= n; i++)
        {
            if (IsPrime(i))
            {
                answer++;
            }
        }

        return answer;
    }

    private static bool IsPrime(int v)
    {
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