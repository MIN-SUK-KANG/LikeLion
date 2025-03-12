using UnityEngine;

public class Enemy : MonoBehaviour
{
    //움직이는 속도를 정의
    public float moveSpeed = 1.3f;

    void Start()
    {
        
    }

    void Update()
    {
        //지정한 Axis를 통해 키의 방향을 판단하고 속도와 프레임 판정을 곱해 이동량을 정한다
        float distanceY = Time.deltaTime * moveSpeed;
        transform.Translate(0, -distanceY, 0);
    }

    //화면 밖으로 나가 카메라에서 보이지 않으면 호출된다.
    private void OnBecameInvisible()
    {
        Destroy(gameObject);    //객체를 삭제한다.
    }


}
