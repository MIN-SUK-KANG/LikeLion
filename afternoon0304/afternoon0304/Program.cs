using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace afternoon0304
{

    //class Profession
    //{
    //    public String Name { get; set; }
    //    public int Score { get; set; }
    //}
    //class Warrior : Profession
    //{
    //    public int Strength { get; set; }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            //Warrior hero = new Warrior();

            //hero.Name = "Nameless";
            //hero.Score = 127;
            //hero.Strength = 24;

            //Console.WriteLine($"{hero.Name}은(는) {hero.Score}레벨의 STR: {hero.Strength}를 보유한 캐릭터입니다.");





            //try
            //{
            //    Console.Write("정수를 입력해주세요: ");
            //    int input = int.Parse(Console.ReadLine());
            //    Console.WriteLine($"입력된 숫자: {input}");
            //}
            //catch (FormatException e)
            //{
            //    Console.WriteLine($"{e}는 정상적인 정수 입력이 아닙니다.");
            //    Console.WriteLine("올바른 숫자를 입력하세요!");
            //}



            //List<String> fruit = new List<String>() { "사과", "바나나", "포도" };

            //Queue<String> work = new Queue<String>();
            //work.Enqueue("첫 번째 작업");
            //work.Enqueue("두 번째 작업");
            //work.Enqueue("세 번째 작업");

            //Stack<int> numbers = new Stack<int>();
            //numbers.Push(10);
            //numbers.Push(20);
            //numbers.Push(30);

            //int size = numbers.Count;

            //for (int i = 0; i < size; i++)
            //{
            //    Console.WriteLine(numbers.Pop());
            //}






            //String inLine = (Console.ReadLine()).ToUpper().Replace("C#", "CSharp");

            //Console.WriteLine(inLine);
            //Console.WriteLine(inLine.Length);





            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var evenNum = numbers.Where(even => even % 2 == 0);

            foreach (var num in evenNum) Console.Write(num + " ");

            int sumNum = numbers.Sum();

            Console.WriteLine("\n\n" + sumNum);



        }
    }
}
