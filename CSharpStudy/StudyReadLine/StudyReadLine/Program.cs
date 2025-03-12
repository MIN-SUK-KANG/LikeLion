using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyReadLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("루인 스킬 피해량은 얼마입니까? (%값 입력, 숫자만) : ");
            float maxDamage = float.Parse(Console.ReadLine());
            Console.Write("카드 게이지 획득량은 얼마입니까? (%값 입력, 숫자만) : ");
            float maxCard = float.Parse(Console.ReadLine());
            Console.Write("각성기 피해는 얼마입니까? (%값 입력, 숫자만) : ");
            float maxTrans = float.Parse(Console.ReadLine());
            Console.Write("현재 플레이어의 최대 마나는 얼마입니까? : ");
            int maxMP = int.Parse(Console.ReadLine());
            Console.Write("전투 중 마나 회복량은 얼마입니까? : ");
            int reMPbattle = int.Parse(Console.ReadLine());
            Console.Write("비전투 중 마나 회복량은 얼마입니까? : ");
            int reMPday = int.Parse(Console.ReadLine());
            Console.Write("이동속도는 얼마입니까? (%값 입력, 숫자만) : ");
            float moveSpd = float.Parse(Console.ReadLine());
            Console.Write("탈 것 속도는 얼마입니까? (%값 입력, 숫자만) : ");
            float rideSpd = float.Parse(Console.ReadLine());
            Console.Write("운반 속도는 얼마입니까? (%값 입력, 숫자만) : ");
            float takeSpd = float.Parse(Console.ReadLine());
            Console.Write("최종 스킬 재사용 대기 시간 감소 효과는 얼마입니까? (%값 입력, 숫자만) : ");
            float coolDown = float.Parse(Console.ReadLine());

            Console.WriteLine("\n\n==활동=======================▼==");
            Console.WriteLine($"루인 스킬 피해               {maxDamage}%");
            Console.WriteLine($"카드 게이지 획득량           {maxCard}%");
            Console.WriteLine($"각성기 피해                  {maxTrans}%");
            Console.WriteLine($"최대 마나                    {maxMP}");
            Console.WriteLine($"전투 중 마나 회복량           {reMPbattle}");
            Console.WriteLine($"비전투 중 마나 회복량         {reMPday}");
            Console.WriteLine($"이동 속도                  {moveSpd}%");
            Console.WriteLine($"탈 것 속도                 {rideSpd:F1}%");
            Console.WriteLine($"운반 속도                  {takeSpd:F1}%");
            Console.WriteLine($"스킬 재사용 대기 시간 감소   {coolDown}%");


        }
    }
}
