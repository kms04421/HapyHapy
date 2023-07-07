using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    // EnemyPisition ��ô
    public Transform target;
    public float moveSpeed = 5f;

    //bullet 
    public GameObject bulletPrefab = default;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    public Transform bulletPool = default;
    private Transform player = default;
    private float spawnRate = default;
    private float timeAfterSpawn = default;


    public GameObject Explosion;
    void Start() 
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        player = FindObjectOfType<PlayerController>().transform;

    }

    private void Update()
    {
        // Ÿ�� �Ѿư��� ���� (EnemySpawner���� ������ EnemyPosition�� ���󰣴�.)
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

        timeAfterSpawn += Time.deltaTime;
        transform.LookAt(player);

        if (spawnRate <= timeAfterSpawn)
        {
            timeAfterSpawn = 0;

            GameObject bullet = Instantiate(bulletPrefab,
                transform.position, transform.rotation);

            bullet.transform.LookAt(player);


            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("���� ���𰡿� �浹");
        if (other.tag == ("Player"))
        {
            Debug.Log("���� �÷��̾� �浹");

            PlayerController playercontroller = other.GetComponent<PlayerController>();

            if (playercontroller != null)
            {
                //���� ssm
                Audio audio = FindObjectOfType<Audio>();

                audio.diePlayMusic();

                //���� ssm

                Debug.Log("���� �÷��̾� ����");

                playercontroller.Die();
            }

        }


        if (other.tag.Equals("PlayerBullet"))
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);

        }



    }
}