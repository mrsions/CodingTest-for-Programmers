///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/42628</source>
///// <improve>8:19~8:25</improve>
///// <summary>
///// 이진트리 구현
///// Simple Benchmark 454508 / 0.560s = 12.315 cpt  || Alloc: 1496.0b
///// Simple Benchmark 8501 / 4.175s = 4910.833 cpt  || Alloc: 241216.0b
///// </summary>

//using System;
//using System.Collections.Generic;
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
//        Stack<Handle> pool = new Stack<Handle>(10);

//        Handle root = null;

//        for (int i = 0; i < operations.Length; i++)
//        {
//            string operation = operations[i];
//            if (operation[0] == 'I')
//            {
//                int v = int.Parse(operation.AsSpan().Slice(2));

//                var h = pool.Count > 0 ? pool.Pop() : new Handle();
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

//                    target.l = null;
//                    target.r = null;
//                    pool.Push(target);
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

//                    target.l = null;
//                    target.r = null;
//                    pool.Push(target);
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