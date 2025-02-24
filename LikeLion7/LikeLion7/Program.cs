using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion7
{
    class Program
    {
        static void Main(string[] args)
        {
            //단항 연산자
            //int number = 5;
            //bool flag = true;


            //Console.WriteLine(+number); //양수 출력 : 5
            //Console.WriteLine(-number); //음수 출력 : -5

            //Console.WriteLine(!flag);  //논리 부정 : false

            //int num = 10;
            //int result = ~num;   //모든 비트 반전 : 1111 0101 결과


            //Console.WriteLine("원래 값 : " + num);
            //Console.WriteLine("~ 연산자 적용 후: " + result);

            //int iKor = 90;
            //int iEng = 75;
            //int iMath = 58;

            //int sum = 0;
            //float average = 0.0f;

            //sum = iKor + iEng + iMath;

            //average = (float)sum / 3;  //평균

            //Console.WriteLine("총점 : " + sum);
            //Console.WriteLine("평균 : " + average);

            //int a = 10, b = 3;

            //Console.WriteLine(a + b);
            //Console.WriteLine(a - b);
            //Console.WriteLine(a * b);
            //Console.WriteLine(a / b);
            //Console.WriteLine(a % b);

            //string firstName = "Alice";
            //string lastName = "Smith";

            //Console.WriteLine(firstName + " " + lastName); //출력

            //int a = 10;
            //a += 5;  // a  = a + 5;
            //Console.WriteLine(a);
            //a -= 5;  // a  = a - 5;
            //Console.WriteLine(a);
            //a *= 5;  // a  = a * 5;
            //Console.WriteLine(a);
            //a /= 5;  // a  = a / 5;
            //Console.WriteLine(a);
            //a %= 5;  // a  = a % 5;
            //Console.WriteLine(a);


            //-----소수점 포맷 출력 예시
            //double value = 1234.56;
            //Console.WriteLine(value.ToString("F2")); // 출력: "1234.56"


            //문제 1.학점 평균 계산 프로그램
            //설명:
            //국어, 영어, 수학 점수를 사용자로부터 입력받아 총점과 평균을 구하는 프로그램을 작성하세요.
            //요구사항:

            //각 과목의 점수는 정수형으로 입력받습니다.
            //총점을 구한 후, 평균을 계산할 때 정수형 총점을 실수형으로 캐스팅하여 소수점까지 정확하게 계산합니다.
            //평균은 소수점 둘째 자리까지 출력하세요.

            Console.Write("국어 점수를 입력: ");
            int krtest = int.Parse(Console.ReadLine());
            Console.Write("영어 점수를 입력: ");
            int entest = int.Parse(Console.ReadLine());
            Console.Write("수학 점수를 입력: ");
            int mathtest = int.Parse(Console.ReadLine());


            int total = krtest + entest + mathtest;
            double average = (double)total / 3;

            Console.Write($"총점: {total}");
            Console.Write($"평균: {average.ToString("F2")}");


            //문제 2.비트 반전(~) 연산자 활용 프로그램
            //설명:
            //사용자로부터 정수를 입력받아, 해당 정수의 모든 비트를 반전(~)한 결과를 출력하는 프로그램을 작성하세요.
            //요구사항:

            //정수를 입력받습니다.
            //비트 반전 연산자(~)를 이용하여 입력된 정수의 비트를 반전합니다.
            //원래의 값과 비트 반전 후의 값을 함께 출력합니다.

            Console.Write("\n\n\n정수를 입력: ");
            int given = int.Parse(Console.ReadLine());
            int flipped = ~given;

            Console.Write($"원래 값: {given}");
            Console.Write($"비트 반전 값: {flipped}");



            //int b = 3;

            //전위 ++b , 후위 b++
            //Console.WriteLine("b의 값은 : " + (b++));

            //전위연산은 '연산 이후 해당 라인 처리', 후위 연산은 '해당 라인 처리 이후 연산'
            //즉 Console.WriteLine 내부에 ++b를 넣을 경우 'b를 ++ 연산한 이후 출력'이 되고, b++를 넣을 경우 '출력 이후 b를 ++ 연산'이 된다.


            //int x = 5, y = 10;

            //Console.WriteLine(x == y);  // false
            //Console.WriteLine(x != y);  // true
            //Console.WriteLine(x < y);   // true
            //Console.WriteLine(x > y);   // false
            //Console.WriteLine(x >= y);  // false
            //Console.WriteLine(x <= y);  //true  

            //bool a = false;
            //bool b = false;
            //Not
            //!a

            //b = !a;

            //Console.WriteLine(b); //true 
        }
    }
}
