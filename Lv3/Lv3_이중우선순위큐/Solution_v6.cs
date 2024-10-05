///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/42628</source>
///// <improve>8:27~8:27</improve>
///// <summary>
///// 풀링을 제외하니 처리속도는 더 좋아짐
///// Simple Benchmark 449760 / 0.534s = 11.884 cpt  || Alloc: 1248.0b
///// Simple Benchmark 8552 / 4.127s = 4826.112 cpt  || Alloc: 321072.0b
///// </summary>

//using System;
//public class Solution
//{
//    public class Handle
//    {
//        public Handle l;
//        public Handle r;
//        public int v;

//        public override string ToString()
//        {
//            return $"{v} (l:{l?.v}, r:{r?.v})";
//        }
//    }

//    public int[] solution(string[] operations)
//    {
//        Handle root = null;

//        for (int i = 0; i < operations.Length; i++)
//        {
//            string operation = operations[i];
//            if (operation[0] == 'I')
//            {
//                int v = int.Parse(operation.AsSpan().Slice(2));

//                var h = new Handle();
//                h.v = v;

//                if (root == null)
//                {
//                    root = h;
//                }
//                else
//                {
//                    var target = root;
//                    while (true)
//                    {
//                        // 적다면
//                        if (v < target.v)
//                        {
//                            if (target.l == null)
//                            {
//                                target.l = h;
//                                break;
//                            }
//                            else
//                            {
//                                target = target.l;
//                            }
//                        }
//                        // 크다면
//                        else
//                        {
//                            if (target.r == null)
//                            {
//                                target.r = h;
//                                break;
//                            }
//                            else
//                            {
//                                target = target.r;
//                            }
//                        }
//                    }
//                }
//            }
//            else
//            {
//                if (root == null) continue;

//                if (operation[2] == '1')
//                {
//                    Handle parent = null;
//                    Handle target = root;
//                    while (target.r != null)
//                    {
//                        parent = target;
//                        target = target.r;
//                    }

//                    if (parent == null)
//                    {
//                        root = target.l;
//                    }
//                    else
//                    {
//                        parent.r = target.l;
//                    }
//                }
//                else
//                {
//                    Handle parent = null;
//                    Handle target = root;
//                    while (target.l != null)
//                    {
//                        parent = target;
//                        target = target.l;
//                    }

//                    if (parent == null)
//                    {
//                        root = target.r;
//                    }
//                    else
//                    {
//                        parent.l = target.r;
//                    }
//                }
//            }
//        }

//        if (root == null)
//        {
//            return new int[] { 0, 0 };
//        }
//        else
//        {
//            var max = root;
//            while (max.r != null)
//            {
//                max = max.r;
//            }
//            var min = root;
//            while (min.l != null)
//            {
//                min = min.l;
//            }
//            return new int[] { max.v, min.v };
//        }
//    }
//}