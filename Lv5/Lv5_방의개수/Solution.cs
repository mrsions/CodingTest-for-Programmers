/// <source>https://school.programmers.co.kr/learn/courses/30/lessons/49190?language=csharp</source>
/// <read>11:25~11:29</read>
/// <solveTime>11:29~12:30</solveTime>
/// <summary>
/// 교차하는 부분도 검증해야한다는 사실을 늦게 알았음.
/// </summary>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


public class Solution
{
    public struct Point
    {
        public int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override int GetHashCode()
        {
            return (x & 0xFFFF) | ((y << 0x20) & 0xFFFF);
        }

        public override bool Equals([NotNullWhen(true)] object obj)
        {
            if (!(obj is Point)) return false;
            Point p = (Point)obj;
            return this.x == p.x && this.y == p.y;
        }

        public override string ToString()
        {
            return $"({x},{y})";
        }

        public static Point operator +(Point lhs, Point rhs)
        {
            return new Point(lhs.x + rhs.x, lhs.y + rhs.y);
        }
        public static Point operator -(Point lhs, Point rhs)
        {
            return new Point(lhs.x + rhs.x, lhs.y + rhs.y);
        }
        public static bool operator ==(Point lhs, Point rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y;
        }
        public static bool operator !=(Point lhs, Point rhs)
        {
            return lhs.x != rhs.x || lhs.y != rhs.y;
        }

        public static Point GetDirection(int v)
        {
            switch (v)
            {
                case 0: return new Point(0, 1);
                case 1: return new Point(1, 1);
                case 2: return new Point(1, 0);
                case 3: return new Point(1, -1);
                case 4: return new Point(0, -1);
                case 5: return new Point(-1, -1);
                case 6: return new Point(-1, 0);
                case 7: return new Point(-1, 1);
                default: throw new NotImplementedException();
            }
        }
    }

    class Node
    {
        public Point point;
        public Node[] links = new Node[8];

        public Node(int x, int y) : this(new Point(x, y)) { }
        public Node(Point point)
        {
            this.point = point;
        }
    }

    private Dictionary<Point, Node> nodes = new Dictionary<Point, Node>();

    public int solution(int[] arrows)
    {
        int answer = 0;

        Node start = new Node(0, 0);
        nodes[start.point] = start;

        Node current = start;
        for (int i = 0; i < arrows.Length; i++)
        {
            current = Move(current, arrows[i], ref answer);
            current = Move(current, arrows[i], ref answer);
        }

        return answer;
    }

    private Node Move(Node current, int direction, ref int answer)
    {
        var nextPoint = current.point + Point.GetDirection(direction);
        if (!nodes.TryGetValue(nextPoint, out var node))
        {
            node = new Node(nextPoint);
            nodes[node.point] = node;
        }
        else
        {
            if (current.links[direction] == null)
            {
                answer++;
            }
        }

        current.links[direction] = node;
        node.links[(direction + 4) % 8] = current;


        return node;
    }

}