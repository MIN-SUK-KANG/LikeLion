using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 0.45f;
    public GameObject explosion;

    void Start()
    {
    }
    void Update()
    {
        transform.Translate(0, Time.deltaTime * moveSpeed, 0);
    }


    private void OnBecameInvisible()
    {
        //화면 밖으로 나가면 미사일 오브젝트 삭제
        Destroy(gameObject);
    }

    //2D충돌 트리거이벤트
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //미사일과 적이 부딫혔다
        //if (collision.gameObject.tag == "Enemy")
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Instantiate(explosion, transform.position, Quaternion.identity);    //폭발 이펙트 생성
            SoundManager.Instance.SoundDie();   //적 처치 음성

            Destroy(collision.gameObject);  //적지우기
            Destroy(gameObject);    //총알 = 자기자신 지우기

            GameManager.Instance.AddScore(10);  //점수 추가


        }


    }


}
