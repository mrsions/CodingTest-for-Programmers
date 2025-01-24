#include <iostream>
#include <stdlib.h>

#include <vector>
#include <functional>
#include <limits>
#include <map>
#include <set>
#include <cmath>

using namespace std;

struct Point
{
    int x;
    int y;

    Point() : x(0), y(0) {}
    Point(int x, int y) : x(x), y(y) {}

    int index(int width) const { return x+y*width; }

    Point operator+(const Point& o) const { return Point(x+o.x, y+o.y); }
    Point operator-(const Point& o) const { return Point(x-o.x, y-o.y); }
    bool operator==(const Point& o) const { return x==o.x && y==o.y; }
    bool operator!=(const Point& o) const { return x!=o.x || y!=o.y; }

    static Point parse(int idx, int width)
    {
        return Point(idx%width, idx/width);
    }
};


namespace Contour
{
    vector<Point> arrows = {{-1,0}, {0,1}, {1,0}, {0,-1}};

    vector<int> Find(vector<bool> maze, int w, int h, Point goal)
    {
        const int maxint = numeric_limits<int>::max();

        int wh = w*h;
        vector<int> levels(wh, maxint);

        vector<int> queue = { goal.index(w) };

        int level = 0;

        while(queue.size())
        {
            int queue_size = queue.size();

            for(int i=0; i<queue_size; i++)
            {
                int idx = queue[i];
                levels[idx] = level;
                
                Point p = Point::parse(idx, w);
                printf("loop (%d,%d)\n", p.x,p.y);

                for(auto arrow:arrows)
                {
                    auto ap = p + arrow;

                    printf("  (%d,%d) ", ap.x, ap.y);

                    if (ap.x<0||ap.x>=w||ap.y<0||ap.y>=h)
                    {
                        printf("  out of bounds\n");
                        continue;
                    } 

                    auto aidx = ap.index(w);
                    if (!maze[aidx])
                    {
                        printf("  block\n");
                    }
                    else if (level < levels[aidx])
                    {
                        printf("  add (%d,%d)\n", ap.x, ap.y);
                        queue.push_back(aidx);
                    }
                    else
                    {
                        printf("  low value (%d,%d)\n", ap.x, ap.y);
                    }
                }
            }

            queue.erase(queue.begin(), queue.begin() + queue_size);

            level++;
        }

        return levels;
    }
}

Point findId(vector<vector<int>> maze, int id)
{
    int w = (int)maze[0].size();
    int h = (int)maze.size();
    
    for(int y=0; y<h; y++)
    {
        for(int x=0; x<w; x++)
        {
            if(maze[y][x] == id)
            {
                return Point(x,y);
            }
        }
    }
    return Point(-1,-1);
}

int solution(vector<vector<int>> maze)
{
    int w = maze[0].size();
    int h = maze.size();
    int wh = w*h;

    Point start;
    Point end;

    vector<bool> maze2(wh, true);
    for(int y=0;y<h;y++)
    {
        for(int x=0;x<w;x++)
        {
            int idx = Point(x,y).index(w);

            switch(maze[y][x])
            {
                case 1:
                    maze2[idx] = false;
                    break;
                case 2:
                    start = Point(x,y);
                    break;
                case 3:
                    end = Point(x,y);
                    break;
            }
        }
    }

    auto result = Contour::Find(maze2, w, h, end);

    for(int y=0;y<h;y++)
    {
        for(int x=0;x<w;x++)
        {
            int idx = Point(x,y).index(w);
            int level = result[idx];
            if(level == numeric_limits<int>::max())
            {
                printf("XX ");
            }
            else
            {
                printf("%02d ", level);
            }
        }
        printf("\n");
    }

    return 0;
}

int main()
{
    solution({{2, 0, 0},
              {0, 0, 0},
              {1, 0, 1},
              {0, 0, 3}});
    return 0;
}