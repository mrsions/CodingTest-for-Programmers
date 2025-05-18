using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class Test2
{
    public record RunItem(Func<bool> func)
    {
    }

    private static List<RunItem> items = new();

    public static void Add<T>(Func<T, bool> func) where T : new()
    {
        var inst = new T();
        items.Add(new(() => func(inst)));
    }

    public static void Run()
    {
        bool success = true;
        for (int i = 0; i < items.Count; i++)
        {
            RunItem item = items[i];
            try
            {
                bool result = item.func();
                Console.WriteLine($"Case {i + 1}: " + result);

                if (success && !result) success = false;
            }
            catch (Exception ex)
            {
                success = false;
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Case {i + 1}: FAILED");
                Console.WriteLine(ex);
                Console.ForegroundColor = color;
            }
        }

        if (!success) return;

        const int SpdTime = 3000;
        for (int i = 0; i < items.Count; i++)
        {
            RunItem item = items[i];
            Func<bool> func = item.func;
            Stopwatch sw = Stopwatch.StartNew();
            int ct = 0;
            while (sw.ElapsedMilliseconds < SpdTime)
            {
                func();
                ct++;
            }
            sw.Stop();

            Console.WriteLine($"Case {i + 1}: {ct} / {sw.Elapsed.TotalSeconds * SpdTime:f3}s = {(ct / sw.Elapsed.TotalSeconds):f3} cps");
        }
    }
}
