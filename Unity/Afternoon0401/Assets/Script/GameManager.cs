using UnityEngine;
using UnityEngine.SceneManagement;

// Design Pattern [1] Singleton.
// 싱글톤 패턴. 해당 프로젝트, 프로그램 내에 언제나 유일하게 존재한다.
// 프로그램 내부에서 다른 프로그램을 불러오도록 해 외부 프로그램이 싱글톤처럼 사용되는 방법,
// 생성이나 파괴가 불가능하도록 물리적인 저장공간을 분리하는 방법을 비롯해 여러가지 방식이 있지만
// 수업에서 교육한, 또한 아래에서 사용된 코드는 '이 스크립트의 인스턴스가 1개만 존재할 수 있도록' 설계하는 방식이다.

// 이 아래의 순서로 진행된다.


/*
 [해당 오브젝트를 가져오라는 명령]

 =============저장된 오브젝트가 없을 경우=============
  -> [기록된 오브젝트가 없다면 본 씬에서 찾아내 저장]
  -> [본 씬에서 찾을 수 없다면 아예 새로 생성해 저장]
 =====================================================

 -> 저장된 오브젝트를 return

----------------------------------------------------------------------------------------------------

 [해당 오브젝트의 첫 생성시]
 
 이미 '다른 인스턴스'가 있다면 새로 생성되는 자신을 제거, 기존 오브젝트를 유지.
 본 카테고리의 인스턴스가 아예 없거나, 이미 자신이 싱글톤으로 지정되었다면 자신을 싱글톤으로 지정.

 이미 자신이 지정된 상태에서 다시 지정하는 이유는, 만일 씬이 변경되는 등의 이유로 호출되었다면 저장 위치를 초기화하기 위해서.

 이후 자신이 씬 전환에도 삭제되지 않도록 설정한다.
 사용된 코드는 DontDestroyOnLoad(gameObject);로, 단순히 DontDestroy만 설정하는 내장 함수가 없다는 이유 뿐 아니라
 Unity 내에는 오류 발생률을 줄이기 위해 씬 종료시 삭제 외에도 '새 씬이 시작될 때 씬에 할당되지 않은 공간을 비운다'는 기능도 있기 때문.

 */


// 수업 내용은 여기까지였으며, 이 내용이 싱글톤의 기본적인 구조다.
// 다만 씬 종료 및 생성시 삭제되지 않는 처리로 인해, 유니티 플레이모드를 종료해도 인스턴스가 남아있게 된다.
// 이를 해결하고자 추가한 함수가 OnApplicationQuit() 내장 메서드로, 플레이모드 종료시 모든 오브젝트에 호출되는 Unity 함수에 해당한다.
// 해당 메서드를 통해 아예 플레이모드를 종료했다면 GameManager도 제거하도록 설정.

public class GameManager : MonoBehaviour
{
    private float[] timer = new float[3] { 0f, 0f, 0f };
    private float nowtime = 0f;

    private int round = 0;
    private bool isStart = false;

    private GameObject player = null;

    // 싱글톤 인스턴스를 저장할 정적 변수
    private static GameManager _instance;
    // 외부에서 인스턴스에 접근할 수 있는 프로퍼티
    public static GameManager Instance
    {
        get
        {
            // 인스턴스가 없으면 찾아보기
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<GameManager>();
                // 씬에서도 찾을 수 없으면 새로 생성
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("GameManager");
                    _instance = singletonObject.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    //게임 시작 시 호출
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        //이 인스턴스를 싱글톤으로 설정
        _instance = this;
        //씬 전환시에도 유지
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {

        if (player == null) player = GameObject.FindGameObjectWithTag("Player");
        if (isStart) nowtime += Time.deltaTime;
    }
    private void OnApplicationQuit()
    {
        // 유니티 플레이모드 종료시 싱글톤 제거, 없으면 not cleaned up 에러 발생
        Destroy(gameObject);
    }


    // 이하의 코드들은 현재 라운드를 표기하고, 플레이 시간을 기록하기 위해 작성되었으며,
    // 그에 맞춰 다른 오브젝트 및 스크립트들이 자신의 행동을 if분기로 변경할 수 있다.

    // 단순히 예시용으로 만든 코드이기 때문에 무조건 0라운드로 시작하지만,
    // 대규모 스테이지 게임을 만들고자 한다면 씬 실행시 현재 씬 명칭을 가져와 현재 라운드를 체크하는 방식으로 만들어야 할 것이다.

    public void RoundStart()
    {
        isStart = true;
        Debug.Log("Round " + round + " 시작");
    }
    public void RoundEnd()
    {
        isStart = false;
        Debug.Log("Round " + round + " 클리어 시간 : " + nowtime.ToString("F3") );
        timer[round] = nowtime;
        round++;
        nowtime = 0f;

        if (round == 3)
        {
            Debug.Log("3라운드 전체 종료 완료.");
            Debug.Log("총합 : " + (timer[0] + timer[1] + timer[2]).ToString("F3") );
        }

        string sceneName = "Stage" + round;
        if(round < 3)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
    public int getRound()
    {
        return round;
    }


}