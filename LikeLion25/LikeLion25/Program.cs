using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion25
{

    //제네릭 사용하기(Generics)
    //<T> 제네릭 클래스를 사용하면 특정 타입에 종속되지 않는 범용 클래스를 만들수있습니다.
    //class Cup<T>
    //{
    //    public T Content { get; set; }
    //}

    //IEnumerator를 사용하는 이유
    //✔ 컬렉션을 직접 제어하며 순회할 수 있음
    //✔ foreach 없이도 컬렉션 순회 가능
    //✔ LINQ나 커스텀 컬렉션을 만들 때 유용함


    //public interface IEnumerator
    //{
    //    bool MoveNext(); // 다음 요소로 이동 (이동할 요소가 있으면 true 반환)
    //    object Current { get; } // 현재 요소 반환
    //    void Reset(); // 처음 위치로 리셋
    //}


    class SimpleCollection : IEnumerable<int>
    {
        private int[] data = { 1, 2, 3, 4, 5 };

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Cup<string> cupOfString = new Cup<string> { Content = "Coffee" };
            //Cup<int> cupOfInt = new Cup<int> { Content = 42 };

            //Console.WriteLine($"CupOfString: {cupOfString.Content}");
            //Console.WriteLine($"cupOfInt: {cupOfInt.Content}");




            //Stack<int> stack = new Stack<int>();

            //stack.Push(10);
            //stack.Push(20);
            //stack.Push(30);

            //while (stack.Count > 0)
            //{
            //    Console.WriteLine(stack.Pop());
            //}



            //List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
            //names.Add("Dave");


            //foreach (var name in names)
            //{
            //    Console.WriteLine(name);
            //}


            //ArrayList list = new ArrayList { "Apple", "Banana", "Cherry" };

            //IEnumerator enumerator = list.GetEnumerator(); //열거자 가져오기


            //while (enumerator.MoveNext()) //다음 요소가 있는지 확인
            //{
            //    Console.WriteLine(enumerator.Current);//현재 요소 출력
            //}



            //var collection = new SimpleCollection();

            //foreach (var i in collection)
            //{
            //    Console.WriteLine(i);
            //}





            //Dictionary<string, int> ages = new Dictionary<string, int>();

            //ages["금도끼"] = 10;
            //ages["은도끼"] = 5;
            //ages["돌도끼"] = 1;

            //foreach (var pair in ages)
            //{
            //    Console.WriteLine($"{pair.Key} : {pair.Value}");
            //}




            //int? nullableInt = null;
            //Console.WriteLine(nullableInt.HasValue ? nullableInt.Value.ToString() : "No value");  //3항연산자. (a?b:c) 형태로 써서, a가 true라면 b, false라면 c.

            //nullableInt = 10;
            //Console.WriteLine(nullableInt.HasValue ? nullableInt.Value.ToString() : "No value");




            //?? 연산자와 ? 연산자를 통해 null값에 안전한 접근이 가능.
            //?? 연산자를 사용해 null인 경우 대체값을 제공하고, ?.는 null안전 접근을 합니다.

            //?? 연산자는 (a ?? b) 형태로 쓰이는데, 3항연산자에서 a가 null이 아닐 경우, 즉 '값이 존재한다'가 true일 경우 자기 자신을 반환하는 경우로도 볼 수 있다. 즉 a와 b가 동일한 3항연산자.
            // ( (a != null) ? a : b ) 혹은 ( a = (a==null) ? b : a )


            //str?.Length; 코드를 풀어쓰면 아래 코드와 동일하다.

            //if (str != null)
            //{
            //    str.Length;
            //}

            //string str = null;
            //Console.WriteLine(str ?? "DefaultValue");   //str이 null일 경우 "DefaultValue"

            //str = "Hello";

            //Console.WriteLine(str?.Length);     //str이 null이 아닐 경우 메소드 실행, str 내부 문자열 길이 출력





            //LINQ는 확장메서드 형태로 제공된다. 
            //LINQ(Language Integrated Query)를 사용해 컬렉션을 쿼리할 수있습니다.
            int[] numbers = { 1, 2, 3, 4, 5 };

            var evenNumbers = numbers.Where(n => n % 2 == 0);       //람다식으로 한줄에 쓴거

            foreach (var num in evenNumbers)
            {
                Console.WriteLine(num);
            }



        }
    }
}
