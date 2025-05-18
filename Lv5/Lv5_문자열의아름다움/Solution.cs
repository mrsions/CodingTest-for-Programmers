///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/68938?language=csharp</source>
///// <read>01:02~01:05</read>
///// <solveTime>01:06~01:13</solveTime>
///// <summary>
///// 
///// </summary>

//using System;

//public class Solution
//{
//    public long solution(string s)
//    {
//        long answer = 0;

//        var sp = s.AsSpan();



//        for (int i = 0; i < s.Length; i++)
//        {
//            //for (int j = i + 1; j <= s.Length; j++)
//            //{

//            //    answer += GetScore(sp, i, j - i);
//            //}
//        }

//        return answer;
//    }

//    static void log(string s)
//    {
//        Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} {s}");
//    }

//    private long GetScore(ReadOnlySpan<char> s, int offset, int length)
//    {
//        int maxScore = 0;
//        for (int i = 0; i < length; i++)
//        {
//            char ci = s[offset + i];

//            for (int j = length - 1; j >= 0; j--)
//            {
//                int score = j - i;
//                if (score < maxScore)
//                {
//                    break;
//                }

//                if (ci == s[offset + j]) continue;

//                maxScore = score;
//                break;
//            }
//        }
//        return maxScore;
//    }
//}