using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = default; //탄알 이동 속도

    //public float spawnRateMin = 3f;  //최소 생성 주기
    //public float spawnRateMax = 5f;    //최대 생성 주기

    private Rigidbody bulletRigidbody; //이동에 사용할 리지드바디 컴포넌트

    public PlayerController playeComponent;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("총알생성");

        bulletRigidbody = GetComponent<Rigidbody>(); //게임 오브젝트에서 rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody.velocity = transform.forward * speed; // 리지드바디의 속도 = 앞쪽 방향 * 이동 속력
      
        //int type = playeComponent.weaponType;
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //playeComponent = new PlayerController(); // 다른 스크립트의 인스턴스 생성
        int type =  playeComponent.SomeMethod();
        Debug.Log(type);
        //wall에 닿으면
        if (other.tag.Equals("Wall"))
        {
            Debug.Log("총알이 벽과 만났다.");

            //총알 파괴
            Destroy(gameObject);
        }

        //enemy에게 닿으면
        if (other.tag.Equals("Enemy"))
        {
            Debug.Log("총알이 적과 만났다.");
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                //수정 ssm
                Audio audio = FindObjectOfType<Audio>();

                audio.CatdieMusic();
                audio.CatdieMusic();

                //수정 ssm
                Destroy(other.gameObject); // 적 오브젝트 삭제
                if(type != 1)
                {
                    Destroy(gameObject); // 총알 삭제
                    GameManager gameManager = FindObjectOfType<GameManager>();
                    gameManager.AddScore(5);
                }
                

            }
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
    
    
}
