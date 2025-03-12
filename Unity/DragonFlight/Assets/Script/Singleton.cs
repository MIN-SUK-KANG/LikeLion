using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }

    void Awake()    //인스턴스 로드 중 호출, Start보다 빠름
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  //씬이 바뀌어도 유지
        }
        else
        {
            Destroy(gameObject);    //중복생성 방지
        }
    }
    public void PrintMessage()
    {
        Debug.Log("싱글톤 메시지 출력!");
    }


}
