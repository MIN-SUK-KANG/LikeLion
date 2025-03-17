using UnityEngine;

public class Homing : MonoBehaviour
{
    public GameObject target;  //플레이어
    public float Speed = 3f;
    Vector2 dir;
    Vector2 dirNo;

    void Start()
    {
        //플레이어 태그로 찾기
        target = GameObject.FindGameObjectWithTag("Player");
        //Unity 인스펙터가 아니라 직접 찾는 이유: Prefab에서 Hierarchy를 찾으면 안된다

        //A - B  A바라보는 벡터     플레이어 - 미사일 
        dir = target.transform.position - transform.position;
        //방향벡터만 구하기 단위벡터 정규화 노말 1의 크기로 만든다. 총알 속도 고정용.
        dirNo = dir.normalized;
    }

    void Update()
    {
        transform.Translate(dirNo * Speed * Time.deltaTime);

        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }



}