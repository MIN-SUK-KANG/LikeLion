using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace afternoon0225
{
    class Program
    {
        static void Main(string[] args)
        {
            //콘솔 창 크기 설정 
            Console.SetWindowSize(120, 30); //x 80 , y 25

            Random rand = new Random();

            int gold = 500;
            int current = 0;
            int highest = 0;
            int input;

            List<int> upgradePercent = new List<int>() { 100, 90, 75, 60, 40, 30, 20, 10, 5 };
            List<int> upgradePrice = new List<int>() { 10, 35, 50, 80, 100, 200, 450, 700, 1000 };
            List<int> itemPrice = new List<int>() { 10, 30, 60, 100, 170, 300, 500, 800, 1500, 2500, 5000 };


            bool haveItem = false;
            bool isAlive = true;

            Console.WriteLine("최강의 재료까지! 10단계에 도달하자!");
            Thread.Sleep(1000);

            while (isAlive)
            {
                if (current > highest)
                {
                    highest = current;
                }
                Console.Clear();
                Console.WriteLine($" 현재 상태: 골드 {gold} | 현재 등급 {current} | 최고 기록 {highest}");
                if (current == 10)
                {
                    Console.WriteLine("\n※※※최고 랭크에 도달했어요!!!※※※");
                    string testing = "＃ⓒㅠＥ %";

                    Console.WriteLine("\n아무 내용이나 입력하시면 게임이 종료됩니다...");
                    testing = Console.ReadLine();
                    if (testing != "＃ⓒㅠＥ %")
                    {
                        isAlive = false;
                    }
                }
                else
                {
                    if (haveItem == false)
                    {
                        Console.WriteLine("\n0. 새 재료 구매 (10)");
                        Console.WriteLine("1. 게임 종료");
                    }
                    if (haveItem == true)
                    {
                        Console.WriteLine("\n1. 강화하기");
                        Console.WriteLine("2. 판매하기");

                        Console.WriteLine("3. 게임 종료");

                        Console.WriteLine($"현재 강화 비용은 {upgradePrice[current - 1]}골드 입니다.");
                        Console.WriteLine($"현재 강화 성공 확률은 {upgradePercent[current - 1]}% 입니다.");
                        Console.WriteLine($"기본 판매 비용은 {itemPrice[current - 1]}골드 입니다.");

                    }
                }

                Console.Write("입력: ");
                string written = Console.ReadLine();
                bool success = int.TryParse(written, out input);    //written(입력값)이 int면 input에 입력, 성공여부를 success에 true/false로 입력.
                if (success == true)
                {
                    if (haveItem == false && input == 0)  //새 재료 구매
                    {
                        if (gold >= 10)
                        {
                            Console.Clear();
                            Console.WriteLine("새로운 재료를 구매합니다.");
                            Thread.Sleep(500);
                            Console.WriteLine("새로운 재료를 구매합니다..");
                            Thread.Sleep(500);
                            Console.WriteLine("새로운 재료를 구매합니다...");
                            Thread.Sleep(500);

                            int eventChance = rand.Next(1, 101); //1~100 랜덤 이벤트 발생

                            if (eventChance <= 20) //20%확률로 고급 재료
                            {
                                Console.WriteLine("와! 마법적 무기 재료가 남아있었습니다!");
                                haveItem = true;
                                gold -= 10;
                                current = 2;
                                Thread.Sleep(500);

                            }
                            else //80% 확률로 일반 재료
                            {
                                Console.WriteLine("일반적인 무기 재료를 획득했습니다.");
                                haveItem = true;
                                gold -= 10;
                                current = 1;
                                Thread.Sleep(500);
                            }
                        }
                        else
                        {
                            Console.WriteLine("파산하셨어요... 게임에서 쫓겨나실 시간입니다.");
                            isAlive = false;
                            Thread.Sleep(1000);
                        }
                    }
                    else if (haveItem == true && input == 1) //강화하기
                    {
                        if (upgradePrice[current - 1] > gold)
                        {
                            Console.WriteLine("돈이 모자라요...");
                            Thread.Sleep(500);
                        }
                        else
                        {
                            int upgradeChance = rand.Next(1, 101); //1~100 랜덤 이벤트 발생
                            Console.Clear();
                            Console.WriteLine("강화강화...");
                            Thread.Sleep(500);
                            Console.WriteLine("강화 시도중...");
                            Thread.Sleep(500); ;
                            Console.WriteLine("과연, 결과는...?");
                            Thread.Sleep(500);

                            gold -= upgradePrice[current - 1];

                            if (upgradeChance <= upgradePercent[current - 1])
                            {
                                Console.Clear();
                                Console.WriteLine("강화, 성공!");
                                current += 1;
                                Console.WriteLine($"{current}단계로 강화했습니다!");
                                Thread.Sleep(500);
                            }
                            else
                            {
                                haveItem = false;
                                current = 0;
                                Console.WriteLine("강화, 실패...");
                                Console.WriteLine("전부 날아갔어요...");
                                Thread.Sleep(500);
                            }
                        }
                    }
                    else if (haveItem == true && input == 2) //판매하기
                    {
                        int sellChance = rand.Next(1, 101); //1~100 랜덤 이벤트 발생

                        Console.Clear();
                        Console.WriteLine("판매중...");
                        Thread.Sleep(500);
                        Console.WriteLine("구매자 발견...!");
                        Thread.Sleep(500);
                        Console.WriteLine("흥정 진행...");

                        if (sellChance <= 10) //10%확률로 고급 재료
                        {
                            Console.WriteLine("와! 약 3할정도 더 비싸게 팔았어요!");
                            haveItem = false;
                            gold += (int)(itemPrice[current - 1] * 1.3);
                            current = 0;
                            Thread.Sleep(1000);
                        }
                        else if (sellChance <= 30) //20%확률로 고급 재료
                        {
                            Console.WriteLine("힝... 흥정왕에게 당해서 1할 싸게 팔아버렸어...!");
                            haveItem = false;
                            gold += (int)(itemPrice[current - 1] * 0.9);
                            current = 0;
                            Thread.Sleep(1000);
                        }
                        else //80% 확률로 일반 재료
                        {
                            Console.WriteLine("평범하게 일반가로 팔았네요.");
                            haveItem = false;
                            gold += itemPrice[current - 1];
                            current = 0;
                            Thread.Sleep(1000);
                        }
                    }
                    else if ((haveItem == false && input == 1) || (haveItem == true && input == 3)) //게임 종료
                    {
                        Console.WriteLine("게임을 종료합니다. 감사합니다!");
                        Thread.Sleep(1000);
                        isAlive = false;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 숫자입니다. 목록중에 선택하세요.");
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 제대로 숫자로 입력하세요.");
                    Thread.Sleep(1000);
                }
            }

        }
    }
}
