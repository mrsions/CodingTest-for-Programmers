/// <source>https://school.programmers.co.kr/learn/courses/30/lessons/68645?language=csharp</source>
/// <solveTime>40m</solveTime>
/// <summary>
/// 방향을 예측으로 잡고 설계하다가 취소함.
/// </summary>
public class Solution
{
    public int[] solution(int n)
    {
        int[] grid = new int[n * n];

        int number = 1;
        int mx = 0;
        int my = -1;
        int dx = 0;
        int dy = 0;

        for (int i = 0; i < n; i++)
        {
            switch (i % 3)
            {
                case 0:
                    dx = 0;
                    dy = 1;
                    break;
                case 1:
                    dx = 1;
                    dy = 0;
                    break;
                case 2:
                    dx = -1;
                    dy = -1;
                    break;
            }

            int len = n - i;

            for (int j = 0; j < len; j++)
            {
                mx += dx;
                my += dy;

                int idx = mx + my * n;

                grid[idx] = number++;
            }
        }

        int[] result = new int[number - 1];
        int resultIdx = 0;
        for (int y = 0; y < n; y++)
        {
            int len = y + 1;
            for (int x = 0; x < len; x++)
            {
                int idx = x + y * n;
                //Console.Write(grid[idx].ToString().PadRight(5));
                result[resultIdx++] = grid[idx];
            }
            //Console.WriteLine();
        }

        return result;
    }
}