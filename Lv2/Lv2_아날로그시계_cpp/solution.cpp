// https://school.programmers.co.kr/learn/courses/30/lessons/250135


#include <stdlib.h>
#include <iostream>

using namespace std;

double fmod1(double a)
{
    while (a >= 1.0)
    {
        a -= 1.0;
    }
    return a;
}
double fmod1n(double a) 
{
    while(a > 1)
    {
        a -= 1;
    }
    return a;
}

int solution(int h1, int m1, int s1, int h2, int m2, int s2) 
{
    int answer = 0;

    int t1 = h1*3600 + m1*60 + s1;
    int t2 = h2*3600 + m2*60 + s2;

    if (t1 == 0 || t1 == 12*3600)
    {
        answer ++;
    }

    int hc=0,mc=0,zc=0;

    for(int t=t1; t<t2; t++)
    {
        double cur_h = fmod1((double)t / (12 * 60 * 60));
        double cur_m = fmod1((double)t / (60 * 60));
        double cur_s = fmod1((double)t / (60));

        int h = t/3600, m = (t/60)%60, s = t%60;
        if(s == 0)
        {
            if(hc != 1 || mc != 1)
            {
                printf("%02d:%02d:%02d   %d %d %d\n", h,m,s,hc,mc,zc);
            }
            hc=0;
            mc=0;
            zc=0;
        }

        double nxt_h = fmod1n((double)(t+1) / (12 * 60 * 60));
        double nxt_m = fmod1n((double)(t+1) / (60 * 60));
        double nxt_s = fmod1n((double)(t+1) / (60));

        if (cur_s < cur_h && nxt_h <= nxt_s)
        {
            answer++;
            hc++;
        }
        if (cur_s < cur_m && nxt_m <= nxt_s)
        {
            answer++;
            mc++;
        }
        if (nxt_h == nxt_m)
        {
            answer--;
            zc++;
        }
    }

    return answer;
}

int main()
{
    cout << "v1" << endl;
    // cout << "Case1: " << (solution(0,5,30,0,7,0)==2?"OK":"NO") << endl;
    // cout << "Case2: " << (solution(12,0,0,12,0,30)==1?"OK":"NO") << endl;
    // cout << "Case4: " << (solution(11, 59, 30, 12, 0, 0)==1?"OK":"NO") << endl;
    // cout << "Case5: " << (solution(11, 58, 59, 11, 59, 0)==1?"OK":"NO") << endl;
    cout << "Case7: " << (solution(	0, 0, 0, 23, 59, 59)==2852?"OK":"NO") << endl;
    return 0;
}