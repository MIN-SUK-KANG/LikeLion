using UnityEngine;


//5. 스테이트(State) 패턴

//스테이트 패턴은 객체의 내부 상태가 변경될 때 동작이 변경되도록 하는 패턴입니다.
//Unity에서는 캐릭터나 적의 AI 상태 관리에 매우 유용합니다.
public class StateMachine
{
    private IState currentState;

    public void ChangeState(IState newState)
    {
        currentState?.Exit();    //이전 상태의 Exit() 실행
        currentState = newState;  //새 상태로 변경
        currentState.Enter();     //새 상태의 Enter() 실행
    }

    public void Update()
    {
        currentState?.Update();    //현재 상태의 Update()실행
    }
}