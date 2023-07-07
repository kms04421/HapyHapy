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
        Debug.Log("���� �Ѿ��� ���𰡿� �浹");
        if (other.tag == ("Player"))
        {
            Debug.Log("���� �Ѿ��� �÷��̾�Ϳ� �浹");

            PlayerController playercontroller = other.GetComponent<PlayerController>();

            if (playercontroller != null)
            {

                //���� ssm
                Audio audio = FindObjectOfType<Audio>();

                audio.diePlayMusic();
                audio.diePlayMusic();


                //���� ssm
                Debug.Log("�÷��̾� ���");

                playercontroller.Die();
            }

        }

    }
}
