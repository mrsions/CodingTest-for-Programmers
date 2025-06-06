﻿/// <source>https://school.programmers.co.kr/learn/courses/30/lessons/42628</source>
/// <improve>9:13~</improve>
/// <summary>
/// unsafe 힙메모리로 구현
/// Simple Benchmark 8832 / 4.230s = 4789.066 cpt  || Alloc: 712.0b
/// Simple Benchmark 8742 / 4.193s = 4796.114 cpt  || Alloc: 129.9b
/// </summary>

using System;
using System.Runtime.InteropServices;
public unsafe class Solution
{
    public struct Handle
    {
        public Handle* l;
        public Handle* r;
        public int v;
    }

    public int[] solution(string[] operations)
    {
        int size = 0;
        int curSize = 0;
        for (int i = 0; i < operations.Length; i++)
        {
            string operation = operations[i];
            if (operation[0] == 'I')
            {
                curSize++;
                if (curSize > size)
                {
                    size = curSize;
                }
            }
            else if (curSize > 0)
            {
                curSize--;
            }
        }

        int len = sizeof(Handle) * size;
        Handle* ptr = (Handle*)Marshal.AllocHGlobal(len);

        Handle* consumable = ptr;
        Handle* consumeEnd = consumable + size;

        Handle* pool = null;

        Handle* root = null;

        for (int i = 0; i < operations.Length; i++)
        {
            string operation = operations[i];
            if (operation[0] == 'I')
            {
                int v = int.Parse(operation.AsSpan().Slice(2));

                Handle* h = null;
                if (consumable < consumeEnd)
                {
                    h = consumable++;
                }
                else
                {
                    h = pool;
                    pool = pool->r;
                }
                h->v = v;
                h->l = null;
                h->r = null;

                if (root == null)
                {
                    root = h;
                }
                else
                {
                    var target = root;
                    while (true)
                    {
                        // 적다면
                        if (v < target->v)
                        {
                            if (target->l == null)
                            {
                                target->l = h;
                                break;
                            }
                            else
                            {
                                target = target->l;
                            }
                        }
                        // 크다면
                        else
                        {
                            if (target->r == null)
                            {
                                target->r = h;
                                break;
                            }
                            else
                            {
                                target = target->r;
                            }
                        }
                    }
                }
            }
            else
            {
                if (root == null) continue;

                if (operation[2] == '1')
                {
                    Handle* parent = null;
                    Handle* target = root;
                    while (target->r != null)
                    {
                        parent = target;
                        target = target->r;
                    }

                    if (parent == null)
                    {
                        root = target->l;
                    }
                    else
                    {
                        parent->r = target->l;
                    }

                    if (pool == null)
                    {
                        pool = target;
                        pool->r = null;
                    }
                    else
                    {
                        target->r = pool;
                        pool = target;
                    }
                }
                else
                {
                    Handle* parent = null;
                    Handle* target = root;
                    while (target->l != null)
                    {
                        parent = target;
                        target = target->l;
                    }

                    if (parent == null)
                    {
                        root = target->r;
                    }
                    else
                    {
                        parent->l = target->r;
                    }

                    if (pool == null)
                    {
                        pool = target;
                        target->r = null;
                    }
                    else
                    {
                        target->r = pool;
                        pool = target;
                    }
                }
            }
        }

        int[] rst = new int[2];
        if (root != null)
        {
            var max = root;
            while (max->r != null)
            {
                max = max->r;
            }
            var min = root;
            while (min->l != null)
            {
                min = min->l;
            }
            rst[0] = max->v;
            rst[1] = min->v;
        }

        Marshal.FreeHGlobal((nint)ptr);
        return rst;
    }
}