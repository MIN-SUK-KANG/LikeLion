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
            //�̱��� �ν��Ͻ��� �����Ͽ� ���� �߰�
            GameManager.Instance.AddScore(10);
            Destroy(collision.gameObject);
        }
    }
}
