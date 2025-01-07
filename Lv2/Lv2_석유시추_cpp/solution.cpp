// https://school.programmers.co.kr/learn/courses/30/lessons/250136
// 

#include <string>
#include <vector>
#include <unordered_set>
#include <stack>
#include <iostream>
#include <random>

using namespace std;

struct Point
{
    int x;
    int y;
    
    int GetIndex(int width) const {
        return y*width + x;
    }
    bool IsValid(int w, int h)
    {
        return 0 <= x && x < w && 0 <= y && y < h;
    }
    Point operator+(const Point& rhs) const {
        return { x + rhs.x, y + rhs.y };
    }
    Point operator-(const Point& rhs) const {
        return { x - rhs.x, y - rhs.y };
    }
    bool operator==(const Point& rhs) const {
        return x == rhs.x && y == rhs.y;
    }
    bool operator!=(const Point& rhs) const {
        return x != rhs.x || y != rhs.y;
    }
};
struct Cell;
struct Group 
{
    vector<Cell*> cells;
};
struct Cell {
    Point pos;
    bool hasOil;
    Group* group;
};

int solution(vector< vector<int> > land) {
    
    int w = land[0].size();
    int h = land.size();
    int wh = w*h;
    
    Cell cells[wh];
    for (int y=0; y<h; y++)
    {
        for (int x=0; x<w; x++)
        {
            cells[y * w + x] = {{x,y}, land[y][x] == 1, nullptr};
        }
    }
    
    Point arrows[] = { {0,1}, {-1,0}, {1,0}, {0,-1} };
    vector<Group*> groups;
    for (int y=0; y<h; y++)
    {
        for (int x=0; x<w; x++)
        {
            Point p = {x, y};
            Cell* cell = cells + p.GetIndex(w);
            if (!cell->hasOil) continue;
            
            if (cell->group == nullptr)
            {
                Group* group = new Group();
                groups.push_back(group);
                
                stack<Cell*> targets;
                targets.push(cell);
                
                while (!targets.empty())
                {
                    Cell* c = targets.top();
                    targets.pop();
                    
                    if (c->group != nullptr)continue;
                    
                    c->group = group;
                    group->cells.push_back(c);
                    
                    for (size_t i=0; i<4; i++)
                    {
                        Point pa = c->pos + arrows[i];
                        if (!pa.IsValid(w,h)) continue;
                        Cell* ca = cells + pa.GetIndex(w);
                        if (!ca->hasOil) continue;
                        targets.push(ca);
                    }
                }
            }
        }
    }
    
    int answer = 0;
    for (int x=0; x<w; x++)
    {
        unordered_set<Group*> groups;
        
        int count = 0;
        for (int y=0; y<h; y++)
        {
            Point p = {x,y};
            Cell* c = cells + p.GetIndex(w);
            if (c->group == nullptr) continue;
            
            if(groups.insert(c->group).second)
            {
                count += c->group->cells.size();
            }
        }

        if (answer < count)
        {
            answer = count;
        }
    }
    
    return answer;
}


int main()
{
    // vector<vector<int>> data = {{0, 0, 0, 1, 1, 1, 0, 0}, {0, 0, 0, 0, 1, 1, 0, 0}, {1, 1, 0, 0, 0, 1, 1, 0}, {1, 1, 1, 0, 0, 0, 0, 0}, {1, 1, 1, 0, 0, 0, 1, 1}};
    
    srand(0);
    int w = 500;
    int h = 500;
    vector<vector<int>> data(h, vector<int>(w));
    for (int y = 0; y < h; y++) {
        for (int x = 0; x < w; x++) {
            data[y][x] = rand() % 2;
        }
    }
    auto start = chrono::high_resolution_clock::now();

    auto result = solution(data);

    auto end = chrono::high_resolution_clock::now();
    auto duration = chrono::duration_cast<chrono::milliseconds>(end - start);
    cout << result << ", " << duration.count() << "ms" << endl;
    
    return 0;
}