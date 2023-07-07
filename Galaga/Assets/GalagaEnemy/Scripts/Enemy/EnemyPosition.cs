using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    private Vector3 defaultPosition;
    private int moveStep = 0;
    private float zPosition = 1;

    void Start()
    {
        defaultPosition = transform.position;
    }

    void Update()
    {
        Vector3 newPosition = transform.position;

        switch (moveStep)
        {
            case 0: // 왼쪽으로 이동
                newPosition += Vector3.left * moveSpeed * Time.deltaTime;
                if (newPosition.x <= defaultPosition.x - 3f)
                {
                    moveStep++;
                }
                break;
            case 1: // 앞쪽으로 이동 
                newPosition += Vector3.back * moveSpeed * Time.deltaTime;
                if (newPosition.z <= defaultPosition.z - zPosition)
                {
                    moveStep++;
                    zPosition += 2;
                }
                break;
            case 2: // 오른쪽으로 이동
                newPosition += Vector3.right * moveSpeed * Time.deltaTime;
                if (newPosition.x >= defaultPosition.x + 3f)
                {
                    moveStep++;
                }
                break;
            case 3: // 앞쪽으로 이동 
                 newPosition += Vector3.back * moveSpeed * Time.deltaTime;
                if (newPosition.z <= defaultPosition.z - zPosition)
                {
                    moveStep = 0;
                    zPosition += 2;
                }
                break;
           
        }

        transform.position = newPosition;
    }

    public void ResetPosition()
    {
        transform.position = defaultPosition;
        moveStep = 0;
    }
}