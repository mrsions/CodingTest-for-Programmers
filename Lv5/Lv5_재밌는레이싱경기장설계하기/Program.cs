
using System;
using System.Linq;


var a = new Solution();
var b = new Solution4();

var rnd = new Random();
for (int z = 0; ; z++)
{
    Console.WriteLine("#########");
    a.print = true;

    int[] heights = new int[9];
    for (int i = 0; i < heights.Length; i++)
    {
        heights[i] = rnd.Next(1, 100);
    }
    //heights = [1, 10, 50, 9000, 9100, 9200, 9300, 9400, 9500, 9600, 9900];
    //heights = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11];
    //heights = [1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024];
    //heights = [1024, 1536, 1792, 1920, 1984, 2016, 2032, 2040, 2044, 2046, 2047];

    var answer = a.solution(heights);
    Array.Sort(heights);
    Console.WriteLine(string.Join(" ", heights));

    if (answer != b.solution(heights) && false)
    {
        Console.WriteLine();
        Console.WriteLine(string.Join(" ", heights));
        return;
    }
    else
    {
        Console.WriteLine(answer);
        //foreach (var solution in a.solutions)
        //{
        //    Console.WriteLine(solution);
        //}
        //Console.WriteLine("Finded");
        //Console.ReadLine();
        foreach (var solution in a.solutions)
        {
            //Console.WriteLine(string.Join(solution));
        }

        var average = heights.Average();
        var mid = heights[heights.Length / 2];

        bool includeMid = mid < average;

        double left = 0;
        double right = 0;
        for (int i = 0; i < heights.Length - 1; i++)
        {
            var v = Math.Abs(heights[i] - heights[i + 1]);
            if (i < heights.Length / 2)
            {
                left += v;
            }
            else
            {
                right += v;
            }
        }

        if (includeMid)
        {
            foreach (var solution in a.solutions)
            {
                if (solution[0] != mid) continue;
                Console.WriteLine(string.Join(" ", solution));
            }
            if (a.solutions.Any(b => heights.Contains(b[0])) == false)
            {
                Console.WriteLine("Mid not match");
                Console.ReadLine();
            }
        }
        else if (left < right)
        {
            var available = heights[heights.Length / 2 - 1];

            foreach (var solution in a.solutions)
            {
                if (solution[0] != available) continue;
                Console.WriteLine(string.Join(" ", solution));
            }

            if (a.solutions.Any(v => available == v[0]) == false)
            {
                Console.WriteLine("left not match");
                Console.ReadLine();
            }
        }
        else
        {
            //var availables = heights.Skip(heights.Length / 2 + 1).ToList();
            //if (a.solutions.Any(v => availables.Contains(v[0])) == false)

            var available = heights[heights.Length / 2 + 1];

            foreach (var solution in a.solutions)
            {
                if (solution[0] != available) continue;
                Console.WriteLine(string.Join(" ", solution));
            }

            if (a.solutions.Any(v => available == v[0]) == false)
            {
                Console.WriteLine("right not match");
                Console.ReadLine();
            }
        }
        Console.ReadLine();

        //var aa = new ArraySegment<int>(heights, 0, heights.Length / 2);
        //var bb = new ArraySegment<int>(heights, aa.Count, aa.Count);

        //int min = Math.Abs(heights[heights.Length / 2] - heights[0]);
        //int max = (int)Math.Ceiling(aa.SelectMany(v => bb.Select(b => Math.Abs(b - v))).Average());

        //if (answer < min || answer > max)
        //{
        //    Console.WriteLine(string.Join(" ", heights));
        //    foreach (var solution in a.solutions)
        //    {
        //        Console.WriteLine(solution);
        //    }
        //    Console.WriteLine("Finded");
        //    Console.ReadLine();
        //}
        //else
        //{
        //    Console.Write("\r" + z);
        //}
    }
}

//int[] heights = new int[7];
//var rnd = new Random(0);
//for (int i = 0; i < heights.Length; i++)
//{
//    heights[i] = rnd.Next(1, 100);
//}

//var a = new Solution();
//var b = new Solution();

//Test.Run(new Solution().solution, new TestCase[]
//{
//    //new(4, new object[]{ n.IntArr(1,8,5) }),
//    //new(5, new object[]{ n.IntArr(11,6,4,11) }),
//    //new(0, new object[]{ n.IntArr(9,9,9,30) }),
//    //new(4, new object[]{ n.IntArr(1,4,5,6,9) }),
//    //new(5, new object[]{ n.IntArr(1,4,5,6,9,10) }),
//    //new(1, new object[]{ n.IntArr(1,4,5,5,5,10) }),
//    new(-1, new object[]{ heights }),
//});