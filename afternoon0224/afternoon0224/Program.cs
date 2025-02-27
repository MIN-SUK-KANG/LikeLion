using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace afternoon0224
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            2024오후문제
            문제 1. 세 정수의 최대값 구하기
            문제 설명:
            사용자로부터 3개의 정수를 입력받아 그 중 가장 큰 값을 출력하는 프로그램을 작성하세요.
            요구사항:

            사용자에게 세 개의 정수를 입력받습니다.
            if문을 사용하여 가장 큰 정수를 결정합니다.
            결과를 “최대값: X” 형식으로 출력합니다.
             */
            Console.WriteLine("==========================================================================\n\n");

            Console.WriteLine("오후 문제 1번. 3개의 정수를 받아 최대값을 출력하기.\n\n");

            Console.WriteLine("1번째 정수를 입력해주세요:");
            int first = int.Parse(Console.ReadLine());
            Console.WriteLine("2번째 정수를 입력해주세요:");
            int second = int.Parse(Console.ReadLine());
            Console.WriteLine("3번째 정수를 입력해주세요:");
            int third = int.Parse(Console.ReadLine());

            Console.WriteLine("\n\n계산중...\n\n");

            if (first > second)
            {
                if (first > third)
                {
                    Console.WriteLine($"최대값: {first}");
                }
                else
                {
                    Console.WriteLine($"최대값: {third}");
                }
            }
            else
            {
                if (second > third)
                {
                    Console.WriteLine($"최대값: {second}");
                }
                else
                {
                    Console.WriteLine($"최대값: {third}");
                }
            }


            /*
            문제 2. 점수에 따른 학점 평가
            문제 설명:
            학생의 점수를 입력받아 아래 기준에 따라 학점을 출력하는 프로그램을 작성하세요.

            90 이상: A 학점
            80 이상 90 미만: B 학점
            70 이상 80 미만: C 학점
            60 이상 70 미만: D 학점
            60 미만: F 학점
             */
            Console.WriteLine("\n==========================================================================\n");

            Console.WriteLine("오후 문제 2번. 학생의 점수를 입력받아, 아래 기준에 따라 학점을 출력하기.\n");

            Console.WriteLine("90 이상: A 학점");
            Console.WriteLine("80 이상 90 미만: B 학점");
            Console.WriteLine("70 이상 80 미만: C 학점");
            Console.WriteLine("60 이상 70 미만: D 학점");
            Console.WriteLine("60 미만: F 학점");

            Console.WriteLine("\n0~100 사이의 숫자로, 학생의 점수를 입력해주세요: ");
            int score = int.Parse(Console.ReadLine());

            if (score < 60)
            {
                Console.WriteLine($"\n{score}점: F 학점");
            }
            else if (score < 70)
            {
                Console.WriteLine($"\n{score}점: D 학점");
            }
            else if (score < 80)
            {
                Console.WriteLine($"\n{score}점: C 학점");
            }
            else if (score < 90)
            {
                Console.WriteLine($"\n{score}점: B 학점");
            }
            else
            {
                Console.WriteLine($"\n{score}점: A 학점");
            }




            /*
            문제 3. 간단한 사칙연산 계산기
            문제 설명:
            사용자로부터 두 개의 숫자와 연산자(+, -, *, /)를 입력받아 해당 연산을 수행하고 결과를 출력하는 계산기 프로그램을 작성하세요.
            요구사항:

            두 개의 숫자와 연산자 기호를 입력받습니다.
            if문을 사용하여 연산자를 확인하고 해당 연산을 수행합니다.
            나눗셈의 경우 0으로 나누는 상황을 처리하여 에러 메시지를 출력합니다.
            결과는 “결과: X” 형식으로 출력합니다.
             */
            Console.WriteLine("\n==========================================================================\n");

            Console.WriteLine("오후 문제 3번. 사용자로부터 두 개의 숫자와 사칙연산 기호를 받아 사칙연산 처리.\n÷0 발생시 에러 메시지 출력.\n");

            Console.WriteLine("첫번째 숫자: ");
            int before = int.Parse(Console.ReadLine());
            Console.WriteLine("바라는 사칙연산\n+, -, *, /의 기호 중 하나로 표기해주세요:");
            string symbol = Console.ReadLine();
            Console.WriteLine("두번째 숫자: ");
            int after = int.Parse(Console.ReadLine());

            if (symbol == "/" && after == 0)
            {
                Console.WriteLine("\nERROR! 0으로 나눌 수 없습니다. ERROR!\nERROR! 0으로 나눌 수 없습니다. ERROR!\nERROR! 0으로 나눌 수 없습니다. ERROR!");
            }
            else
            {
                if (symbol == "/")
                {
                    double result = (double)(before / after);
                    string fourdigit = result.ToString("F4");

                    Console.WriteLine($"\n소수점 밑 4자리수까지 계산해, {before}{symbol}{after} = {fourdigit}입니다.");
                }
                else
                {
                    int calcul = 0;
                    if (symbol == "+")
                    {
                        calcul = before + after;
                    }
                    else if (symbol == "-")
                    {
                        calcul = before - after;
                    }
                    else if (symbol == "*")
                    {
                        calcul = before * after;
                    }
                    else
                    {
                        Console.WriteLine("사칙연산 기호 말고 다른거 입력했네... 오류입니다.");
                    }

                    Console.WriteLine($"\n{before}{symbol}{after} = {calcul}입니다.");
                }
            }
            Console.WriteLine("\n==========================================================================\n");


            /*
            //시간남는사람
            나만의 텍스트노벨 배운내용 더 넣어서 만들기
             */
        }
    }
}
