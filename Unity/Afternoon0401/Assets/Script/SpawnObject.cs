using UnityEngine;

// Design Pattern [3] Factory.
// 팩토리 패턴. 조건이 충족될 시 새로운 오브젝트를 생성하는 스크립트, 혹은 오브젝트.
// 적 몬스터나 아이템, 효과 부여 및 제거 등의 처리를 별개의 클래스로 분리해 독립시키는것이 목적이다.
// 생성 좌표나 개수를 랜덤으로 처리해도 플레이어 연산이 필요 없는 형태라는게 하나의 패턴으로 명명된 가장 큰 이유.
// 실제로 서버와 클라이언트(이용자)를 분리하는 온라인 게임 등에서 클라이언트가 적 생성에 절대 직접 관여할 수 없도록 독립시키는 의도가 강하다.

// 소환수가 또다시 소환수를 만드는 식의 적 로직을 만들 경우, 재귀함수를 통해 일정 단계의 소환수는 소환할 수 없다는 식으로 처리해도 되겠으나
// 팩토리 패턴 내부에서 '특정 조건에 걸리는 소환수는 생성시 팩토리 패턴 스크립트를 보유하도록 설계하는' 방법도 가능.
// 물론 둘 다 결과적으로는 같은 처리가 되므로 개인 취향이나 체감 난이도 문제긴 하다.

// 공통되는 효과들을 전부 관리하며, 기존 C# 수업때 배운 오버라이드 개념과도 어느정도 연동되어 있다.
// enum이나 Interface 등을 이용해 데이터의 구성요소와 생성된 오브젝트의 행위를 다시 한 번 분리하는 형태도 가능.
// 수업 중 묘사된 예시가 이쪽이나, 본 코드에서는 단순히 Player와 Observer에게서 데이터를 받아와 일정 개수만 소환하는 식으로 작성했다.

public class SpawnObject : MonoBehaviour
{
    // 소환될 수 있는 오브젝트 종류들을 저장해두는 배열. 유니티 인스펙터에서 입력한다.
    [SerializeField] private GameObject[] shapes;

    private GameObject[] spawnObject = new GameObject[4] { null, null, null, null };
    private Vector3[] spawnPos = new Vector3[4];
    private int[] level = { 0, 0, 0, 0 };
    private bool[] done = { false, false, false, false };

    private void Start()
    {
        spawnPos[0] = new Vector3(2f, 2f, 2f);
        spawnPos[1] = new Vector3(-2f, 2f, 2f);
        spawnPos[2] = new Vector3(2f, 2f, -2f);
        spawnPos[3] = new Vector3(-2f, 2f, -2f);
    }
    
    private void Update()
    {
        Create();
    }

    private void Create()
    {
        for (int i = 0; i < 4; i++)
        {
            if (spawnObject[i] == null)
            {
                if (level[i] < shapes.Length)
                {
                    spawnObject[i] = GameObject.Instantiate(shapes[level[i]], spawnPos[i], Quaternion.identity);
                    level[i]++;
                }
                else
                {
                    done[i] = true;
                }
                EventController.Instance.TriggerEvent("ShapeCreation", done[i]);
            }
        }
    }

}
