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


namespace Dijkstra
{
    struct Link;

    struct Node
    {
        vector<Link> links;
    };

    struct Link
    {
        int distance;
        Node* node;

        bool operator <(const Link& other) const 
        {
            if (distance == other.distance)
            {
                return node < other.node;
            }
            return distance < other.distance;
        }
    };

    template<typename K, typename V>
    V get_value_or_default(map<K,V> list, K key, V def_value)
    {
        if (list.find(key) == list.end())
        {
            return def_value;
        }
        else
        {
            return list[key];
        }
    }

    vector<Node*> Find(Node* start, Node* end)
    {
        const int maxint = numeric_limits<int>::max();

        map<Node*, int> distances;
        set<Node*> visited;
        set<Link> current_links;
        map<Node*, Node*> cameFrom;

        distances[start] = 0;
        current_links.insert({0, start});

        vector<Node*> result;
        while(current_links.size())
        {
            auto c_it = current_links.begin();
            auto c_link = *c_it;
            current_links.erase(c_it);
            printf("Curr %p\n", c_link.node);
            
            if(c_link.node == end)
            {
                auto l_node = end;
                result.push_back(l_node);
                while(cameFrom.find(l_node) != cameFrom.end())
                {
                    l_node = cameFrom[l_node];
                    result.insert(result.begin(), l_node);
                }
                break;
            }

            if(visited.find(c_link.node) != visited.end())
            {
                printf("Visited %p\n", c_link.node);
                continue;
            }
            visited.insert(c_link.node);

            for(auto link:c_link.node->links)
            {
                int new_distance = c_link.distance + link.distance;
                int n_distance = get_value_or_default(distances, link.node, maxint);

                if (new_distance < n_distance)
                {
                    cameFrom[link.node] = c_link.node;
                    distances[link.node] = new_distance;
                    current_links.insert({new_distance, link.node});
                    printf("Add %p %d\n", link.node, new_distance);
                }
            }
        }

        return result;
    }
}

struct PointNode : public Dijkstra::Node
{
    Point pos;
};

int solution(vector<vector<int>> maze)
{
    int w = maze[0].size();
    int h = maze.size();

    vector<Point> arrows = {{-1,0}, {0,1}, {1,0}, {0,-1}};

    PointNode* start;
    PointNode* end;

    vector<vector<PointNode>> points(h, vector<PointNode>(w));
    for(int y=0;y<h;y++)
    {
        for(int x=0;x<w;x++)
        {
            auto maze_val = maze[y][x];
            auto node = &points[y][x];
            node->pos = Point(x,y);

            if(maze_val == 2) start = node;
            else if(maze_val == 3) end = node;

            for(auto arrow:arrows)
            {
                auto apos = node->pos + arrow;
                
                if (apos.x < 0 || apos.x >= w || apos.y < 0 || apos.y >= h || maze_val == 1) continue;

                node->links.push_back({1, &points[apos.y][apos.x]});
            }
        }
    }

    auto result = Dijkstra::Find(start, end);

    for(auto item:result)
    {
        auto node = (PointNode*)item;
        printf("%d,%d\n", node->pos.x, node->pos.y);
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
