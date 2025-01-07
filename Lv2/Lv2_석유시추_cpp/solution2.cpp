// https://school.programmers.co.kr/learn/courses/30/lessons/250136
// 효율성 테스트 통과못함

#include <iostream>

#include <vector>
#include <stack>

using namespace std;

bool inline has_oil(vector<vector<int>>& land, int idx, int w, int wh)
{
    if (idx < 0 || idx >= wh) return false;

    return land[idx/w][idx%w] == 1;
}

int solution(vector< vector<int> > land) {
    
    int w = land[0].size();
    int h = land.size();
    int wh = w*h;
    
    stack<int> points;
    int answer = 0, idx;

    for (int x=0; x<w; x++)
    {
        for(int y=0; y<h; y++)
        {
            idx = y*w+x;
            if(has_oil(land,idx,w,wh))
            {
                points.push(idx);
            }
        }

        int count = 0;
        vector<bool> checks(wh, false);
        while(points.size())
        {
            idx = points.top();
            points.pop();

            if (idx < 0 || idx >= wh) continue;

            if(checks[idx]) continue;
            checks[idx] = true;
            int x = idx%w;
            int y = idx/w;

            if(land[y][x] == 0) continue;

            count++;

            if (x == 0)
            {
                if(has_oil(land,idx+1,w,wh)) points.push(idx+1);
            }
            else if(x == w-1)
            {
                if(has_oil(land,idx-1,w,wh)) points.push(idx-1);
            }
            else
            {
                if(has_oil(land,idx+1,w,wh)) points.push(idx+1);
                if(has_oil(land,idx-1,w,wh)) points.push(idx-1);
            }
            if(has_oil(land,idx-w,w,wh)) points.push(idx-w);
            if(has_oil(land,idx+w,w,wh)) points.push(idx+w);
        }

        if(answer < count)
        {
            answer = count;
        }
    }
    
    return answer;
}

int main()
{
    // vector<vector<int>> data = {{0, 0, 0, 1, 1, 1, 0, 0}, {0, 0, 0, 0, 1, 1, 0, 0}, {1, 1, 0, 0, 0, 1, 1, 0}, {1, 1, 1, 0, 0, 0, 0, 0}, {1, 1, 1, 0, 0, 0, 1, 1}};
    // bool result = (solution(data) == 9);

    // vector<vector<int>> data = {{1, 0, 1, 0, 1, 1}, {1, 0, 1, 0, 0, 0}, {1, 0, 1, 0, 0, 1}, {1, 0, 0, 1, 0, 0}, {1, 0, 0, 1, 0, 1}, {1, 0, 0, 0, 0, 0}, {1, 1, 1, 1, 1, 1}};
    // bool result = (solution(data) == 16);

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