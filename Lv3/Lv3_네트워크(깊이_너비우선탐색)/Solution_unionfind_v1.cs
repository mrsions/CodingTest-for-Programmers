// 실패한 소스코드

///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/43162?language=csharp</source>
///// <reading>7:47~7:50 이해가 안됨</reading>
///// <coding>7:51~8:17 8:40~</coding>
///// <summary>
///// union-find 알고리즘
///// </summary>
///// <failed>
///// 기본제공세트에서는 통과했지만, 최종테스트에서 통과하지못함
///// 너무 복잡하게 생각한것 같음
///// </failed>

//using System;
//using System.IO.Pipes;
//using System.Linq;

//public class Solution
//{
//    public int solution(int n, int[,] computers)
//    {
//        int answer = 0;

//        int genId = 0;
//        int[] networkIds = new int[n];
//        for (int i = 0; i < n; i++)
//        {
//            int myNetId = networkIds[i];

//            // id 찾기
//            if (myNetId == 0)
//            {
//                for (int j = 0; j < n; j++)
//                {
//                    if (computers[i, j] == 1)
//                    {
//                        myNetId = networkIds[j];
//                        break;
//                    }
//                }
//            }

//            // 새로운 네트워크 등록
//            if (myNetId == 0)
//            {
//                myNetId = ++genId;
//                answer++;
//            }

//            // 연결된 컴퓨터에 id 추가
//            for (int j = 0; j < n; j++)
//            {
//                if (computers[i, j] == 1)
//                {
//                    ref int befNetId = ref networkIds[j];
//                    if (befNetId == 0)
//                    {
//                        befNetId = myNetId;
//                    }
//                    else if (befNetId != myNetId)
//                    {
//                        for (int k = 0; k < j; k++)
//                        {
//                            if (networkIds[j] == myNetId)
//                            {
//                                networkIds[j] = befNetId;
//                            }
//                        }
//                        myNetId = befNetId;
//                        answer--;
//                    }
//                }
//            }
//            //Console.WriteLine(string.Join(" ", networkIds.Select(v => v.ToString())));
//        }

//        //Console.ReadLine();
//        return answer;
//    }
//}