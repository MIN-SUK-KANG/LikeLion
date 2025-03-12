using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    //스크롤할 속도를 상수로 지정해 줍니다.
    public float scrollSpeed = 1.2f;
    //쿼드의 머터리얼 데이터를 받아올 객체를 선언합니다.
    private Material thisMaterial;

    void Start()
    {
        //객체 생성시 최초 1회 호출
        //현재 객체의 Component들을 참조, Renderer 컴포넌트에서 material 정보를 받아옵니다.
        thisMaterial = GetComponent<Renderer>().material;
        
    }
    void Update()
    {
        //새롭게 지정해줄 Offset 객체를 선언
        Vector2 newoffset = thisMaterial.mainTextureOffset;
        //y값에 현재 y값 및 프레임, 속도 보정 추가
        newoffset.Set(0, newoffset.y + (scrollSpeed * Time.deltaTime));
        //최종적으로 offset값을 지정해 줍니다.
        thisMaterial.mainTextureOffset = newoffset;
    }

}
