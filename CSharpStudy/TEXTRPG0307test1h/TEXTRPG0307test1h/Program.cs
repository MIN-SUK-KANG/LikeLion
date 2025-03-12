using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TEXTRPG0307test1h
{
    public class Job
    {
        protected string name;
        protected int hp;
        protected int atk;

        public int Attack()
        {
            return atk;
        }
        public void Damaged(int enemyAtk)
        {
            hp -= enemyAtk;
        }
        public virtual void Explain()
        {
            Console.WriteLine($"직업 이름 : {name}");
            Console.WriteLine($"체력 : {hp}    공격력 : {atk}");
        }
        public virtual void ResetHP() { }
        public bool isDead()
        {
            if (hp <= 0) return true;
            else return false;
        }
    }

    public class Knight : Job
    {
        public Knight()
        {
            this.name = "기사";
            this.hp = 100;
            this.atk = 10;
        }
        public override void ResetHP()
        {
            if (this.hp <= 0) this.hp = 100;
        }
    }
    public class Mage : Job
    {
        public Mage()
        {
            this.name = "마법사";
            this.hp = 50;
            this.atk = 20;
        }
        public override void ResetHP()
        {
            if (this.hp <= 0) this.hp = 50;
        }
    }
    public class Thief : Job
    {
        public Thief()
        {
            this.name = "도둑";
            this.hp = 70;
            this.atk = 15;
        }
        public override void ResetHP()
        {
            if (this.hp <= 0) this.hp = 70;
        }
    }

    public class Monster : Job
    {
        public int levelcheck;
        public Monster(int level)
        {
            levelcheck = level;
            switch(level)
            {
                case 1:
                    this.name = "초보몹";
                    this.hp = 30;
                    this.atk = 3;
                    break;
                case 2:
                    this.name = "중수몹";
                    this.hp = 60;
                    this.atk = 6;
                    break;
                case 3:
                    this.name = "고수몹";
                    this.hp = 90;
                    this.atk = 9;
                    break;
            }
        }
        public override void ResetHP()
        {
            switch (levelcheck)
            {
                case 1:
                    hp = 30;
                    break;
                case 2:
                    hp = 60;
                    break;
                case 3:
                    hp = 90;
                    break;
            }
        }
        public override void Explain()
        {
            Console.WriteLine($"몬스터 이름 : {name}");
            Console.WriteLine($"체력 : {hp}    공격력 : {atk}");
        }
    }

    public class UIDesign
    {
        public int mapNum = 0;        //0 메인화면, 1 사냥터 선택, 2 전투 진입
        public int hardNum = 0;
        public Job player;

        public List<Monster> enemy = new List<Monster>() { new Monster(1) , new Monster(2) , new Monster(3) };

        

        public  UIDesign(Job given)
        {
            player = given;
        }
        public void ShowMap()
        {
            Console.Clear();
            Console.WriteLine("==================================");
            player.Explain();

            switch (mapNum)
            {
                case 0:
                    Console.Write("1.사냥터 2.종료 : ");
                    break;
                case 1:
                    Console.WriteLine("1. 초보맵");
                    Console.WriteLine("2. 중수맵");
                    Console.WriteLine("3. 고수맵");
                    Console.WriteLine("4. 전단계");
                    Console.WriteLine("=================");
                    Console.Write("맵을 선택하세요 : ");
                    break;
                case 2:
                    Console.WriteLine("==================================");
                    enemy[hardNum].Explain();
                    Console.Write("1.공격 2.도망 : ");
                    break;
            }

            int.TryParse(Console.ReadLine(), out int inputt);
            switch (mapNum)
            {
                case 0:
                    if (inputt == 1)
                    {
                        mapNum += 1;
                    }
                    else if (inputt == 2)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("올바른 값을 입력해주세요.");
                    }
                    break;
                case 1:
                    if (inputt == 1)
                    {
                        mapNum += 1;
                        hardNum = 0;
                    }
                    else if (inputt == 2)
                    {
                        mapNum += 1;
                        hardNum = 1;
                    }
                    else if (inputt == 3)
                    {
                        mapNum += 1;
                        hardNum = 2;
                    }
                    else if (inputt == 4)
                    {
                        mapNum -= 1;
                    }
                    else
                    {
                        Console.WriteLine("올바른 값을 입력해주세요.");
                    }
                    break;
                case 2:
                    if (inputt == 1)
                    {
                        player.Damaged(enemy[hardNum].Attack());
                        enemy[hardNum].Damaged(player.Attack());
                        if ( player.isDead() )
                        {
                            mapNum -= 1;
                            player.ResetHP();
                        }
                        if (enemy[hardNum].isDead())
                        {
                            mapNum -= 1;
                        }
                    }
                    else if (inputt == 2)
                    {
                        mapNum -= 1;
                        enemy[hardNum].ResetHP();
                        hardNum = 0;
                    }
                    else
                    {
                        Console.WriteLine("올바른 값을 입력해주세요.");
                    }
                    break;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("직업을 선택하세요(1.기사 2.마법사 3.도둑) : ");

            Job newcomer = new Job();

            int.TryParse(Console.ReadLine(), out int number);

            switch (number)
            {
                case 1:
                    newcomer = new Knight();
                    break;
                case 2:
                    newcomer = new Mage();
                    break;
                case 3:
                    newcomer = new Thief();
                    break;
                default:
                    Console.WriteLine("올바른 값을 입력해주세요.");
                    break;
            }
            UIDesign theGame = new UIDesign(newcomer);
            while(true)
            {
                theGame.ShowMap();
            }
        }
    }
}
