/// <source>https://programmers.co.kr/learn/courses/30/lessons/87389?language=csharp</source>
/// <solveTime>2m</solveTime>
/// <summary>
/// </summary>
public class Solution
{
    public int solution(int n)
    {
        int i = 1;
        while (n % i != 1)
        {
            i++;
        }
        return i;
    }
}