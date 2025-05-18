/// <source>https://school.programmers.co.kr/learn/courses/30/lessons/250134</source>
/// <solveTime>16:16 ~17:40</solveTime>
/// <summary>
/// 
/// </summary>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

public class Solution
{
    public struct Point : IEqualityComparer<Point>
    {
        public int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool IsValid(int w, int h)
        {
            return 0 <= x && x < w
                && 0 <= y && y < h;
        }

        public bool Equals(Point x, Point y) => x.x == y.x && x.y == y.y;
        public override int GetHashCode() => HashCode.Combine(this.x, this.y);
        public int GetHashCode([DisallowNull] Point obj) => obj.GetHashCode();
        public static Point operator +(Point a, Point b) => new(a.x + b.x, a.y + b.y);
        public static Point operator -(Point a, Point b) => new(a.x - b.x, a.y - b.y);
        public static bool operator ==(Point x, Point y) => x.x == y.x && x.y == y.y;
        public static bool operator !=(Point x, Point y) => x.x != y.x || x.y != y.y;

        public override string ToString()
        {
            return $"({x},{y})";
        }
    }

    private static Point[] arrows =
    {
        new Point(0, 1),
        new Point(1, 0),
        new Point(0, -1),
        new Point(-1, 0)
    };

    public struct Character
    {
        public Point current;
        public Point goal;
        public int[,] moved;
        public bool HasGoal => current == goal;
        public override string ToString()
        {
            return $"Char(c:{current},g:{goal},h:{HasGoal})";
        }
    }

    public struct Characters
    {
        public Character red;
        public Character blue;

        public override string ToString()
        {
            return $"Characters(red:{red}, blue:{blue})";
        }
    }

    private static Point FindMazeById(int[,] maze, int id)
    {
        int w = maze.GetLength(1), h = maze.GetLength(0);
        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                if (maze[y, x] == id)
                {
                    return new Point(x, y);
                }
            }
        }
        return default;
    }

    [Conditional("DEBUG")]
    static void log(object v)
    {
        //Console.WriteLine(v);
    }

    public int solution(int[,] maze)
    {
        Point red = FindMazeById(maze, 1);
        Point blue = FindMazeById(maze, 2);
        Point redgoal = FindMazeById(maze, 3);
        Point bluegoal = FindMazeById(maze, 4);

        int[,] redmoved = new int[maze.GetLength(0), maze.GetLength(1)];
        redmoved[red.y, red.x] = 1;

        int[,] bluemoved = new int[maze.GetLength(0), maze.GetLength(1)];
        bluemoved[blue.y, blue.x] = 1;

        int length = Find(maze, new()
        {
            red = new()
            {
                current = red,
                goal = redgoal,
                moved = redmoved
            },
            blue = new()
            {
                current = blue,
                goal = bluegoal,
                moved = bluemoved
            }
        }, 1);

        return length;
    }

    public int Find(int[,] maze, Characters chars, int depth)
    {
        char[] temp = new char[depth * 2];
        Array.Fill(temp, ' ');
        string tab = new string(temp);

        int minLength = int.MaxValue;
        log($"{tab}Find({depth}, {chars})");

        int w = maze.GetLength(1), h = maze.GetLength(0);
        for (int ri = 0; ri < arrows.Length; ri++)
        {
            Point r = chars.red.current;
            if (!chars.red.HasGoal)
            {
                r += arrows[ri];
                //if (!r.IsValid(w, h) || maze[r.y, r.x] == 5 || r == chars.blue.current || chars.red.moved[r.y, r.x] != 0)
                if (!r.IsValid(w, h) || maze[r.y, r.x] == 5 || chars.red.moved[r.y, r.x] != 0)
                {
                    log($"{tab}- [{ri},0] r:{r} continue");
                    continue;
                }
                else
                {
                    log($"{tab}- [{ri},0] r:{r}");
                }
            }

            chars.red.moved[r.y, r.x] = depth + 1;

            for (int bi = 0; bi < arrows.Length; bi++)
            {
                Point b = chars.blue.current;

                if (!chars.blue.HasGoal)
                {
                    b += arrows[bi];
                    //if (!b.IsValid(w, h) || maze[b.y, b.x] == 5 || b == chars.red.current || b == r || chars.blue.moved[b.y, b.x] != 0)
                    if (!b.IsValid(w, h) || maze[b.y, b.x] == 5 || b == r || chars.blue.moved[b.y, b.x] != 0)
                    {
                        log($"{tab}- [{ri},{bi}] b:{b} continue");
                        continue;
                    }
                    else
                    {
                        log($"{tab}- [{ri},{bi}] b:{b}");
                    }

                    if (r == chars.blue.current && b == chars.red.current)
                    {
                        continue;
                    }
                }

                chars.blue.moved[b.y, b.x] = depth + 1;

                Characters chars2 = chars;
                chars2.red.current = r;
                chars2.blue.current = b;

                if (chars2.red.HasGoal && chars2.blue.HasGoal)
                {
                    log($"{tab}- [{ri},{bi}] goal");
                    return 1;
                }

                int newLength = Find(maze, chars2, depth + 1);
                if (newLength != -1)
                {
                    newLength++;
                    if (newLength < minLength)
                    {
                        minLength = newLength;
                    }
                }

                chars.blue.moved[b.y, b.x] = 0;
            }

            chars.red.moved[r.y, r.x] = 0;
        }

        if (minLength == int.MaxValue) return -1;
        else return minLength;
    }
}