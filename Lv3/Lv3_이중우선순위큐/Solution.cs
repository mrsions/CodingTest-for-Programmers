///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/42628</source>
///// <reading>7:12~7:16</reading>
///// <coding>7:19~7:21</coding>
///// <failed_Resolve>7:26~7:27</failed_Resolve>
///// <summary>
///// 너무 쉬워서 방심함
///// Simple Benchmark 423314 / 0.708s = 16.719 cpt  || Alloc: 1952.0b
///// Simple Benchmark 200 / 4.988s = 249383.015 cpt  || Alloc: 501712.5b
///// </summary>


//using System.Collections.Generic;
//using System.Linq;
//public class Solution
//{
//    public int[] solution(string[] operations)
//    {
//        List<int> result = new List<int>();

//        foreach (string operation in operations)
//        {
//            switch (operation[0])
//            {
//                case 'I':
//                    result.Add(int.Parse(operation.Substring(2)));
//                    break;

//                case 'D':
//                    if (result.Count == 0) break;

//                    if (operation[2] == '1')
//                    {
//                        result.Remove(result.Max());
//                    }
//                    else
//                    {
//                        result.Remove(result.Min());
//                    }
//                    break;
//            }
//        }

//        if (result.Count == 0)
//        {
//            return new int[] { 0, 0 };
//        }
//        else
//        {
//            return new int[] { result.Max(), result.Min() };
//        }
//    }
//}