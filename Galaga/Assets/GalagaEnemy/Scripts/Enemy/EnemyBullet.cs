using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = default;
    private Rigidbody rigid = default;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * speed;

        Destroy(gameObject, 15.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("적의 총알이 무언가와 충돌");
        if (other.tag == ("Player"))
        {
            Debug.Log("적의 총알이 플레이어와와 충돌");

            PlayerController playercontroller = other.GetComponent<PlayerController>();

            if (playercontroller != null)
            {

                //수정 ssm
                Audio audio = FindObjectOfType<Audio>();

                audio.diePlayMusic();
                audio.diePlayMusic();


                //수정 ssm
                Debug.Log("플레이어 사망");

                playercontroller.Die();
            }

        }

    }
}
