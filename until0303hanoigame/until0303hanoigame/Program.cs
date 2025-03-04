using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace until0303hanoigame
{
    public class Tower
    {
        [DllImport("msvcrt.dll")]
        static extern int _getch();

        private int height;

        private int position = 1;

        private Queue<int> qTower1 = new Queue<int>();
        private Queue<int> qTower2 = new Queue<int>();
        private Queue<int> qTower3 = new Queue<int>();

        private int temp = 0;

        private int count = 0;
        private int minCount;


        public Tower(int size)  //생성자
        {
            this.Height = size;
        }


        public int Height
        {
            get { return height; }
            set
            {
                if (value <= 6)
                {
                    height = value;
                    Console.WriteLine($"입력대로 {value}층짜리 하노이탑 게임을 시작합니다.");
                }
                else
                {
                    height = 6;
                    Console.WriteLine("최고 6층까지만 가능합니다. 자동으로 6층으로 진행합니다.");
                    Thread.Sleep(1000);
                }

                for (int i = 1; i <= height; i++)
                {
                    qTower1.Enqueue(i);
                }

                this.minCount = (int)(Math.Pow(2.0, (double)height) - 1);
            }
        }

        public void Take()
        {
            if (temp != 0)
            {
                Console.SetCursorPosition(0, 15);
                Console.Write("\n이미 원판을 들고 있습니다.");
                Thread.Sleep(1000);
            }
            else
            {
                if (position == 1 && qTower1.Count != 0)
                {
                    temp = qTower1.Dequeue();
                }
                else if (position == 2 && qTower2.Count != 0)
                {
                    temp = qTower2.Dequeue();
                }
                else if (position == 3 && qTower3.Count != 0)
                {
                    temp = qTower3.Dequeue();
                }
                else
                {
                    Console.SetCursorPosition(0, 15);
                    Console.Write("\n해당 위치에 원판이 없습니다.");
                    Thread.Sleep(1000);
                }
            }

        }   //Take() 종료

        public void PutDisk()
        {
            if (temp == 0)
            {
                Console.SetCursorPosition(0, 15);
                Console.Write("\n들고 있는 원판이 없습니다.");
                Thread.Sleep(1000);
            }
            else
            {
                if ( position == 1 && (qTower1.Count == 0 || qTower1.Peek() > temp))
                {
                    Queue<int> rev = new Queue<int>(qTower1.Reverse());
                    rev.Enqueue(temp);
                    qTower1 = new Queue<int>(rev.Reverse());
                    temp = 0;
                    count++;
                }
                else if ( position == 2 && (qTower2.Count == 0 || qTower2.Peek() > temp) )
                {
                    Queue<int> rev = new Queue<int>(qTower2.Reverse());
                    rev.Enqueue(temp);
                    qTower2 = new Queue<int>(rev.Reverse());
                    temp = 0;
                    count++;
                }
                else if ( position == 3 && (qTower3.Count == 0 || qTower3.Peek() > temp) )
                {
                    Queue<int> rev = new Queue<int>(qTower3.Reverse());
                    rev.Enqueue(temp);
                    qTower3 = new Queue<int>(rev.Reverse());
                    temp = 0;
                    count++;
                }
                else
                {
                    Console.SetCursorPosition(0, 15);
                    Console.Write("\n올바른 위치가 아닙니다.");
                    Thread.Sleep(1000);
                }
            }
        }   //PutDisk() 종료

        public void KeyControl()
        {
            int pressKey;   //정수형 변수선언 키값을 받기 위한 위치 

            if (Console.KeyAvailable)   //키가 눌렸을때 true
            {
                pressKey = _getch();    //입력된 키를 아스키 수치로

                switch (pressKey)
                {
                    case 87:        //대문자 W, 위
                        this.Take();
                        break;
                    case 119:       //소문자 w, 위
                        this.Take();
                        break;

                    case 65:        //대문자 A, 왼쪽
                        if (position > 1) position--;
                        else position = 1;
                        break;
                    case 97:        //소문자 a, 왼쪽
                        if (position > 1) position--;
                        else position = 1;
                        break;

                    case 83:        //대문자 S. 아래
                        this.PutDisk();
                        break;
                    case 115:       //소문자 s, 아래
                        this.PutDisk();
                        break;

                    case 68:        //대문자 D, 오른쪽
                        if (position < 3) position++;
                        else position = 3;
                        break;
                    case 100:       //소문자 d, 오른쪽
                        if (position < 3) position++;
                        else position = 3;
                        break;
                }
            }

        }   //KeyControl() 종료

        public void UIdraw()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(0, 1);
            Console.Write("┃                       ┃");
            Console.SetCursorPosition(3, 1);
            Console.Write("원판 이동 횟수 : " + count);
            Console.SetCursorPosition(0, 2);
            Console.Write("┗━━━━━━━━━━━━━━━━━━━━━━━┛");
        }

        public void TowerDraw1()
        {
            Queue<int> copy = new Queue<int>(qTower1);
            int a = copy.Count;

            while (a > 0)
            {
                string line = "";
                if (copy.Count == 0)
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(3, (13 - copy.Count));
                    int spacing = copy.Dequeue();

                    for (int i = 0; i < (6 - spacing); i++)
                    {
                        line += " ";
                    }
                    for (int i = 0; i < spacing; i++)
                    {
                        line += "--";
                    }
                    for (int i = 0; i < (6 - spacing); i++)
                    {
                        line += " ";
                    }
                    Console.WriteLine(line);
                }
            }

        }
        public void TowerDraw2()
        {
            Queue<int> copy = new Queue<int>(qTower2);
            int a = copy.Count;

            while (a > 0)
            {
                string line = "";
                if (copy.Count == 0)
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(23, (13 - copy.Count));
                    int spacing = copy.Dequeue();

                    for (int i = 0; i < (6 - spacing); i++)
                    {
                        line += " ";
                    }
                    for (int i = 0; i < spacing; i++)
                    {
                        line += "--";
                    }
                    for (int i = 0; i < (6 - spacing); i++)
                    {
                        line += " ";
                    }
                    Console.WriteLine(line);
                }
            }

        }
        public void TowerDraw3()
        {
            Queue<int> copy = new Queue<int>(qTower3);
            int a = copy.Count;

            while (a > 0)
            {
                string line = "";
                if (copy.Count == 0)
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(43, (13 - copy.Count));
                    int spacing = copy.Dequeue();

                    for (int i = 0; i < (6 - spacing); i++)
                    {
                        line += " ";
                    }
                    for (int i = 0; i < spacing; i++)
                    {
                        line += "--";
                    }
                    for (int i = 0; i < (6 - spacing); i++)
                    {
                        line += " ";
                    }
                    Console.WriteLine(line);
                }
            }
        }

        public void TableDraw()
        {
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("        ||                  ||                  ||");
            Console.WriteLine("        ||                  ||                  ||");
            Console.WriteLine("        ||                  ||                  ||");
            Console.WriteLine("        ||                  ||                  ||");
            Console.WriteLine("        ||                  ||                  ||");
            Console.WriteLine("        ||                  ||                  ||");
            Console.WriteLine("        ||                  ||                  ||");
            Console.WriteLine("        ||                  ||                  ||");
            Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

        }

        public void TakeDraw()
        {
            int xPos = 0;
            if (position == 1)
            {
                xPos = 3;
            }
            if (position == 2)
            {
                xPos = 23;
            }
            else if (position == 3)
            {
                xPos = 43;
            }
            
            Console.SetCursorPosition(xPos, 4);
            string line = "";

            if (temp != 0)
            {
                for (int i = 0; i < (6 - temp); i++)
                {
                    line += " ";
                }
                for (int i = 0; i < temp; i++)
                {
                    line += "--";
                }
                for (int i = 0; i < (6 - temp); i++)
                {
                    line += " ";
                }
            }
            else
            {
                line += "     ↓      ";
            }
            
            Console.WriteLine(line);
        }

        public void GameMain()
        {
            //배경 그리기
            UIdraw();
            TableDraw();
            TakeDraw();

            //탑 그리기
            TowerDraw1();
            TowerDraw2();
            TowerDraw3();

            //키 입력 받기
            KeyControl();

            Console.SetCursorPosition(0, 15);
            Console.WriteLine("WASD로 플레이 해주세요");

            if (qTower3.Count == height)
            {
                Console.SetCursorPosition(0, 15);
                Console.WriteLine($"게임 클리어! {count}번의 움직임으로 {height}층 하노이 탑을 깼습니다.");
                Console.WriteLine($"{height}층 하노이 탑은 {minCount}번의 움직임으로 깰 수 있습니다. 당신은 최소 횟수에 성공했나요?\n\n\n");
                Environment.Exit(0);
            }
        }
        //Tower 클래스 종료
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Console.SetWindowSize(100, 25);
            Console.SetBufferSize(100, 25);

            int size = 0;
            while (size <= 0)
            {
                Console.Clear();
                Console.WriteLine("하노이 탑 옮기기\n\n이 게임은 WASD로 작동합니다\n\n1~6층까지의 탑을 플레이할 수 있습니다.");

                Console.Write("\n\n\n원하는 층수를 입력해주세요: ");
                int.TryParse(Console.ReadLine(), out size);
                if (size <= 0)
                {
                    Console.Write("\n'숫자'로 입력해주세요. 0이나 음수도 안됩니다.");
                    Thread.Sleep(1000);
                }
            }

            Tower game = new Tower(size);

            //시스템 시간 확인
            int dwTime = Environment.TickCount;     // 1ms 단위 체크

            while (true)
            {
                if (dwTime + 50 < Environment.TickCount)    //0.05초 지연시 내부 코드 실행
                {
                    dwTime = Environment.TickCount;     //현재시간 다시 세팅

                    Console.Clear();
                    game.GameMain();
                }
            }

        }
    }
}
