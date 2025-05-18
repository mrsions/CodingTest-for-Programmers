using System;
using System.Text;

int len = 10000;
var rnd = new Random(0);
StringBuilder sb = new StringBuilder(10000);
for (int i = 0; i < 10000; i++)
{
    sb.Append((char)rnd.Next('a', 'z'));
}


Test.Run(new Solution().solution, new TestCase[]
{
    new(9L, new object[]{ "baby" }),
    //new(0L, new object[]{ "oo" }),
    //new(0L, new object[]{ sb.ToString() }),
});