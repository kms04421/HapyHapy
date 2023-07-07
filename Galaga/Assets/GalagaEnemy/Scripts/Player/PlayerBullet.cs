using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = default; //ź�� �̵� �ӵ�

    //public float spawnRateMin = 3f;  //�ּ� ���� �ֱ�
    //public float spawnRateMax = 5f;    //�ִ� ���� �ֱ�

    private Rigidbody bulletRigidbody; //�̵��� ����� ������ٵ� ������Ʈ

    public PlayerController playeComponent;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("�Ѿ˻���");

        bulletRigidbody = GetComponent<Rigidbody>(); //���� ������Ʈ���� rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody.velocity = transform.forward * speed; // ������ٵ��� �ӵ� = ���� ���� * �̵� �ӷ�
      
        //int type = playeComponent.weaponType;
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //playeComponent = new PlayerController(); // �ٸ� ��ũ��Ʈ�� �ν��Ͻ� ����
        int type =  playeComponent.SomeMethod();
        Debug.Log(type);
        //wall�� ������
        if (other.tag.Equals("Wall"))
        {
            Debug.Log("�Ѿ��� ���� ������.");

            //�Ѿ� �ı�
            Destroy(gameObject);
        }

        //enemy���� ������
        if (other.tag.Equals("Enemy"))
        {
            Debug.Log("�Ѿ��� ���� ������.");
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                //���� ssm
                Audio audio = FindObjectOfType<Audio>();

                audio.CatdieMusic();
                audio.CatdieMusic();

                //���� ssm
                Destroy(other.gameObject); // �� ������Ʈ ����
                if(type != 1)
                {
                    Destroy(gameObject); // �Ѿ� ����
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
