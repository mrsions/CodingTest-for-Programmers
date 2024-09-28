/// <source>https://school.programmers.co.kr/learn/courses/30/lessons/76501?language=csharp</source>
/// <solveTime>3m</solveTime>
/// <summary>
/// </summary>
public class Solution
{
    public int solution(int[] absolutes, bool[] signs)
    {
        int answer = 0;
        for (int i = 0, len = absolutes.Length; i < len; i++)
        {
            if (signs[i])
            {
                answer += absolutes[i];
            }
            else
            {
                answer -= absolutes[i];
            }
        }
        return answer;
    }
}