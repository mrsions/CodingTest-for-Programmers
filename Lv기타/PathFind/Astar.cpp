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


namespace Astar
{
    struct Cell
    {
        int gScore;
        int fScore;
    };

    struct OpenItem
    {
        int fScore;
        int index;

        bool operator<(const OpenItem& other) const
        {
            if (fScore == other.fScore)
            {
                return index < other.index;
            }
            return fScore < other.fScore;
        }
    };

    vector<Point> arrows = {{-1,0}, {0,1}, {1,0}, {0,-1}};

    int get_heuristic(Point s, Point e)
    {
        return abs(s.x-e.x) + abs(s.y+e.y);
    }


    vector<Point> Find(int w, int h, Point start, Point end, function<bool(int,int)> check)
    {
        int wh = w * h;

        Cell default_cell;
        default_cell.gScore = numeric_limits<int>::max();
        default_cell.fScore = numeric_limits<int>::max();

        vector<Cell> cells(wh, default_cell);

        int sidx = start.index(w);
        int eidx = end.index(w);

        cells[sidx].gScore = 0;
        cells[sidx].fScore = get_heuristic(Point::parse(sidx, w), Point::parse(eidx, w));
        
        map<int, int> cameFrom;
        set<OpenItem> openSet;
        openSet.insert({0, sidx});
        
        vector<Point> result;
        while(openSet.size())
        {
            auto curr_it = openSet.begin();
            int cur_fscore = curr_it->fScore;
            int cur_idx = curr_it->index;
            openSet.erase(curr_it);
            
            if (cur_idx == eidx)
            {
                result.reserve(wh);
                result.push_back(end);
                int bef_idx = eidx;
                while(cameFrom.find(bef_idx) != cameFrom.end())
                {
                    bef_idx = cameFrom[bef_idx];
                    result.insert(result.begin(), Point::parse(bef_idx, w));
                }
                break;
            }

            auto cur_cell = &cells[cur_idx];
            Point cur_pos = Point::parse(cur_idx, w);
            int n_gScore = cur_cell->gScore + 1;

            for(auto ar=arrows.begin(); ar<arrows.end(); ar++)
            {
                Point n_pos = cur_pos + *ar;

                if(n_pos.x<0||n_pos.x>=w||n_pos.y<0||n_pos.y>=h||!check(n_pos.x,n_pos.y))
                {
                    continue;
                }

                int n_idx = n_pos.index(w);
                auto n_cell = &cells[n_idx];

                if (n_gScore < n_cell->gScore)
                {
                    cameFrom[n_idx] = cur_idx;
                    n_cell->gScore = n_gScore;
                    n_cell->fScore = n_gScore + get_heuristic(n_pos, end);

                    openSet.insert({n_cell->fScore, n_idx});
                }
            }
        }

        return result;
    }
};

int solution(vector<vector<int>> maze)
{
    Point start(0,0);
    Point end(2,3);

    auto isPass = [maze](int x, int y) { return maze[y][x] == 0; };

    auto result = Astar::Find(maze[0].size(), maze.size(), start, end, isPass);

    for(auto p:result)
    {
        printf("%d,%d\n", p.x,p.y);
    }

    return 0;
}

int main()
{
    solution({{0, 0, 0},
              {0, 0, 0},
              {1, 0, 1},
              {0, 0, 0}});
    return 0;
}
