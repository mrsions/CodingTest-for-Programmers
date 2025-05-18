#include "pch.h"

struct RunItem
{
	function<bool()> func;
};

vector<RunItem> items;

void Test::Add(function<bool()> func)
{
	RunItem item = { func };

	items.push_back(item);
}

// TODO: 라이브러리 함수의 예제입니다.
void Test::Run()
{
	for (size_t i = 0; i < items.size(); i++)
	{
		try
		{
			if (items[i].func())
			{
				cout << "Case " << (i + 1) << ": Success" << endl;
			}
			else
			{
				cout << "Case " << (i + 1) << ": Failed" << endl;
			}
		}
		catch (int ex)
		{
			cout << ex << endl;
		}
	}
};