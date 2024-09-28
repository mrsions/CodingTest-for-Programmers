Test.Run(new Solution().solution, new TestCase[]
{
    new (new int[]{ 5,10 }, new int[]{ 5,9,7,10}, 5),
    new (new int[]{1,2,3,36}, new int[]{2,36,1,3},1),
    new (new int[]{-1}, new int[]{3,2,6},10)
});