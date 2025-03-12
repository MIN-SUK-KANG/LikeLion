using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //싱글톤 디자인패턴 응용하기 : static으로 자기자신 저장

    public static GameManager Instance;

    int score = 0;  //점수 저장 및 관리
    public Text ScoreText;  //using UnityEngine.UI를 통해 Text 객체 가져오기
    public Text StartText;  //게임 시작 전 3, 2, 1

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 0;
        StartCoroutine("StartGame");
    }

    IEnumerator StartGame()
    {
        int i = 3;

        while (i > 0)
        {
            StartText.text = i.ToString();

            //yield return new WaitForSeconds(1);
            yield return new WaitForSecondsRealtime(1); //게임이 멈춰도 동작하는 대기

            i--;

            if (i == 0)
            {
                StartText.gameObject.SetActive(false);  //UI감추기
                Time.timeScale = 1; //다시 시간 정상으로
            }
        }
    }



    public void AddScore(int num)
    {
        score += num;
        ScoreText.text = $"Score : {score}";
    }


}
