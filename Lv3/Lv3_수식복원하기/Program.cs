Test.Run(new Solution().solution, new TestCase[]
{
    new(n.Arr("13 - 6 = 5"), new object[]{ n.Arr("14 + 3 = 17", "13 - 6 = X", "51 - 5 = 44") }),
    new(n.Arr("1 + 5 = ?", "1 + 2 = 3"), new object[]{ n.Arr("1 + 1 = 2", "1 + 3 = 4", "1 + 5 = X", "1 + 2 = X") }),
    new(n.Arr("10 - 2 = 4", "3 + 3 = 10", "33 + 33 = 110"),new object[]{  n.Arr("10 - 2 = X", "30 + 31 = 101", "3 + 3 = X", "33 + 33 = X") }),
    new(n.Arr("2 + 2 = 4", "7 + 4 = ?", "5 - 5 = 0"), new object[]{ n.Arr("2 - 1 = 1", "2 + 2 = X", "7 + 4 = X", "5 - 5 = X") }),
    new(n.Arr("2 + 2 = 4", "7 + 4 = 12", "8 + 4 = 13"),new object[]{  n.Arr("2 - 1 = 1", "2 + 2 = X", "7 + 4 = X", "8 + 4 = X") }),
});