using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip musicClip; // ����� ����� Ŭ��
    public AudioClip diemusicClip; // ����� ����� Ŭ��
    public AudioClip catDie;
    public AudioClip Attack;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // AudioSource ������Ʈ ��������
        audioSource.clip = musicClip; // ����� Ŭ�� �Ҵ�



    }

   void Update()
   {

         // �����̽��ٸ� ������ �뷡 ���



   }

   public void PlayMusic()
   {
        
       // audioSource.Play(); // �뷡 ���
   }



   public void diePlayMusic()
   {

 
        audioSource.clip = diemusicClip; // ����� Ŭ�� �Ҵ�
        audioSource.Play(); // �뷡 ���*/
    }
    public void CatdieMusic()
    {

        audioSource.PlayOneShot(catDie); // �뷡 ���*/
    }
    public void AttackMusic()
    {

        audioSource.PlayOneShot(Attack); // �뷡 ���*/
    }
}
