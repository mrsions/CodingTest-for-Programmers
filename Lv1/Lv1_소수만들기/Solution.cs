/// <source>https://programmers.co.kr/learn/courses/30/lessons/12977?language=csharp</source>
/// <solveTime>12m</solveTime>
/// <summary></summary>
class Solution
{
    public int solution(int[] nums)
    {
        int answer = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                for (int k = j + 1; k < nums.Length; k++)
                {
                    int v = nums[i] + nums[j] + nums[k];

                    bool find = false;
                    for (int l = 2; l < v; l++)
                    {
                        if (v % l == 0)
                        {
                            find = true;
                            break;
                        }
                    }

                    if (!find)
                    {
                        answer++;
                    }
                }
            }
        }

        return answer;
    }
}