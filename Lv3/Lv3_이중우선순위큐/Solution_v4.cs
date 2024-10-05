///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/42628</source>
///// <improve>8:05~8:09</improve>
///// <summary>
///// 입력이 많은 상황에 어울릴 것 같음.
///// Simple Benchmark 446238 / 0.569s = 12.749 cpt  || Alloc: 936.0b
///// Simple Benchmark 1490 / 4.880s = 32750.411 cpt  || Alloc: 41056.0b
///// </summary>

//using System;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//public class Solution
//{
//    public int[] solution(string[] operations)
//    {
//        int min = 0;
//        int max = 0;
//        List<int> result = new List<int>(operations.Length);

//        for (int i = 0; i < operations.Length; i++)
//        {
//            string operation = operations[i];
//            if (operation[0] == 'I')
//            {
//                int v = int.Parse(operation.AsSpan().Slice(2));

//                if (result.Count == 0) min = max = v;
//                else if (v < min) min = v;
//                else if (v > max) max = v;

//                result.Add(v);
//            }
//            else
//            {
//                if (result.Count == 0) continue;

//                if (operation[2] == '1')
//                {
//                    result.Remove(max);
//                    if (result.Count != 0) max = Max(result);
//                }
//                else
//                {
//                    result.Remove(min);
//                    if (result.Count != 0) min = Min(result);
//                }
//            }
//        }

//        if (result.Count == 0)
//        {
//            return new int[] { 0, 0 };
//        }
//        else
//        {
//            return new int[] { max, min };
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