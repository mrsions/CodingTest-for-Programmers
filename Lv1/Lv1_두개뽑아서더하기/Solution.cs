using System.Collections.Generic;

/// <source>https://programmers.co.kr/learn/courses/30/lessons/68644?language=csharp</source>
/// <solveTime>8m</solveTime>
/// <summary>
/// </summary>
public class Solution
{
    public int[] solution(int[] numbers)
    {
        List<int> list = new List<int>();

        for (int i = 0, len = numbers.Length; i < len; i++)
        {
            for (int j = i + 1; j < len; j++)
            {
                int value = numbers[i] + numbers[j];
                if (!list.Contains(value))
                {
                    list.Add(value);
                }
            }
        }

        int[] array = list.ToArray();
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] > array[j])
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }

        return array;
    }
}