#pragma once

#define WIN32_LEAN_AND_MEAN             // 거의 사용되지 않는 내용을 Windows 헤더에서 제외합니다.

#include <vector>
#include <iostream>
#include <functional>

using namespace std;

class Test
{
public:
	static void Add(function<bool()> func);

	static void Run();
};