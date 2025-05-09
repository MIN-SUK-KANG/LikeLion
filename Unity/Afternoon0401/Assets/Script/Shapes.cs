using UnityEngine;

public class Shapes : MonoBehaviour
{
    private int round;
    private bool isColiding = false;

    Vector3 thisPos;

    void Start()
    {
        round = GameManager.Instance.getRound();
    }

    void Update()
    {
        thisPos = gameObject.transform.position;

        if (round == 0)
        {
            if ( EventController.Instance.TriggerEvent("Fallcheck", thisPos.y) )
            {
                Destroy(gameObject);
            }
        }
        else if (round == 1)
        {
            if ( EventController.Instance.TriggerEvent("PushAndBack", isColiding) )
            {
                FindAnyObjectByType<Player>().taskComplete();
                Destroy(gameObject);
            }
        }
        else if (round == 2)
        {
            if ( EventController.Instance.TriggerEvent("ShapeDestroyed", isColiding) )
            {
                // 팩토리에 삭제를 전달

                Destroy(gameObject);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == "Goal" )
        {
            isColiding = true;
        }
    }
}
