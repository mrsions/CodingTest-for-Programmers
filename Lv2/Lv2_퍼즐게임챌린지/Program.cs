Test.Run(new Solution().solution, new TestCase[]
{
    new(3, n.IntArr(1, 5, 3),n.IntArr(2, 4, 7), 30L),
    new(2, n.IntArr(1, 4, 4, 2),n.IntArr(6, 3, 8, 2), 59L),
    new(294, n.IntArr(1, 328, 467, 209, 54),n.IntArr(2, 7, 1, 4, 3), 1723L),
    new(39354, n.IntArr(1, 99999, 100000, 99995),n.IntArr(9999, 9001, 9999, 9001), 3456789012L)
});