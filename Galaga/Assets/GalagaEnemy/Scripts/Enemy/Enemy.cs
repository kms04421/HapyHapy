using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    // EnemyPisition 추척
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
        // 타겟 쫓아가는 로직 (EnemySpawner에서 생성한 EnemyPosition을 따라간다.)
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
        Debug.Log("적과 무언가와 충돌");
        if (other.tag == ("Player"))
        {
            Debug.Log("적과 플레이어 충돌");

            PlayerController playercontroller = other.GetComponent<PlayerController>();

            if (playercontroller != null)
            {
                //수정 ssm
                Audio audio = FindObjectOfType<Audio>();

                audio.diePlayMusic();

                //수정 ssm

                Debug.Log("적이 플레이어 살해");

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