using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace afternoon0305
{
    class SwordMan
    {
        public string name;
        public int winRound;

        protected int winCount = 0;
        protected int loseCount = 0;

        protected int power;
        protected int speed;
        protected int accuracy;

        protected static Random rand = new Random();

        public virtual void Status()
        {
            Console.WriteLine($"{name}:\t근력[{power,2}]\t속도[{speed,2}]\t기술[{accuracy,2}]");
        }

        public virtual void Attack(SwordMan enemy)
        {
            if ( (this.Bash() > enemy.Jump()) || (this.Bash() > enemy.Break()) )
            {
                Console.WriteLine($"{name}의 검은 {enemy.name}의 방어를 뚫고 명중했다!");
                winRound++;
            }
            else winRound--;
        }
        public virtual void Dodge(SwordMan enemy)
        {
            if ( (this.Jump() > enemy.Bash()) || (this.Jump() > enemy.Break()) )
            {
                Console.WriteLine($"{name}은(는) {enemy.name}의 검을 피해냈다!");
                winRound++;
            }
            else winRound--;
        }
        public virtual void Parry(SwordMan enemy)
        {
            if ( (this.Break() > enemy.Bash()) || (this.Break() > enemy.Jump()) )
            {
                Console.WriteLine($"{name}은(는) {enemy.name}의 공격을 예상해 반격에 성공했다!");
                winRound++;
            }
            else winRound--;
        }

        public int Bash() => power + accuracy;
        public int Jump() => power + speed;
        public int Break() => speed + accuracy;


        public bool RoundWin()
        {
            if (winRound > 0) return true; else return false;
        }
        public void NextRound() => winRound = 0;


        public int ResultGood() => winCount;
        public int ResultBad() => loseCount;
        public void ResultWrite() => Console.Write($"{name}: 모의전 {winCount}승 {loseCount}패");


        public void Battle(SwordMan a)
        {
            this.Attack(a);
            this.Dodge(a);
            this.Parry(a);

            if (this.RoundWin() == true)
            {
                winCount++;
                Console.WriteLine($"흠, {name}의 1승...");
            }
            else
            {
                loseCount++;
                Console.WriteLine($"흠, {name}의 1패...");
            }
            this.NextRound();
        }


        public int D3() => rand.Next(100, 999);
        public int D3x6() => rand.Next(1, 6) + rand.Next(1, 6) + rand.Next(1, 6);
        public int D5x6() => rand.Next(1, 6) + rand.Next(1, 6) + rand.Next(1, 6) + rand.Next(1, 6) + rand.Next(1, 6);
    }
    class Saber : SwordMan
    {
        public Saber()
        {
            name = "세이버" + base.D3();

            power = base.D3x6();
            speed = base.D5x6();
            accuracy = base.D3x6();
        }


    }
    class Twohander : SwordMan
    {
        public Twohander()
        {
            name = "투핸더" + base.D3();

            power = base.D5x6();
            speed = base.D3x6();
            accuracy = base.D3x6();
        }


    }
    class Buckler : SwordMan
    {
        public Buckler()
        {
            name = "버클러" + base.D3();

            power = base.D3x6();
            speed = base.D3x6();
            accuracy = base.D5x6();
        }


    }




    class Program
    {
        static void Main(string[] args)
        {
            List<SwordMan> freshers = new List<SwordMan>();
            freshers.Add(new Saber());
            freshers.Add(new Saber());
            freshers.Add(new Twohander());
            freshers.Add(new Twohander());
            freshers.Add(new Buckler());
            freshers.Add(new Buckler());

            Console.WriteLine("=============================================================================\n");
            Console.WriteLine("어느새 시간이 이렇게 되었군.\n신입 검투사들을 환영할 준비를 해야겠다.\n");
            Console.WriteLine("=============================================================================");

            for (int i = 0; i < freshers.Count(); i++)
            {
                Console.WriteLine($"{i+1}번째 신입은 {freshers[i].name}인가.");
                freshers[i].Status();
                Console.WriteLine("");
            }

            Console.WriteLine("\n\n역시 아직 잘 모르겠군.\n시범경기로 굴리며, 녀석들의 실력을 확인해보자.\n");
            Console.WriteLine("=============================================================================");

            for (int i = 0; i < freshers.Count(); i++)
            {
                for (int j = 0; j < freshers.Count(); j++)
                {
                    if (i != j)
                    {
                        freshers[i].Battle(freshers[j]);
                    }
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("=============================================================================");
            Console.WriteLine("결과가 나왔군.\n");

            var indexing = from arms in freshers
                           orderby arms.ResultGood() descending, arms.ResultBad() descending
                           select arms;

            int ranking = 1;
            foreach(var arms in indexing)
            {
                Console.Write($"{ranking}위 - ");
                ranking++;
                arms.ResultWrite();
                Console.Write("\n");
            }

            Console.WriteLine("\n\n이렇게 되었나. 하나하나 가르칠 맛이 있겠어.");
            Console.WriteLine("=============================================================================");
        }
    }
}
