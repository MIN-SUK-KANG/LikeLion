using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace afternoon0226
{
    class Program
    {
        static int SumGiven(int a, int b)
        {
            //Q7.두 수의 합을 구하는 함수
            //문제: 두 개의 정수를 입력받아 합을 반환하는 함수를 작성하세요.
            //3과 5의 합: 8

            return a + b;
        }
        static int StringLength(String given)
        {
            return given.Length;
        }
        static int MaxGiven(int x, int y, int z)
        {
            int[] got = { x, y, z };
            int max = 0;
            for (int i = 0; i < 3; i++)
            {
                if (got[i] > max) max = got[i];
            }
            return max;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            //2026오후문제
            //배열 관련 문제(3문제)

            //Q1.배열 요소 출력
            //문제: 크기가 5인 정수 배열을 만들고, { 10, 20, 30, 40, 50}값을 저장한 후 출력하세요.
            //10 20 30 40 50
            int[] num1 = {10, 20, 30, 40, 50 };

            Console.WriteLine("Q1. 저장 후 출력\n");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{num1[i]} ");
            }
            Console.WriteLine("\n------------------------------");
            //Q2.배열 요소 합 구하기
            //문제: 사용자가 5개의 정수를 입력하면 배열에 저장하고, 모든 수의 합을 출력하세요.
            //숫자 입력: 1 2 3 4 5
            //총 합: 15
            int[] num2 = new int[5];
            int sum = 0;
            Console.WriteLine("Q2. 입력값 배열에 저장 이후 합 출력\n");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{i+1}번째 정수: ");
                bool success = int.TryParse(Console.ReadLine(), out int ask);
                if (success == true)
                {
                    num2[i] = ask;
                }
                else
                {
                    Console.WriteLine("제대로 숫자를 입력해주세요");
                    i--;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                sum += num2[i];
            }

            Console.WriteLine($"\n총 합: {sum}");
            Console.WriteLine("------------------------------");


            //Q3.최대값 찾기
            //문제: 정수 배열 { 3, 8, 15, 6, 2}에서 가장 큰 값을 찾아 출력하세요.
            //최대값: 15
            int[] num3 = { 3, 8, 15, 6, 2 };
            int max = 0;
            for (int i = 0; i < 5; i++)
            {
                if (num3[i] > max) max = num3[i];
            }

            Console.WriteLine("Q3. 정수 배열 {3, 8, 15, 6, 2}에서 최대값 찾아 출력\n");
            Console.WriteLine($"최대값: {max}");
            Console.WriteLine("------------------------------");


            //반복문 관련 문제(3문제)
            //for / while / foreach 반복문을 연습하는 문제

            //Q4. 1부터 10까지 출력(for문)
            //문제: for문을 사용하여 1부터 10까지 출력하세요.
            //1 2 3 4 5 6 7 8 9 10
            Console.WriteLine("Q4. for문을 사용하여 1부터 10까지 출력\n");

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i+1} ");
            }

            Console.WriteLine("\n------------------------------");


            //Q5.짝수만 출력(while문)
            //문제: while문을 사용하여 1부터 10까지 중 짝수만 출력하세요.
            //2 4 6 8 10
            Console.WriteLine("Q5. for문을 사용하여 1부터 10까지 중에서 짝수만 출력\n");

            for (int i = 1; i <= 10; i++)
            {
                if (i%2 == 0)
                {
                    Console.Write($"{i} ");
                }
            }

            Console.WriteLine("\n------------------------------");


            //Q6.배열 요소 출력(foreach문)
            //문제: foreach문을 사용하여 배열 { 1, 2, 3, 4, 5}의 요소를 출력하세요.
            //1 2 3 4 5
            Console.WriteLine("Q6. foreach문을 사용하여 배열 { 1, 2, 3, 4, 5}의 요소를 출력\n");
            int[] num6 = { 1, 2, 3, 4, 5 };
            foreach(int number in num6)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine("\n------------------------------");


            //함수 관련 문제(3문제)
            //함수를 선언하고, 매개변수와 반환값을 연습하는 문제

            //Q7.두 수의 합을 구하는 함수
            //문제: 두 개의 정수를 입력받아 합을 반환하는 함수를 작성하세요.
            //3과 5의 합: 8

            Console.WriteLine("Q7. 두 개의 정수를 입력받아 합을 반환하는 함수\n");

            bool success1 = false, success2 = false;
            int first = 0, second = 0;


            while (success1 == false)
            {
                Console.Write("1번째 정수: ");
                success1 = int.TryParse(Console.ReadLine(), out first);
                if (success1 != true)
                {
                    Console.WriteLine("제대로 숫자를 입력해주세요");
                }
            }


            while (success2 == false)
            {
                Console.Write("2번째 정수: ");
                success2 = int.TryParse(Console.ReadLine(), out second);
                if (success2 != true)
                {
                    Console.WriteLine("제대로 숫자를 입력해주세요");
                }
            }

            Console.WriteLine($"\n{first}과 {second}의 합: {SumGiven(first, second)}");

            Console.WriteLine("------------------------------");

            //Q8.문자열 길이 반환 함수
            //문제: 문자열을 입력받아 길이를 반환하는 함수를 작성하세요.
            //문자열 입력: Hello
            //문자열 길이: 5

            Console.WriteLine("Q8. 문자열을 입력받아 길이를 반환하는 함수");

            Console.Write("\n문자열 입력: ");

            Console.WriteLine($"\n문자열 길이: {StringLength(Console.ReadLine())}");

            Console.WriteLine("------------------------------");

            //Q9.가장 큰 수 반환 함수
            //문제: 세 개의 정수를 입력받아 가장 큰 값을 반환하는 함수를 작성하세요.
            //가장 큰 수: 7

            Console.WriteLine("Q9. 세 개의 정수를 입력받아 가장 큰 값을 반환하는 함수\n");

            bool success91 = false, success92 = false, success93 = false;
            int first9 = 0, second9 = 0, third9 = 0;


            while (success91 == false)
            {
                Console.Write("1번째 정수: ");
                success91 = int.TryParse(Console.ReadLine(), out first9);
                if (success91 != true)
                {
                    Console.WriteLine("제대로 숫자를 입력해주세요");
                }
            }

            while (success92 == false)
            {
                Console.Write("2번째 정수: ");
                success92 = int.TryParse(Console.ReadLine(), out second9);
                if (success92 != true)
                {
                    Console.WriteLine("제대로 숫자를 입력해주세요");
                }
            }

            while (success93 == false)
            {
                Console.Write("3번째 정수: ");
                success93 = int.TryParse(Console.ReadLine(), out third9);
                if (success93 != true)
                {
                    Console.WriteLine("제대로 숫자를 입력해주세요");
                }
            }

            Console.WriteLine($"\n가장 큰 수: {MaxGiven(first9, second9, third9)}");

            Console.WriteLine("========================================");
        }
    }
}
