//#include <vector>
//#include <queue>
//#include <set>
//#include <tuple>
//#include <iostream>
//
//using namespace std;
//
//struct Point {
//    int x, y;
//
//    Point(int x, int y) : x(x), y(y) {}
//
//    bool operator==(const Point& o) const {
//        return x == o.x && y == o.y;
//    }
//
//    bool operator!=(const Point& o) const {
//        return !(*this == o);
//    }
//
//    bool operator<(const Point& o) const {
//        return y < o.y || (y == o.y && x < o.x);
//    }
//};
//
//struct State {
//    Point red, blue;
//    int depth;
//
//    State(Point r, Point b, int d) : red(r), blue(b), depth(d) {}
//};
//
//bool isValid(Point p, int w, int h, vector<vector<int>>& maze) {
//    return p.x >= 0 && p.x < w && p.y >= 0 && p.y < h && maze[p.y][p.x] != 5;
//}
//
//int bfs(vector<vector<int>> maze, Point redStart, Point redGoal, Point blueStart, Point blueGoal) {
//    int w = maze[0].size(), h = maze.size();
//    vector<Point> directions = { {0, 1}, {1, 0}, {0, -1}, {-1, 0} };
//    queue<State> q;
//    set<pair<Point, Point>> visited;
//
//    q.push(State(redStart, blueStart, 0));
//    visited.insert({ redStart, blueStart });
//
//    while (!q.empty()) {
//        State current = q.front();
//        q.pop();
//
//        // 두 수레가 도착점에 도달했는지 확인
//        if (current.red == redGoal && current.blue == blueGoal) {
//            return current.depth;
//        }
//
//        for (const auto& dirRed : directions) {
//            Point newRed = { current.red.x + dirRed.x, current.red.y + dirRed.y };
//            if (newRed == redGoal) newRed = redGoal;  // 도착점 고정
//            if (!isValid(newRed, w, h, maze) || newRed == current.blue) continue;
//
//            for (const auto& dirBlue : directions) {
//                Point newBlue = { current.blue.x + dirBlue.x, current.blue.y + dirBlue.y };
//                if (newBlue == blueGoal) newBlue = blueGoal;  // 도착점 고정
//                if (!isValid(newBlue, w, h, maze) || newBlue == newRed || (newRed == current.blue && newBlue == current.red)) continue;
//
//                // 방문 상태 체크
//                if (visited.count({ newRed, newBlue }) == 0) {
//                    visited.insert({ newRed, newBlue });
//                    q.push(State(newRed, newBlue, current.depth + 1));
//                }
//            }
//        }
//    }
//    return 0;  // 풀 수 없는 경우
//}
//
//int solution(vector<vector<int>> maze) {
//    Point redStart(0, 0), redGoal(0, 0), blueStart(0, 0), blueGoal(0, 0);
//
//    for (int y = 0; y < maze.size(); y++) {
//        for (int x = 0; x < maze[0].size(); x++) {
//            if (maze[y][x] == 1) redStart = { x, y };
//            if (maze[y][x] == 3) redGoal = { x, y };
//            if (maze[y][x] == 2) blueStart = { x, y };
//            if (maze[y][x] == 4) blueGoal = { x, y };
//        }
//    }
//
//    return bfs(maze, redStart, redGoal, blueStart, blueGoal);
//}
//
//// 디버그를 위한 main 함수
//int main() {
//    vector<vector<int>> maze1 = {
//        {1, 4},
//        {0, 0},
//        {2, 3}
//    };
//    cout << solution(maze1) << endl;  // Expected: 3
//
//    vector<vector<int>> maze2 = {
//        {1, 0, 2},
//        {0, 0, 0},
//        {5, 0, 5},
//        {4, 0, 3}
//    };
//    cout << solution(maze2) << endl;  // Expected: 7
//
//    vector<vector<int>> maze3 = {
//        {1, 5},
//        {2, 5},
//        {4, 5},
//        {3, 5}
//    };
//    cout << solution(maze3) << endl;  // Expected: 0
//
//    vector<vector<int>> maze4 = {
//        {4, 1, 2, 3}
//    };
//    cout << solution(maze4) << endl;  // Expected: 0
//
//    return 0;
//}
