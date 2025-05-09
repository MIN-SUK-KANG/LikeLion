using Photon.Pun;
using UnityEngine;

public class NetPaddle : MonoBehaviourPun
{

    public float speed = 10f;

    void Update()
    {
        if (photonView.IsMine) //자기자신 플레이하는 주체 네트워크는 자기자신컨트롤하느냐 다른 플레이어 컨트롤하느냐 이걸 고민해줘야한다.
        {
            float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.Translate(0, move, 0);
        }
    }
}
