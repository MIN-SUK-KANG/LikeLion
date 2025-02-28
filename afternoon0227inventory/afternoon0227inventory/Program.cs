using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace afternoon0227inventory
{
    struct Item
    {
        string ItemName;
        int ItemCount;

        public Item(string name, int number)
        {
            ItemName = name;
            ItemCount = number;
        }

        public void Add(int another)
        {
            Console.Write($"현재 {ItemCount}개 존재.");
            ItemCount += another;
            Console.Write($"{another}개를 추가해 {ItemCount}개가 됩니다.");
        }

        public void Remove(int take)
        {
            if(take > ItemCount)
            {
                Console.WriteLine($"해당 아이템은{ItemCount}개 뿐입니다.");
                Console.WriteLine($"{take}개를 사용할 수 없어 {ItemCount}개만 사용, 전부 소비합니다.");
                ItemCount = 0;
                ItemName = null;
            }
            else
            {
                Console.Write($"{ItemCount}개의 아이템을 사용합니다.");
                ItemCount -= take;
                Console.Write($"사용 후 {ItemCount}개가 남았습니다.\n");
            }
        }

        public string CallName()
        {
            return ItemName;
        }
        public int Count()
        {
            return ItemCount;
        }
    }

    class Program
    {

        //최대 아이템 개수(배열 크기)
        const int MAX_ITEMS = 10;

        //아이템 배열 (이름 저장)
        static Item[] inventory = new Item[MAX_ITEMS];

        //아이템 추가 함수
        static void AddItem(string name, int count)
        {
            for (int i = 0; i < inventory.Length; i++)  //이미 있는 아이템이면 개수 증가
            {
                if (inventory[i].CallName() == name)
                {
                    inventory[i].Add(count);
                    return;
                }
            }

            //빈 슬롯에 새로운 아이템 추가
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].CallName() == null)
                {
                    inventory[i] = new Item(name, count);
                    return;
                }
            }

            Console.WriteLine("인벤토리가 가득 찼습니다.");

        }


        //아이템 제거 함수
        static void RemoveItem(string name, int count)
        {
            for (int i = 0; i < MAX_ITEMS; i++)
            {
                if (inventory[i].CallName() == name) //이름하고 같은지
                {
                    inventory[i].Remove(count);
                    return;
                }
            }

            Console.WriteLine("아이템을 찾을 수 없습니다!");

        }


        //인벤토리 출력 함수
        static void ShowInventory(Item[] listing)
        {
            bool isEmpty = true;

            for (int i = 0; i < inventory.Length; i++)
            {
                if (listing[i].Count() != 0)
                {
                    Console.WriteLine($"{listing[i].CallName()} (x{listing[i].Count()})");
                    isEmpty = false;
                }
            }

            if (isEmpty)
            {
                Console.WriteLine("인벤토리가 비어 있습니다.");
            }
        }
        static void Main(string[] args)
        {
            //테스트 : 아이템 추가
            AddItem("포션", 5);
            AddItem("칼", 1);
            AddItem("포션", 3); //포션 개수 추가

            ShowInventory(inventory);

            //아이템 사용
            Console.WriteLine("포션 2개 사용");
            RemoveItem("포션", 2);
            ShowInventory(inventory);

            //테스트 : 없는 아이템 제거
            Console.WriteLine("방패 1개 제거 시도");
            RemoveItem("방패", 1);

            ShowInventory(inventory);

            //테스트: 모든 포션 제거
            Console.WriteLine("포션 8개 사용(초과 사용 테스트)");
            RemoveItem("포션", 8);
            ShowInventory(inventory);
        }
    }
}
