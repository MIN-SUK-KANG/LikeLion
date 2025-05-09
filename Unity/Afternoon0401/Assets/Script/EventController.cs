using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Design Pattern [2] Observer.
// 옵저버 패턴. Subject와 Observer가 대응되어, Subject에 모든 이벤트가 저장되고 Observer는 파악만 한다.
// 본 스크립트 역시 싱글톤 구조를 사용했으나 해당 설명은 GameManager 스크립트로.

// 이벤트 발생 주체 (Subject)
// 다만, 본 예제에서는 수신자(Observer)가 이벤트를 생성.

// 생성된 EventController에 전달, 저장되기에 Player가 이벤트를 EventController에서 실행시키는 것은 맞다.
// 다만 본 스크립트에 저장되는것은 '해당 메서드의 내용과 위치'로 보아야 한다.
// 즉 단순히 Subject : Object의 1:1 대응이 아니라, '행동 주체'가 또다시 분리된 형태.

// Player나 Prefab이 행동하면, EventController가 해당 이벤트를 파악, 대상을 보유한 수신자에게 이벤트 실행을 지시한다.
// 어떤 면에서 보면 이러한 행동 주체들이 수신자나 다름없을지도...?

// 수신자는 씬마다 변경되지만 본 발생자(Subject)는 동일하도록 싱글톤으로 구현.

// 일반적인 옵저버 시스템일 경우 이벤트 발생 주체 내에 모든 이벤트를 정의해두고,
// 수신자는 이벤트 발생 주체에 등록된 이벤트를 수신하는 방식.

// 이 예제에서는 본래 수신자 역할만 해야 할 수신자를 '각 씬마다 할당된 이벤트 관리자'로 만들어
// 이벤트 발생 주체에게 이벤트를 전달하는 방식으로 구현.
public class EventController : MonoBehaviour
{
    // 싱글톤 구현
    private static EventController _instance;
    public static EventController Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("EventController");
                _instance = go.AddComponent<EventController>();
            }
            return _instance;
        }
    }
    //게임 시작 시 호출
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        //이 인스턴스를 싱글톤으로 설정
        _instance = this;
        //씬 전환시에도 유지
        DontDestroyOnLoad(gameObject);
    }
    private void OnApplicationQuit()
    {
        // 유니티 플레이모드 종료시 싱글톤 제거, 없으면 not cleaned up 에러 발생
        Destroy(gameObject);
    }

    // 이벤트와 옵저버를 연결하는 딕셔너리.

    // 정확히는, Predicate<object>라는 이벤트를 이 스크립트에서 딕셔너리로 저장해두는 것으로
    // 다른 클래스에서 이벤트를 발생시키고자 할 경우 이 딕셔너리에서 해당 이벤트를 찾아서 실행시키는 방식.

    // Predicate<object>란, 매개변수가 하나만 입력되며 bool을 반환하는 대리자(delegate)이다.
    // 대리자(delegate)란, 매서드를 매개변수로 전달해 다른 메서드에서 실행할 수 있도록 하는 것이다.
    // 예제 코드의 Action<object>는 반환값이 없는 메서드(void 함수)를 대상으로 삼는 대리자이다.
    // https://gapal.tistory.com/44 참조
    private Dictionary<string, Predicate<object>> _eventDictionary = new();

    // 딕셔너리에 이벤트(옵저버) 추가
    public void AddListener(string eventName, Predicate<object> listener)
    {
        if (_eventDictionary.TryGetValue(eventName, out Predicate<object> thisEvent))
        {
            thisEvent += listener;
            _eventDictionary[eventName] = thisEvent;
        }
        else
        {
            _eventDictionary.Add(eventName, listener);
        }
    }

    // 딕셔너리에서 이벤트(옵저버) 제거
    public void RemoveListener(string eventName, Predicate<object> listener)
    {
        if (_eventDictionary.TryGetValue(eventName, out Predicate<object> thisEvent))
        {
            thisEvent -= listener;
            _eventDictionary[eventName] = thisEvent;
        }
    }

    // 이벤트발생(모든 옵저버에게 알림)

    // object는 '모든 변수의 부모 클래스'로, 모든 변수를 받을 수 있다.
    // 이벤트 발생 주체에서 이벤트를 발생시키고자 할 경우 이 함수를 호출하면 된다.

    // 매개변수가 없는 이벤트도 발생시킬 수 있도록 초기값을 null로 설정. 변수가 없어도 알아서 입력된 object가 null인것으로 인식, 처리한다.
    // 다만 이는 해당 이벤트를 실행시키는 외부 오브젝트나 메서드가 기준이고, 옵저버에서 생성해 AddListener로 등록 할 때는 매개변수를 정확히 맞춰야 한다.

    // 주의할 점은 Predicate<object>로 정의된 상태이기에 매개변수가 하나인 이벤트만 발생시킬 수 있다.
    // Predicate는 매개변수 하나만 선언할 수 있으나, Action이나 Func의 경우 Action<object, object> 등으로 여러 변수를 받을 수 있다.

    // 다만 대리자의 형태와 무관하게, 대리자가 매개변수를 하나만 받는데 변수를 여럿 입력해야 하는 경우가 존재한다.
    // 이런 경우에는 object[]같은 Array나 List 등을 써서 하나의 변수로 묶어서 생성, 등록, 선언하는 것으로 해결 가능.

    // 이벤트 생성, 사용시에는 매개변수 정의시 object data로 선언하되 메서드 내부에서 (int)data 등의 방식으로 캐스팅하여 연산한다.
    // 본 컨트롤러 내에서 Predicate를 <object>로 받기 때문에 object로 선언되지 않으면 오류가 발생하기 때문.
    // 이런 식으로 object로 진행한다면, 이벤트 호출시 신경써서 이벤트 원본이 존재하는 스크립트를 확인하고 변수 타입을 맞출 필요가 있다.

    // https://gapal.tistory.com/44 참조
    // Predicate<object> 대신 Func<object, bool>로도 대체 가능하다.
    public bool TriggerEvent(string eventName, object data = null)
    {
        if (_eventDictionary.TryGetValue(eventName, out Predicate<object> thisEvent))
        {
            return thisEvent.Invoke(data);
        }
        else
        {
            return false;
        }
    }


}
