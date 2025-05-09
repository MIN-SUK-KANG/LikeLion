using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    private bool isStart = false;
    private bool taskDone = false;

    private void Start()
    {
    }

    // 키 입력 발생시 GameManager의 RoundStart()를 실행
    private void Update()
    {
        // 방향키에따른 움직임
        float moveX = Time.deltaTime * Input.GetAxis("Horizontal");
        float moveZ = Time.deltaTime * Input.GetAxis("Vertical");

        // 플레이어의 충돌로 방향이 변하면 가로세로 축도 변하므로, (0,0,0)으로 회전시키기.

        // transform.rotation = Quaternion.Euler(Vector3.zero);로 하면 그냥 (0,0,0) 방향으로 오브젝트가 즉시 변경되므로,
        // 부드럽게 회전시키기 위해 Quaternion.RotateTowards을 사용.

        // 1번째 인자는 시작 각도, 2번째 인자는 목표 각도.
        // 1번 인자에 들어간 시작 각도로 오브젝트가 즉시 변경되므로, transform.rotation으로 설정해야 오브젝트의 현재 각도를 가져올 수 있다.

        // 3번째 인자는 회전 속도로, RotateTowards 연산시 최대 해당 각도까지만 회전시킨다.
        // 60.0f * Time.deltaTime으로 하면 xyz 각도가 각각 초당 60도씩 회전 가능.

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.zero), 60.0f * Time.deltaTime);

        // 방향키를 입력해야 게임 시작으로 취급
        // Input.GetAxis를 if문 안에 그대로 넣을 경우 위 입력 이후 또다시 입력이 되어야 게임 시작으로 취급되므로
        // 이전에 입력된 값이 0이 아닌지 확인하는 형태로 구현하기 위해 moveX, moveZ 변수를 사용
        if (!isStart)
        {
            if (moveX != 0 || moveZ != 0)
            {
                isStart = true;
                GameManager.Instance.RoundStart();
            }
        }

        transform.Translate(moveX*3, 0, moveZ*3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            if ( GameManager.Instance.getRound() == 1 && EventController.Instance.TriggerEvent("PushAndBack", taskDone) )
            {
                taskDone = false;
            }
        }
    }

    public void taskComplete()
    {
        taskDone = true;
    }


}
