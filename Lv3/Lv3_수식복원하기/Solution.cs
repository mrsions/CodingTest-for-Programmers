///// <source>https://school.programmers.co.kr/learn/courses/30/lessons/340210</source>
///// <solveTime>90m</solveTime>
///// <summary>
///// 
///// 1. 진법을 찾는다는 개념의 min, max를 구하는 방식의 로직에서 
///// 단순화된 방식을 찾는데 오래걸림
///// 
///// 2. unsafe 및 stackalloc을 시도하다가 오래걸림
///// 
///// 3. 앞으로는 최대한 빠른 방법으로 작성한 뒤, 최적화를 통한 향상으로 방향을 잡기로 함.
/////
///// </summary>

//using System;
//using System.Runtime.CompilerServices;
//using System.Text.RegularExpressions;

//public class Solution
//{
//    const int MAX_NUMBER_SYSTEM = 9;
//    const int MIN_NUMBER_SYSTEM = 2;

//    public enum Operation
//    {
//        Plus,
//        Minus
//    }

//    public struct Expression
//    {
//        public bool isAnswer;
//        public string lhs;
//        public Operation op;
//        public string rhs;
//        public string result;

//        public override string ToString()
//        {
//            return $"{lhs} {(op == Operation.Plus ? '+' : '-')} {rhs} = {result}";
//        }
//    }

//    public string[] solution(string[] expressions)
//    {
//        Regex regex = new Regex(@"(\d+) (\+|\-) (\d+) = (X|\d+)", RegexOptions.Singleline | RegexOptions.Compiled);

//        Expression[] exps = new Expression[expressions.Length];

//        // 최대갯수와 문제 갯수 추출
//        int answerCount = 0;
//        int maxNumber = MIN_NUMBER_SYSTEM - 1;
//        for (int i = 0; i < expressions.Length; i++)
//        {
//            string expression = expressions[i];
//            Expression exp = new Expression();

//            var match = regex.Match(expression);
//            if (!match.Success)
//            {
//                throw new ArgumentException($"Unkown format '{expression}'");
//            }

//            // 수식 입력
//            exp.lhs = match.Groups[1].Value;
//            exp.rhs = match.Groups[3].Value;
//            exp.result = match.Groups[4].Value;
//            exp.isAnswer = exp.result == "X";

//            switch (match.Groups[2].Value)
//            {
//                case "+": exp.op = Operation.Plus; break;
//                case "-": exp.op = Operation.Minus; break;
//                default: throw new ArgumentException($"Unkown operation '{match.Groups[2].Value}'");
//            };

//            exps[i] = exp;

//            // 최대값 입력
//            if (maxNumber < MAX_NUMBER_SYSTEM - 1)
//            {
//                SetMaxNumber(exp.lhs, ref maxNumber);
//                SetMaxNumber(exp.rhs, ref maxNumber);
//                if (!exp.isAnswer) SetMaxNumber(exp.result, ref maxNumber);
//            }

//            if (exp.isAnswer) answerCount++;
//        }

//        // 값변경
//        int numberSystem = maxNumber + 1;
//        bool matchedNumberSystem = numberSystem == MAX_NUMBER_SYSTEM;

//        // 연산값 추론
//        if (!matchedNumberSystem)
//        {
//            foreach (var exp in exps)
//            {
//                if (exp.isAnswer) continue;

//                // 최대결과와 주어진 결과가 같다는것은
//                // 추론할 수 있는 정보가 없다는 뜻.
//                string maxResult = Calc(exp, MAX_NUMBER_SYSTEM);
//                if (exp.result == maxResult)
//                {
//                    continue;
//                }

//                for (int i = numberSystem; i < MAX_NUMBER_SYSTEM; i++)
//                {
//                    string rst = Calc(exp, i);
//                    if (exp.result == rst)
//                    {
//                        numberSystem = i;
//                        break;
//                    }
//                }

//                matchedNumberSystem = true;
//                break;
//            }
//        }

//        // 결과도출
//        string[] answer = new string[answerCount];
//        int answerIdx = 0;
//        if (matchedNumberSystem)
//        {
//            for (int i = 0; i < exps.Length; i++)
//            {
//                Expression exp = exps[i];
//                if (!exp.isAnswer) continue;

//                exp.result = Calc(exp, numberSystem);
//                answer[answerIdx++] = exp.ToString();
//            }
//        }
//        else
//        {
//            for (int i = 0; i < exps.Length; i++)
//            {
//                Expression exp = exps[i];
//                if (!exp.isAnswer) continue;

//                var minResult = Calc(exp, numberSystem);
//                var maxResult = Calc(exp, MAX_NUMBER_SYSTEM);
//                exp.result = minResult == maxResult ? minResult : "?";
//                answer[answerIdx++] = exp.ToString();
//            }
//        }

//        return answer;
//    }

//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    private void SetMaxNumber(string strNumber, ref int max)
//    {
//        foreach (char c in strNumber)
//        {
//            int number = c - '0';
//            if (number < 0 || number > 9) continue;

//            if (max < number)
//            {
//                max = number;
//            }
//        }
//    }

//    const int TEMP_LENGTH = 11;
//    char[] m_TempCharResult = new char[TEMP_LENGTH]; // int 최대길이
//    char[] m_TempCharLeft = new char[TEMP_LENGTH]; // int 최대길이
//    char[] m_TempCharRight = new char[TEMP_LENGTH]; // int 최대길이
//    private string Calc(Expression exp, int numberSystem)
//    {
//        int length = exp.op == Operation.Plus
//            ? Math.Max(exp.lhs.Length, exp.rhs.Length) + 1
//            : Math.Max(exp.lhs.Length, exp.rhs.Length);

//        // 초기화
//        Span<char> result = m_TempCharResult.AsSpan<char>().Slice(0, length);
//        Span<char> lhs = m_TempCharLeft.AsSpan<char>().Slice(0, length);
//        Span<char> rhs = m_TempCharRight.AsSpan<char>().Slice(0, length);
//        result.Fill('0');
//        lhs.Fill('0');
//        rhs.Fill('0');

//        // 값 복사 
//        exp.lhs.CopyTo(0, m_TempCharLeft, length - exp.lhs.Length, exp.lhs.Length);
//        exp.rhs.CopyTo(0, m_TempCharRight, length - exp.rhs.Length, exp.rhs.Length);

//        // 1의자리수부터 계산하기 위해 반전
//        lhs.Reverse();
//        rhs.Reverse();

//        // 계산
//        if (exp.op == Operation.Plus)
//        {
//            for (int i = 0; i < length; i++)
//            {
//                int l = Math.Max(0, lhs[i] - '0');
//                int r = Math.Max(0, rhs[i] - '0');
//                int v = Math.Max(0, result[i] - '0');

//                v = l + r + v;
//                if (v >= numberSystem)
//                {
//                    result[i + 1] = '1';
//                    v -= numberSystem;
//                }
//                result[i] = (char)(v + '0');
//            }
//        }
//        else
//        {
//            // 음수 결과가 없기에 계산식 단순화
//            for (int i = 0; i < length; i++)
//            {
//                int l = Math.Max(0, lhs[i] - '0');
//                int r = Math.Max(0, rhs[i] - '0');
//                int v = Math.Max(0, result[i] - '0');

//                v = l - r - v;
//                if (v < 0)
//                {
//                    result[i + 1] = '1';
//                    v += numberSystem;
//                }
//                result[i] = (char)(v + '0');
//            }
//        }

//        // 반전
//        result.Reverse();

//        // 사용하지않은 글자 제외
//        while (result.Length > 1 && (result[0] == 0 || result[0] == '0'))
//        {
//            result = result.Slice(1);
//        }

//        return new string(result);
//    }
//}