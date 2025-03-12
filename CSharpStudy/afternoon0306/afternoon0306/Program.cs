using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace afternoon0306
{
    public class Character
    {
        static Random rand = new Random();

        protected string strName;

        protected int level = 1;
        protected int EXP = 0;
        protected int HP = 20;

        public virtual int Attack()
        {
            return rand.Next(1, 6);
        }
        public virtual int MagicAtk()
        {
            return 0;
        }
        public virtual void LevelUp()
        {
            while(EXP >= level && level <= 10)
            {
                EXP -= level;
                level++;
                Console.WriteLine($"레벨업! Lv.{level-1}에서 Lv.{level}로!");
            }
            if (level >= 10)
            {
                Console.WriteLine("최고 레벨에 도달했습니다.");
            }
        }
        public int getHP()
        {
            return HP;
        }
        public void Battle(Character enemy)
        {
            HP -= enemy.Attack();
            if (HP <= 0)
            {
                Console.WriteLine($"{strName}이 사망했습니다.");
            }
        }
    }
    public class Player : Character
    {
        private int JobName = 0;
        //직업선택

        private void SetData()
        {
            switch (JobName)
            {
                case 1:
                    strName = "기사";
                    HP = base.HP + level * 6;
                    break;
                case 2:
                    strName = "마법사";
                    HP = base.HP + level * 2;
                    break;
                case 3:
                    strName = "도둑";
                    HP = base.HP + level * 4;
                    break;
                default:
                    Console.WriteLine("올바른 값을 입력해주세요.");
                    break;
            }
        }
        public void SelectJob()
        {
            while (JobName != 1 && JobName != 2 && JobName != 3)
            {
                int.TryParse(Console.ReadLine(), out JobName);
                SetData();
            }
        }
        
        public override int Attack()
        {
            switch (JobName)
            {
                case 1:
                    return base.Attack() + base.Attack();
                case 3:
                    int crit = base.Attack();
                    if(crit == 6)
                    {
                        return 20;
                    }
                    else
                    {
                        return crit;
                    }
                default:
                    return base.Attack();
            }
        }
        public override int MagicAtk()
        {
            switch (JobName)
            {
                case 2:
                    return base.Attack() / 2 + level * 3;
                default:
                    return base.MagicAtk();
            }
        }
        public override void LevelUp()
        {
            base.LevelUp();
            SetData();
        }
    }
    public class Monster : Character
    {
        private int Difficulty = 0;
        //난이도
        public Monster()
        {
            SelectDifficult();
        }
        public void SelectDifficult()
        {
            int level = base.Attack() + base.Attack();
            if (level < 6)
            {
                Difficulty = 1;
                EXP = 3;
                SetData();
            }
            else if (level < 11)
            {
                Difficulty = 2;
                EXP = 5;
                SetData();
            }
            else
            {
                Difficulty = 3;
                EXP = 10;
                SetData();
            }
        }
        private void SetData()
        {
            switch (Difficulty)
            {
                case 1:
                    strName = "고블린";
                    HP = 6;
                    break;
                case 2:
                    strName = "스켈레톤";
                    HP = 10;
                    break;
                case 3:
                    strName = "오크";
                    HP = 20;
                    break;
            }
        }
        public override int Attack()
        {
            switch (Difficulty)
            {
                case 1:
                    return 2;
                case 2:
                    return 4;
                case 3:
                    return (base.Attack() / 2) + 2;
                default:
                    return 0;
            }
        }


    }


    class BattleField
    {

    }



    class Program
    {
        static void Main(string[] args)
        {
            //캐릭터 입력
            //필드 정리, 난이도 1~3, 1~3마리 등장



        }
    }
}
