using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion8
{
    class Program
    {
        static void Main(string[] args)
        {
            //비트연산자
            //int x = 5; // 0101
            //int y = 3; // 0011 

            //Console.WriteLine(x & y); //AND : 1 (0001)
            //Console.WriteLine(x | y); //OR : 7 (0111)
            //Console.WriteLine(x ^ y); //XOR :6   (0110)
            //Console.WriteLine(~x);    //NOT : -6 

            //int value = 4;  //0100

            //Console.WriteLine(value << 1); //왼쪽이동 : 8 (1000)
            //Console.WriteLine(value >> 1); //오른쪽이동: 2 (0010)

            //int a = 10, b = 20;

            //int max;

            //max = (a < b) ? a : b; //삼항 연산자

            //Console.WriteLine(max);

            //int key = 1;

            //string str;
            //str = (key == 2) ? "문이열렸습니다." : "문을 못열었습니다.";

            //Console.WriteLine(str);

            //int result = 10 + 2 * 5; //곱셈이 덧셈보다 우선
            //Console.WriteLine(result);

            //int adjustedResult = (10 + 2) * 5; //괄호 우선순위 먼저계산

            //Console.WriteLine(adjustedResult);

            //int score = 85;

            //if (score >= 90)
            //{
            //    Console.WriteLine("A 학점");
            //}
            //else
            //{
            //    Console.WriteLine("B 학점");
            //}

            //string GameID = "멋사검존";


            //if (GameID == "멋사검존")
            //{
            //    Console.WriteLine("아이디가 일치합니다.");
            //}
            //else
            //{
            //    Console.WriteLine("아이디가 일치하지 않습니다.");
            //}

            //int score = 60;

            //if (score >= 90)
            //{
            //    Console.WriteLine("A 학점");
            //}
            //else if (score >= 80)
            //{
            //    Console.WriteLine("B 학점");
            //}
            //else if (score >= 70)
            //{
            //    Console.WriteLine("C 학점");
            //}
            //else
            //{
            //    Console.WriteLine("F 학점");
            //}



            //1단계
            //가지고있는 소지금을 입력하세요 :  
            //0~100  무한의대검 +1
            //101~200 카타나 +2
            //201~300 진은검 +3
            //301~400 집판검 +4
            //401~500 엑스칼리버 +5
            //501~600 유령검 +6
            //601~ 전설의검 +7

            //2단계
            //캐릭터 이름
            //공격력 : 100 + 1 

            Console.WriteLine("가지고있는 소지금을 입력하세요: ");
            int money = int.Parse(Console.ReadLine());
            Console.WriteLine("캐릭터의 이름을 입력하세요: ");
            string name = Console.ReadLine();
            int power = 100;
            string weapon = "";
            if(money >= 0 && money <= 100)
            {
                power = power + 1;
                weapon = "무한의대검";
            } else if(money > 100 && money <= 200)
            {
                power = power + 2;
                weapon = "카타나";
            }
            else if (money > 200 && money <= 300)
            {
                power = power + 3;
                weapon = "진은검";
            }
            else if (money > 300 && money <= 400)
            {
                power = power + 4;
                weapon = "집판검";
            }
            else if (money > 400 && money <= 500)
            {
                power = power + 5;
                weapon = "엑스칼리버";
            }
            else if (money > 500 && money <= 600)
            {
                power = power + 6;
                weapon = "유령검";
            }
            else if (money < 0)
            {
                Console.WriteLine("돈이 없어...");
            }
            else
            {
                power = power + 7;
                weapon = "전설의검";
            }
            Console.WriteLine($"{weapon}을 획득한 {name}의 공격력은...");
            Console.WriteLine($"무려 {power}점에 다다랐다!");


        }
    }
}
