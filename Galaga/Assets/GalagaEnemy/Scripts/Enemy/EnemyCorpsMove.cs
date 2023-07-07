using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCorpsMove : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    private Vector3 enemyCorpsPosition = Vector3.zero;



    bool moveCheck = default;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveCheck == true)
        {
            enemyCorpsPosition.x = -moveSpeed * Time.deltaTime;
            transform.Translate(enemyCorpsPosition);

            if (transform.position.x <= -3f)
            {
                moveCheck = false;
            }
        }
        else if (moveCheck == false)
        {
            enemyCorpsPosition.x = moveSpeed * Time.deltaTime;
            transform.Translate(enemyCorpsPosition);

            if (transform.position.x >= 3f)
            {
                moveCheck = true;
            }
        }

    }
}
