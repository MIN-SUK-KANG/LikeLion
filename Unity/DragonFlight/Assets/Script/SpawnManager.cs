using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //몬스터 가져오기. 오브젝트는 Unity에서 집어넣기.
    public GameObject enemy;


    void SpawnEnemy()
    {
        float randomX = Random.Range(-2f, 2f);  //적이 나타날 x좌표 랜덤지정

        //적 생성, (랜덤x좌표 현재y고정 0z고정), 회전 없음
        Instantiate(enemy, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
    }

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 0.5f);
    }


    void Update()
    {
        
    }
}
