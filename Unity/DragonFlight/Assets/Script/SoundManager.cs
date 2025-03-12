using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;    //자기자신을 변수로 담기

    AudioSource myAudio;    //AudioSource 컴포넌트를 변수로 담기
    public AudioClip SoundBullet;   //재생할 발사음
    public AudioClip soundDie;      //재생할 적 처치음

    void Awake()
    {
        if(SoundManager.Instance == null)
        {
            SoundManager.Instance = this;
        }
    }
    void Start()
    {
        myAudio = GetComponent<AudioSource>();  //AudioSource 컴포넌트 가져와서 변수에 저장
    }


    public void PlayBulletSound()
    {
        myAudio.PlayOneShot(SoundBullet);
    }
    public void SoundDie()
    {
        myAudio.PlayOneShot(soundDie);  //몬스터 처치 사운드 1회 실행
    }


    void Update()
    {
        
    }
}
