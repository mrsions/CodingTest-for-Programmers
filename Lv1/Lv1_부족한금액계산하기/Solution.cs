/// <source>https://programmers.co.kr/learn/courses/30/lessons/82612?language=csharp</source>
/// <solveTime>8m</solveTime>
/// <summary>
/// </summary>
class Solution
{
    public long solution(int price, int money, int count)
    {
        long need = 0;
        for (int i = 0; i < count; i++)
        {
            need += price * (i + 1L);
        }

        if (need < money) return 0;
        else return need - money;
    }
}