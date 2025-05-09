using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Coin"))
        {
            //싱글톤 인스턴스에 접근하여 점수 추가
            GameManager.Instance.AddScore(10);
            Destroy(collision.gameObject);
        }
    }
}
