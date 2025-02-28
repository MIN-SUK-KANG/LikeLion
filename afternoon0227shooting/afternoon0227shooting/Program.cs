using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace afternoon0227shooting
{

    struct Plane
    {
        string body;
        string wing;
        int x;
        int y;

        public Plane(string nwing, string nbody, int Xpos, int Ypos)
        {
            wing = nwing;
            body = nbody;
            x = Xpos;
            y = Ypos;

        }

        public void printPlane()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(wing);
            Console.SetCursorPosition(x, y+1);
            Console.WriteLine(body);
            Console.SetCursorPosition(x, y+2);
            Console.WriteLine(wing);
        }
        public void moveUp() => y--;
        public void moveDown() => y++;
        public void moveLeft() => x--;
        public void moveRight() => x++;

        public int xPos()
        {
            return x;
        }
        public int yPos()
        {
            return y;
        }
    }

    class Program
    {

        static Plane MakeMove(ConsoleKeyInfo keyInfo, Plane hero)
        {
            //방향키 입력에 따른 좌표 변경
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow: if (hero.yPos() > 0) hero.moveUp(); break;
                case ConsoleKey.DownArrow: if (hero.yPos() < Console.WindowHeight - 1) hero.moveDown(); break;
                case ConsoleKey.LeftArrow: if (hero.xPos() > 0) hero.moveLeft(); break;
                case ConsoleKey.RightArrow: if (hero.xPos() < Console.WindowWidth - 1) hero.moveRight(); break;
            }
            return hero;
        }
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25); // 콘솔 창 크기 설정 (가로 80, 세로 25)
            Console.SetBufferSize(80, 25); // 버퍼 크기도 동일하게 설정 (스크롤 방지)


            ConsoleKeyInfo keyInfo;

            Console.CursorVisible = false;


            //시간 1초루프
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            long prevSecond = stopwatch.ElapsedMilliseconds; // 1 /1000    1000일때 1초

            Console.Write("날개 모양을 짧은 문자열로 그려주세요:");
            string wing = Console.ReadLine();
            Console.Write("몸통 모양을 짧은 문자열로 그려주세요:");
            string body = Console.ReadLine();

            Plane player = new Plane(wing, body, 0, 12);

            while (true)
            {
                long currentSecond = stopwatch.ElapsedMilliseconds; //현재시간 가져오기

                if (currentSecond - prevSecond >= 100)
                {
                    // Console.WriteLine("1초루프");
                    Console.Clear();

                    player.printPlane();

                    keyInfo = Console.ReadKey(true); //키 입력 받기 (화면 출력 X)

                    //방향키 입력에 따른 좌표 변경
                    player = MakeMove(keyInfo, player);

                    prevSecond = currentSecond;//이전 시간 업데이트
                }


            }


        }
    }
}
