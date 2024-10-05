#include <iostream>
#include <string>
#include <vector>

using namespace std;

vector<int> solution(vector<string> operations);

int main()
{
	vector<string> params = { "I 1", "I 3", "I 5", "I 7", "I 9", "D -1", "D -1", "D 1", "I 2", "D 1", "D 1" };
	vector<int> expect  = { 2, 2 };

	vector<int> result = solution(params);

    if (expect == result) {
        cout << "성공" << endl;
    }
    else {
        cout << "실패" << endl;
    }
}