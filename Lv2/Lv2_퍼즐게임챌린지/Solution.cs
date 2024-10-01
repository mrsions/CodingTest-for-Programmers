/// <source>https://school.programmers.co.kr/learn/courses/30/lessons/340212</source>
/// <solveTime>34m</solveTime>
/// <summary>
/// </summary>
public class Solution
{
    public int solution(int[] diffs, int[] times, long limit)
    {
        int lv = 1;
        int lvMax = 100_000;

        while (lv < lvMax)
        {
            int mid = (lv + lvMax) / 2;
            var time = GetPlayTime(diffs, times, mid);

            if (time <= limit)
            {
                lvMax = mid;
            }
            else
            {
                lv = mid + 1;
            }
        }

        return lv;
    }

    private static long GetPlayTime(int[] diffs, int[] times, long level)
    {
        long playTime = 0;

        for (int i = 0; i < diffs.Length; i++)
        {
            var retryCount = diffs[i] - level;
            if (retryCount > 0)
            {
                if (i > 0)
                {
                    playTime += (times[i - 1] + times[i]) * retryCount;
                }
                else
                {
                    playTime += (times[i]) * retryCount;
                }
            }

            playTime += times[i];
        }

        return playTime;
    }
}