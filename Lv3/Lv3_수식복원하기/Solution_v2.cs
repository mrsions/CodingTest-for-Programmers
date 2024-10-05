/// <source>https://school.programmers.co.kr/learn/courses/30/lessons/340210</source>
/// <solveTime>90m</solveTime>
/// <imporveTime>30m</imporveTime>
/// <summary>
/// 
/// regex 제거 (속도향상 큼)
/// 버퍼 제거  (속도향상 적음)
/// 계산결과를 Span으로 변경 (속도향상 적음)
/// 
/// </summary>

using System;
using System.Runtime.CompilerServices;

public class Solution
{
    const int MAX_NUMBER_SYSTEM = 9;
    const int MIN_NUMBER_SYSTEM = 2;

    public enum Operation
    {
        Plus,
        Minus
    }

    public struct Expression
    {
        public bool isAnswer;
        public string lhs;
        public Operation op;
        public string rhs;
        public string result;

        public override string ToString()
        {
            return $"{lhs} {(op == Operation.Plus ? '+' : '-')} {rhs} = {result}";
        }
    }

    public string[] solution(string[] expressions)
    {
        Expression[] exps = new Expression[expressions.Length];

        // 최대갯수와 문제 갯수 추출
        int answerCount = 0;
        int maxNumber = MIN_NUMBER_SYSTEM - 1;
        for (int i = 0; i < expressions.Length; i++)
        {
            string expression = expressions[i];
            var items = expression.Split(' ');

            Expression exp = new Expression();

            // 수식 입력
            exp.lhs = items[0];
            exp.rhs = items[2];
            exp.result = items[4];
            exp.isAnswer = exp.result == "X";

            switch (items[1])
            {
                case "+": exp.op = Operation.Plus; break;
                case "-": exp.op = Operation.Minus; break;
                default: throw new ArgumentException($"Unkown operation '{items[1]}'");
            };

            exps[i] = exp;

            // 최대값 입력
            if (maxNumber < MAX_NUMBER_SYSTEM - 1)
            {
                SetMaxNumber(exp.lhs, ref maxNumber);
                SetMaxNumber(exp.rhs, ref maxNumber);
                if (!exp.isAnswer) SetMaxNumber(exp.result, ref maxNumber);
            }

            if (exp.isAnswer) answerCount++;
        }

        // 값변경
        int numberSystem = maxNumber + 1;
        bool matchedNumberSystem = numberSystem == MAX_NUMBER_SYSTEM;

        // 연산값 추론
        if (!matchedNumberSystem)
        {
            for (int i = 0; i < exps.Length; i++)
            {
                Expression exp = exps[i];
                if (exp.isAnswer) continue;
                var expResult = exp.result.AsSpan();

                // 최대결과와 주어진 결과가 같다는것은
                // 추론할 수 있는 정보가 없다는 뜻.
                var result = Calc(exp, MAX_NUMBER_SYSTEM);
                if (result.SequenceEqual(expResult))
                {
                    continue;
                }

                for (int j = numberSystem; j < MAX_NUMBER_SYSTEM; j++)
                {
                    result = Calc(exp, j);
                    if (result.SequenceEqual(expResult))
                    {
                        numberSystem = j;
                        break;
                    }
                }

                matchedNumberSystem = true;
                break;
            }
        }

        // 결과도출
        string[] answer = new string[answerCount];
        int answerIdx = 0;
        if (matchedNumberSystem)
        {
            for (int i = 0; i < exps.Length; i++)
            {
                Expression exp = exps[i];
                if (!exp.isAnswer) continue;

                exp.result = new string(Calc(exp, numberSystem));
                answer[answerIdx++] = exp.ToString();
            }
        }
        else
        {
            var origin = m_TempCharResult;
            var temp = new char[origin.Length];

            for (int i = 0; i < exps.Length; i++)
            {
                Expression exp = exps[i];
                if (!exp.isAnswer) continue;

                m_TempCharResult = origin;
                var minResult = Calc(exp, numberSystem);
                m_TempCharResult = temp;
                var maxResult = Calc(exp, MAX_NUMBER_SYSTEM);

                exp.result = minResult.SequenceEqual(maxResult) ? new string(minResult) : "?";
                answer[answerIdx++] = exp.ToString();
            }
        }

        return answer;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SetMaxNumber(string strNumber, ref int max)
    {
        for (int i = 0; i < strNumber.Length; i++)
        {
            char c = strNumber[i];
            int number = c - '0';
            if (number < 0 || number > 9) continue;

            if (max < number)
            {
                max = number;
            }
        }
    }

    char[] m_TempCharResult = new char[11]; // int 최대길이
    private Span<char> Calc(Expression exp, int numberSystem)
    {
        int length = exp.op == Operation.Plus
            ? Math.Max(exp.lhs.Length, exp.rhs.Length) + 1
            : Math.Max(exp.lhs.Length, exp.rhs.Length);

        // 초기화
        Span<char> result = m_TempCharResult.AsSpan<char>().Slice(0, length);
        result.Fill('0');

        var lhs = exp.lhs;
        var rhs = exp.rhs;

        // 계산
        if (exp.op == Operation.Plus)
        {
            for (int i = 0; i < length; i++)
            {
                int l = GetCharReverse(lhs, i) - '0';
                int r = GetCharReverse(rhs, i) - '0';
                int v = result[i] - '0';

                v = l + r + v;
                if (v >= numberSystem)
                {
                    result[i + 1] = '1';
                    v -= numberSystem;
                }
                result[i] = (char)(v + '0');
            }
        }
        else
        {
            // 음수 결과가 없기에 계산식 단순화
            for (int i = 0; i < length; i++)
            {
                int l = GetCharReverse(lhs, i) - '0';
                int r = GetCharReverse(rhs, i) - '0';
                int v = result[i] - '0';

                v = l - r - v;
                if (v < 0)
                {
                    result[i + 1] = '1';
                    v += numberSystem;
                }
                result[i] = (char)(v + '0');
            }
        }

        // 반전
        result.Reverse();

        // 사용하지않은 글자 제외
        while (result.Length > 1 && (result[0] == 0 || result[0] == '0'))
        {
            result = result.Slice(1);
        }

        return result;
    }

    private char GetCharReverse(string source, int index)
    {
        int len = source.Length;
        if (index < len)
        {
            index = len - index - 1;
            return source[index];
        }
        else
        {
            return '0';
        }
    }
}