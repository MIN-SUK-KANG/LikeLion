using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion3
{
    class Program
    {
        static void Main(string[] args)
        {
            //캐릭터 
            //hp : 100
            //att : 56.7
            //캐릭터이름 : ??
            //등급 : S

            int hp = 100;
            double att = 56.7;
            string name = "??";
            char grade = 'S';

            Console.WriteLine("캐릭터");
            Console.WriteLine("hp : " + hp);
            Console.WriteLine("att : " + att);
            Console.WriteLine("캐릭터이름 : " + name);
            Console.WriteLine("등급 : " + grade);
        }
    }
}
