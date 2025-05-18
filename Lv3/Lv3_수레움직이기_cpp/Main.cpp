//#include "../../Shared_cpp/Test.h"
//
//using namespace std;
//
//int solution(vector<vector<int>> operations);
//
//int main()
//{
//    Test::Add([]() { return solution({ {1,0,2},{0,0,0}, {5,0,5}, {4,0,3} }) == 7; });
//    //Test::Add([]() { return solution({ {1,2,0},{0,0,0}, {5,0,5}, {4,0,3} }) == 5; });
//    //Test::Add([]() { return solution({ {1,0,0,1},{0,0,0}, {5,0,5}, {4,0,3} }) == 5; });
//    //Test::Add([]() { return solution({ {5, 0, 3, 5}, {0, 0, 0, 0}, {5, 0, 4, 0}, {5, 2, 1, 0} }) == 3; });
//    Test::Run();
//    return 0;
//}

#include <vector>
#include <unordered_set>
#include <iostream>

using namespace std;

struct Point
{
	int x, y;

	bool operator==(const Point& o) const { return x == o.x && y == o.y; }
	void operator()(int a) {
		cout << "??" << a << endl;
	}
	int operator()(int a, int b) {
		cout << "--" << a << endl;
		return b;
	}
};


int main()
{
	Point a;
	a(1);
	a(1,2);
}