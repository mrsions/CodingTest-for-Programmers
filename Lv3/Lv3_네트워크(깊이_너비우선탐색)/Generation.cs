using System;
using System.Collections.Generic;

public class Generation
{
    static Random rnd0 = new Random(0);
    static Random rndr = new Random();

    public static TestCase New(bool useFix = true)
    {
        var rnd =  useFix ? rnd0 : rndr;

        int n = rnd.Next(200, 201);
        //int n = rnd.Next(1, 20);
        //int n = rnd.Next(3, 5);

        double pivot = rnd.NextDouble() * 0.4 + 0.3;

        int[,] computers = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                computers[i, j] = rnd.NextDouble() < pivot ? 1 : 0;
            }
            computers[i, i] = 1;
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if(computers[i, j] == 1 || computers[j, i] == 1)
                {
                    computers[i, j] = 1; 
                    computers[j, i] = 1;
                }
            }
        }

        int result = new Solution().solution(n, computers);
        //string print = $"new({result}, {n}, new int[,] {ToString_Arr(computers)}),";
        //Console.WriteLine(print);
        //Console.WriteLine();
        //Console.WriteLine();

        return new TestCase(result, n, computers);
    }

    static string ToString_Arr(int[,] arr)
    {
        string result = "{ ";
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            result += "{ ";
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                result += arr[i, j];
                if (j < arr.GetLength(1) - 1)
                {
                    result += ", ";
                }
            }
            result += " }";
            if (i < arr.GetLength(0) - 1)
            {
                result += ", ";
            }
        }
        result += " }";
        return result;
    }

    /// <source>https://school.programmers.co.kr/learn/courses/30/lessons/43162?language=csharp</source>
    /// <reading>11:30~11:37</reading>
    /// <coding>11:38~11:58</coding>
    /// <summary>
    /// </summary>
    public class Solution
    {
        public class Computer
        {
            public int id;
            public bool resolved;
            public List<Computer> links = new List<Computer>();
            public Network network;
        }

        public class Network
        {
            public List<Computer> computers = new List<Computer>();
        }


        Computer[] m_computers;
        List<Network> networks = new List<Network>();

        public int solution(int n, int[,] computers)
        {
            this.m_computers = new Computer[n];
            for (int i = 0; i < n; i++)
            {
                this.m_computers[i] = new Computer()
                {
                    id = i,
                    links = new List<Computer>(n)
                };
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j && computers[i, j] == 1)
                    {
                        m_computers[i].links.Add(m_computers[j]);
                    }
                }
            }

            for (int i = 0; i < m_computers.Length; i++)
            {
                Computer computer = m_computers[i];
                Resolve(computer, computer.network);
            }

            return networks.Count;
        }

        private void Resolve(Computer computer, Network network)
        {
            if (computer.resolved) return;
            computer.resolved = true;

            if (network == null)
            {
                network = new Network();
                networks.Add(network);
            }

            computer.network = network;

            foreach (var link in computer.links)
            {
                Resolve(link, network);
            }
        }
    }
}