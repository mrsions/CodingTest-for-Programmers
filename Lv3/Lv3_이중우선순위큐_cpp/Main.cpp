#include "Test.h"

using namespace std;

vector<int> solution(vector<string> operations);

int main()
{
    // 실행
    auto func = [](const vector<any>& params) { return solution(any_cast<vector<string>>(params[0])); };

    vector<TestCase> testCases = {
        TestCase(any(vector<int>{ 2, 2 }),     vector<any>{ vector<string> { "I 1", "I 3", "I 5", "I 7", "I 9", "D -1", "D -1", "D 1", "I 2", "D 1", "D 1" } }),
        TestCase(any(vector<int>{ 333, -45 }), vector<any>{ vector<string> { "I -45", "I 653", "D 1", "I -642", "I 45", "I 97", "D 1", "D -1", "I 333" } }),
        TestCase(any(vector<int>{ 2, 2 }),     vector<any>{ vector<string> { "I 1", "I 3", "I 5", "I 7", "I 9", "D -1", "D -1", "D 1", "I 2", "D 1", "D 1" } }),
        TestCase(vector<int> { 2086717672, 164982793 }, vector<any>{ Test::GetReadStringVector("commands.txt") })
    };
    Test::Run(func, testCases);

    return 0;
}