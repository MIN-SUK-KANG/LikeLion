using UnityEngine;

public class MoveObject : MonoBehaviour
{

    public float speed = 5.0f;  //이동속도

    // Update is called once per frame
    void Update()
    {
        //키 입력에 따라 이동
        //float move = Input.GetAxis("Horizontal");

        //방향 * 속도 * 타임.델타타임
        //해당하는 방향을 지정 * 이동속도로 표현되는 단위시간당 이동거리 * 이동한 시간
        //Input.GetAxis로 받은 이동은 Vector3로 표현되는 3차원 벡터의 방향을 지정한다.
        //transform.Translate(Vector3.right * move * speed * Time.deltaTime);

        //Time.deltaTime은 fps에 대한 역수에 해당한다.
        //소비자 프레임에 비례한 연산으로 업데이트 속도와 연산을 자동 정리해주기에, 좀 더 프레임이 매끄럽게 된다.


        //x, y, z축에 대해 입력을 받아서 보내는 형태.
        //z축은 변화가 없도록 했기에 평면 이동이 특정 평면에 구속된다.
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //transform.position += move * speed * Time.deltaTime;

        //같은 방식이지만 y축에 대해 구속되어 xz 평면을 이동한다.
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //transform.position += move * speed * Time.deltaTime;
        transform.Translate(move * speed * Time.deltaTime);
        //내장된 함수로 처리
    }
}
