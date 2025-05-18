/////// <source>https://school.programmers.co.kr/learn/courses/30/lessons/68938?language=csharp</source>
/////// <read>12:58~13:00</read>
/////// <solveTime>13:00~13:03</solveTime>
/////// <summary>
/////// 몇몇 케이스에 맞지않아 실패
/////// </summary>

//using System;

//public class Solution
//{
//    public int solution(int[] heights)
//    {
//        Array.Sort(heights);

//        int mid = heights.Length / 2;
//        int mod = heights.Length % 2;
//        if (mod == 0)
//        {
//            return heights[mid] - heights[mid - 1];
//        }
//        else
//        {
//            return Math.Max(heights[mid + 1] - heights[mid], heights[mid] - heights[mid - 1]);
//        }
//    }
//}