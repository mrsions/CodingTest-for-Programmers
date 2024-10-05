///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/42628</source>
///// <improve>7:29~7:34</improve>
///// <summary>
///// Linq 제거
///// foreach 제거
///// Simple Benchmark 445438 / 0.556s = 12.490 cpt  || Alloc: 936.0b
///// Simple Benchmark 1502 / 4.876s = 32464.386 cpt  || Alloc: 41056.0b
///// </summary>

//using System;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//public class Solution
//{
//    public int[] solution(string[] operations)
//    {
//        List<int> result = new List<int>(operations.Length);

//        for (int i = 0; i < operations.Length; i++)
//        {
//            string operation = operations[i];
//            if (operation[0] == 'I')
//            {
//                result.Add(int.Parse(operation.AsSpan().Slice(2)));
//            }
//            else
//            {
//                if (result.Count == 0) continue;

//                if (operation[2] == '1')
//                {
//                    result.Remove(Max(result));
//                }
//                else
//                {
//                    result.Remove(Min(result));
//                }
//            }
//        }

//        if (result.Count == 0)
//        {
//            return new int[] { 0, 0 };
//        }
//        else
//        {
//            return new int[] { Max(result), Min(result) };
//        }
//    }

//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    private int Max(List<int> list)
//    {
//        int max = list[0];
//        for (int i = 1; i < list.Count; i++)
//        {
//            if (list[i] > max)
//            {
//                max = list[i];
//            }
//        }
//        return max;
//    }

//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    private int Min(List<int> list)
//    {
//        int min = list[0];
//        for (int i = 1; i < list.Count; i++)
//        {
//            if (list[i] < min)
//            {
//                min = list[i];
//            }
//        }
//        return min;
//    }
//}