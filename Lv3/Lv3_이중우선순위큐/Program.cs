

using System.Collections.Generic;
using System;
using System.Linq;


//-------------------------------------------------------
// 대규모 예제 생성
HashSet<int> result = new();
List<string> command = new List<string>();
var rnd = new Random(0);
for (int i = 0; i < 10000; i++)
{
    if (rnd.NextDouble() < 0.8)
    {
        while (true)
        {
            int v = rnd.Next(0, int.MaxValue);
            if (result.Contains(v)) continue;

            command.Add("I " + v);
            result.Add(v);
            break;
        }
    }
    else
    {
        if (rnd.NextDouble() < 0.5)
        {
            command.Add("D 1");
            result.Remove(result.Max());
        }
        else
        {
            command.Add("D -1");
            result.Remove(result.Min());
        }
    }
}

// 시작
Test.Run(new Solution().solution, new TestCase[]
{
    new(n.Arr(0,0), new object[]{ n.Arr("I 16", "I -5643", "D -1", "D 1", "D 1", "I 123", "D -1") }),
    new(n.Arr(333, -45), new object[]{ n.Arr("I -45", "I 653", "D 1", "I -642", "I 45", "I 97", "D 1", "D -1", "I 333") }),
    new(n.Arr(2, 2), new object[]{ n.Arr("I 1", "I 3", "I 5", "I 7", "I 9", "D -1", "D -1", "D 1", "I 2", "D 1", "D 1") }),
    new(n.Arr(result.Max(),result.Min()), new object[]{ command.ToArray() }),
});
