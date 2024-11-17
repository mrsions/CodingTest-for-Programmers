Test.Run(new Solution().solution, new TestCase[]
{
    new(3, new object[]{ n.IntArr(6, 6, 6, 4, 4, 4, 2, 2, 2, 0, 0, 0, 1, 6, 5, 5, 3, 6, 0) }),
    new(1, new object[]{ n.IntArr(6, 4, 2, 0, 6, 4, 2, 0) }),
    new(2, new object[]{ n.IntArr(4, 1, 4, 7, 4, 1, 4, 7) }),
    new(3, new object[]{ n.IntArr(6, 5, 2, 7, 1, 4, 2, 4, 6) }),
    new(3, new object[]{ n.IntArr(5, 2, 7, 1, 6, 3) }),
    new(3, new object[]{ n.IntArr(6, 2, 4, 0, 5, 0, 6, 4, 2, 4, 2, 0) })
});