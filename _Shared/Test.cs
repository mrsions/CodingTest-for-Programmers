using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public record TestCase(object Expect, params object[] Params);

public static class n
{
    public static int[] IntArr(params int[] a) => a;
    public static int[] BA(params int[] a) => a;
    public static T[] Arr<T>(params T[] a) => a;
}

public static class Test
{
    public static void Run(Delegate method, params TestCase[] testCases)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("Run  : " + method.Method.DeclaringType.Assembly.GetName().Name);
        Console.WriteLine("Case : " + testCases.Length);

        bool success = true;
        for (int i = 0; i < testCases.Length; i++)
        {
            TestCase testCase = testCases[i];
            try
            {
                var result = method.DynamicInvoke(testCase.Params);

                if (AnyEquals(result, testCase.Expect))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"[{i + 1}/{testCases.Length}] Success");
                }
                else
                {
                    success = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[{i + 1}/{testCases.Length}] Failed  (result:{result} != expect:{testCase.Expect})");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine(ex);
                Environment.Exit(1);
                return;
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        if (!success)
        {
            if (!Environment.GetCommandLineArgs().Contains("-nowait"))
            {
                Console.WriteLine();
                Console.WriteLine("Please any key..");
                Console.ReadKey();
            }
            Environment.Exit(1);
        }
    }

    private static bool AnyEquals(object a, object b)
    {
        if (a == null && b == null) return true;
        else if (a == null || b == null) return false;
        else if (a.Equals(b)) return true;

        Type ta = a.GetType();
        Type tb = b.GetType();
        if (ta != tb) return false;

        if (a is ICollection)
        {
            var aa = ToArray(((ICollection)a).GetEnumerator());
            var bb = ToArray(((ICollection)b).GetEnumerator());
            if (aa.Count != bb.Count)
            {
                return false;
            }

            for (int i = 0; i < aa.Count; i++)
            {
                if (!AnyEquals(aa[i], bb[i]))
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            var comparerType = typeof(EqualityComparer<>).MakeGenericType(ta);
            var compareInstance = comparerType.GetProperty("Default", BindingFlags.Static | BindingFlags.Public)
                .GetValue(null);
            var method = comparerType.GetMethod("Equals", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            return (bool)method.Invoke(compareInstance, new object[] { a, b });
        }
    }

    private static List<object> ToArray(IEnumerator e)
    {
        List<object> list = new List<object>();
        while (e.MoveNext())
        {
            list.Add(e.Current);
        }
        return list;
    }
}
