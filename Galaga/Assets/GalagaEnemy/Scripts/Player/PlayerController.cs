using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Quaternion quaternion = Quaternion.identity;
    private Rigidbody playerRigid;
    public float speed = 5f;

    public GameObject bulletPrefab;
    public float fireRate = 0.2f;   // 발사 간격 (초)
    private float fireTimer = 0f;   // 발사 타이머

    List<Weapon> weapons = new List<Weapon>();
    int weaponType = 0;

    private void Start()
    {
        //수정 ssm
        Audio audio = FindObjectOfType<Audio>();
        audio.PlayMusic();
        //수정 ssm


        playerRigid = GetComponent<Rigidbody>();
        weapons.Add(new Weapon("rifle", 1, 0.2f));
        weapons.Add(new Weapon("Sniper", 1, 1.2f));
        weapons.Add(new Weapon("Shotgun", 6, 0.8f));
      
    }
  
  
    private void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigid.velocity = newVelocity;

      

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponType = 0;
            SomeMethod();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponType = 1;
            SomeMethod();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponType = 2;
            SomeMethod();
        }



        // 총 발사 로직
        fireTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && fireTimer >= weapons[weaponType].BulletRate || Input.GetButton("Jump") && fireTimer >= weapons[weaponType].BulletRate)
        {
            for(int i =0; i < weapons[weaponType].Bullets; i++)
            {
                Vector3 newRotation = new Vector3(0f, -1f*i+2, 0f); //
                Quaternion quaternionRotation = Quaternion.Euler(newRotation);

                FireBullet(quaternionRotation);
                fireTimer = 0f;
            }

            //수정 ssm
            Audio audio = FindObjectOfType<Audio>();
            audio.AttackMusic();

            //수정 ssm

        }
    }

    private void FireBullet(Quaternion quaternionRotation)
    {
        
        GameObject bullet = Instantiate(bulletPrefab, transform.position, quaternionRotation);
        PlayerBullet bulletControler = bullet.GetComponent<PlayerBullet>();
        bulletControler.playeComponent = this;
        // 총알 발사 로직
    }

    public void Die()
    {


        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
        gameManager.gameoverText.SetActive(true);
        gameObject.SetActive(false);

        //GameManager gameManager = FindObjectOfType<GameManager>();
        //gameManager.EndGame();
    }

    public int SomeMethod()
    {
        return weaponType;
    }
}
