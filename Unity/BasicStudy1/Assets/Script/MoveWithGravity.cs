using UnityEngine;

public class MoveWithGravity : MonoBehaviour
{
    public Rigidbody rb;

    public float jumpForce = 5.0f;  //점프력


    void Start()
    {
        
    }



    void Update()
    {
        //스페이스를 누르면 점프

        //GetKey: 누르고 있는 동안
        //GetKeyDown: 누르는 순간 (1회성)
        //GetKeyUP: 눌렀다 떼는 순간 (1회성)

        //1회성 입력과 꾹 누르고 있어야 할 때를 구분하는 코드같은것도 가능

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Rigidbody: 물리효과를 추가해 중력을 적용합니다.
            //AddForce: 점프를 위해 오브젝트에 힘을 줍니다.
            //ForceMode.Impulse: 순간적으로 힘을 가하는 옵션.

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
    }
}
