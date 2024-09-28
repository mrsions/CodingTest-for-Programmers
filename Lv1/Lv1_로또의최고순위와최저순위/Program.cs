Test.Run(new Solution().solution, new TestCase[]
{
    new(n.IntArr(3, 5), n.IntArr(44, 1, 0, 0, 31, 25), n.IntArr(31, 10, 45, 1, 6, 19)),
    new(n.IntArr(1, 6), n.IntArr(0, 0, 0, 0, 0, 0), n.IntArr(38, 19, 20, 40, 15, 25)),
    new(n.IntArr(1, 1), n.IntArr(45, 4, 35, 20, 3, 9), n.IntArr(20, 9, 3, 45, 4, 35)),
});