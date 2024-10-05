///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/42628</source>
///// <improve>8:05~8:05</improve> 
///// <summary>
///// 매우 거대한 객체에 대해서는 더 어울릴듯 함
///// Simple Benchmark 424478 / 0.632s = 14.896 cpt  || Alloc: 1392.0b
///// Simple Benchmark 4614 / 4.523s = 9802.618 cpt  || Alloc: 321264.0b
///// </summary>

//using System;
//using System.Collections.Generic;

//public class Solution
//{
//    public int[] solution(string[] operations)
//    {
//        SortedSet<int> result = new SortedSet<int>();

//        for (int i = 0; i < operations.Length; i++)
//        {
//            string operation = operations[i];
//            if (operation[0] == 'I')
//            {
//                int v = int.Parse(operation.AsSpan().Slice(2));

//                result.Add(v);
//            }
//            else
//            {
//                if (result.Count == 0) continue;

//                if (operation[2] == '1')
//                {
//                    result.Remove(result.Max);
//                }
//                else
//                {
//                    result.Remove(result.Min);
//                }
//            }
//        }

//        if (result.Count == 0)
//        {
//            return new int[] { 0, 0 };
//        }
//        else
//        {
//            return new int[] { result.Max, result.Min };
//        }
//    }
//}