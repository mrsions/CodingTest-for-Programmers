// Simple Benchmark 6653 / 5.000053 = 7515.486246805952 cpt

#include <iostream>
#include <string>
#include <vector>

using namespace std;

struct Handle
{
	Handle* l;
	Handle* r;
	int v;
};

vector<int> solution(vector<string> operations) {

	int size = 0;
	int curSize = 0;
	for (int i = 0; i < operations.size(); i++)
	{
		string operation = operations[i];
		if (operation[0] == 'I')
		{
			curSize++;
			if (curSize > size)
			{
				size = curSize;
			}
		}
		else if (curSize > 0)
		{
			curSize--;
		}
	}

	int len = sizeof(Handle) * size;
	Handle* ptr = (Handle*)malloc(len);

	Handle* consumable = ptr;
	Handle* consumeEnd = consumable + size;

	Handle* pool = NULL;

	Handle* root = NULL;


	for (int i = 0; i < operations.size(); i++)
	{
		string operation = operations[i];
		if (operation[0] == 'I')
		{
			int v = stoi(operation.substr(2));

			Handle* h = NULL;
			if (consumable < consumeEnd)
			{
				h = consumable++;
			}
			else
			{
				h = pool;
				pool = pool->r;
			}
			h->v = v;
			h->l = NULL;
			h->r = NULL;

			if (root == NULL)
			{
				root = h;
			}
			else
			{
				Handle* target = root;
				while (true)
				{
					// 적다면
					if (v < target->v)
					{
						if (target->l == NULL)
						{
							target->l = h;
							break;
						}
						else
						{
							target = target->l;
						}
					}
					// 크다면
					else
					{
						if (target->r == NULL)
						{
							target->r = h;
							break;
						}
						else
						{
							target = target->r;
						}
					}
				}
			}
		}
		else
		{
			if (root == NULL) continue;

			if (operation[2] == '1')
			{
				Handle* parent = NULL;
				Handle* target = root;
				while (target->r != NULL)
				{
					parent = target;
					target = target->r;
				}

				if (parent == NULL)
				{
					root = target->l;
				}
				else
				{
					parent->r = target->l;
				}

				if (pool == NULL)
				{
					pool = target;
					pool->r = NULL;
				}
				else
				{
					target->r = pool;
					pool = target;
				}
			}
			else
			{
				Handle* parent = NULL;
				Handle* target = root;
				while (target->l != NULL)
				{
					parent = target;
					target = target->l;
				}

				if (parent == NULL)
				{
					root = target->r;
				}
				else
				{
					parent->l = target->r;
				}

				if (pool == NULL)
				{
					pool = target;
					target->r = NULL;
				}
				else
				{
					target->r = pool;
					pool = target;
				}
			}
		}
	}

	vector<int> answer;
	if (root != NULL)
	{
		Handle* max = root;
		while (max->r != NULL)
		{
			max = max->r;
		}
		Handle* min = root;
		while (min->l != NULL)
		{
			min = min->l;
		}
		answer.push_back(max->v);
		answer.push_back(min->v);
	}
	else 
	{
		answer.push_back(0);
		answer.push_back(0);
	}

	free(ptr);
	return answer;
}