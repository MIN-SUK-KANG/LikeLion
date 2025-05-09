using UnityEngine;

// 이벤트 수신자 (Observer)
// 다만 본 예제에서는 수신자 역할보다는 이벤트 생성 및 매개가 주 역할.
// 여기서 이벤트를 생성해서 EventController에 전달하며,
// 싱글톤 구조가 없으므로 본 스크립트가 부착된 오브젝트는 씬이 바뀔 때 제거된다.

// 때문에 본 스크립트의 메서드들은 count 변수를 동일하게 쓰지만,
// 씬마다 Observer는 하나뿐이기에 씬 전환시 제거되고 다음 씬의 Observer GameObject에 새로이 본 스크립트가 생성된다.
// 즉 count = 0; 초기화가 매 씬마다 이루어지므로, 씬이 변화하면 0부터 시작하는 것.

// 관리 편의성상 Observer 스크립트 하나에 여러 개의 이벤트(메서드)를 전부 만들어두고,
// 현재 라운드에 따라 특정 이벤트만 저장하게 만들었으나,
// 실제로는 각 라운드마다 해당 메서드만 보유한 Observer 1, 2, 3 스크립트와 오브젝트가 따로 있는 것에 가깝다.


public class Observer : MonoBehaviour
{
    private int count = 0;
    private int round;
    private void Start()
    {
        round = GameManager.Instance.getRound();

        if (round == 0)
        {
            EventController.Instance.AddListener("Fallcheck", Fallcheck);
        }
        else if (round == 1)
        {
            EventController.Instance.AddListener("PushAndBack", PushAndBack);
        }
        else if (round == 2)
        {
            EventController.Instance.AddListener("ShapeDestroyed", ShapeDestroyed);
        }
    }
    private void Update()
    {
        if (round == 0)
        {
            if (count == 4)
            {
                GameManager.Instance.RoundEnd();
            }
        }
        else if (round == 1)
        {
            if (count == 2)
            {
                GameManager.Instance.RoundEnd();
            }
        }
        else if (round == 2)
        {
            if (count == 8)
            {
                GameManager.Instance.RoundEnd();
            }
        }
    }
    private void OnDestroy()
    {
        if(round == 0)
        {
            EventController.Instance.RemoveListener("Fallcheck", Fallcheck);
        }
        else if (round == 1)
        {
            EventController.Instance.RemoveListener("PushAndBack", PushAndBack);
        }
        else if (round == 2)
        {
            EventController.Instance.RemoveListener("ShapeDestroyed", ShapeDestroyed);
        }
    }


    // round 0 (Scene 1)에서 쓸 이벤트
    private bool Fallcheck(object data)
    {
        // object로 받아오지만 도형 오브젝트의 y좌표를 받아오므로 float로 캐스팅
        if ( (float)data < -5.0f )
        {
            killCount();
            Debug.Log($"0스테이지 해결 {count}/4");
            return true;
        }
        else
        {
            return false;
        }
    }

    // round 1 (Scene 2)에서 쓸 이벤트
    private bool PushAndBack(object data)
    {
        if ( (bool)data == true ) // 매개변수를 true로 입력할 경우
        {
            Debug.Log($"1스테이지 해결 {count}/2");
            killCount();
            return true;
        }
        else
        {
            return false;
        }
    }

    // round 2 (Scene 3)에서 쓸 이벤트
    private bool ShapeDestroyed(object data)
    {
        if ((bool)data == true) // 매개변수를 true로 입력할 경우
        {
            killCount();
            Debug.Log($"2스테이지 해결 {count}/8");
            return true;
        }
        else
        {
            return false;
        }
    }

    public void killCount()
    {
        count++;
    }



}
