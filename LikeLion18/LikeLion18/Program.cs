using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion18
{
    //struct Rectangle
    //{
    //    public int Width;
    //    public int Height;

    //    public int GetArea() => Width * Height;
    //}
    //struct Point
    //{
    //    public int x;
    //    public int y;
    //}




    class Program
    {

        struct Student
        {
            public string Name;  //학생 이름
            public int iKor;     //국어
            public int iEng;     //영어
            public int iMath;    //수학

            //학생 정보를 출력하는 함수
            public void Print()
            {
                Console.WriteLine($"{Name}\t{iKor}\t{iEng}\t{iMath}");
            }
        }


        static void Main(string[] args)
        {
            //  var rect = new Rectangle { Width = 5, Height = 4 };

            //Rectangle rect;
            //rect.Width = 10;
            //rect.Height = 20;
            //Console.WriteLine($"Area : {rect.GetArea()}");


            //Point[] points = new Point[2];

            //points[0].x = 10;
            //points[0].y = 10;

            //points[1].x = 20;
            //points[1].y = 20;



            //foreach (var point in points)
            //{
            //    Console.WriteLine($"Point: ({point.x},{point.y})");
            //}



            //구조체를 이용해서
            //학생3명의 이름 성적을 받고 국어,영어,수학
            //출력하시오.
            //이름    국어    영어    수학
            //홍길동   100     80      70
            //홍길란    90     10      20
            //홍길순    20     55      70

            //학생 배열 선언
            Student[] students = new Student[3];

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine("학생성적을 입력하세요.");
                Console.Write("학생이름 : ");
                students[i].Name = Console.ReadLine();
                Console.Write("국어 : ");
                students[i].iKor = int.Parse(Console.ReadLine());
                Console.Write("영어 : ");
                students[i].iEng = int.Parse(Console.ReadLine());
                Console.Write("수학 : ");
                students[i].iMath = int.Parse(Console.ReadLine());
            }


            Console.WriteLine("이름    국어    영어    수학");

            foreach (Student std in students)
            {
                std.Print();
            }

        }
    }
}
