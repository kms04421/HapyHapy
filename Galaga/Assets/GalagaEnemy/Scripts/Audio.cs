using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip musicClip; // 재생할 오디오 클립
    public AudioClip diemusicClip; // 재생할 오디오 클립
    public AudioClip catDie;
    public AudioClip Attack;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // AudioSource 컴포넌트 가져오기
        audioSource.clip = musicClip; // 오디오 클립 할당



    }

   void Update()
   {

         // 스페이스바를 누르면 노래 재생



   }

   public void PlayMusic()
   {
        
       // audioSource.Play(); // 노래 재생
   }



   public void diePlayMusic()
   {

 
        audioSource.clip = diemusicClip; // 오디오 클립 할당
        audioSource.Play(); // 노래 재생*/
    }
    public void CatdieMusic()
    {

        audioSource.PlayOneShot(catDie); // 노래 재생*/
    }
    public void AttackMusic()
    {

        audioSource.PlayOneShot(Attack); // 노래 재생*/
    }
}
