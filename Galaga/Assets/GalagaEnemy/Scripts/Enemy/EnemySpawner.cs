using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawner : MonoBehaviour
{
    // Prefab ��������
    public GameObject enemyPrefab;
    public GameObject enemyPositionPrefab;

    public string enemyTag = "Enemy";


    // ù��°�� ������ ���� ��ġ ������ (���� ���� ���)
    public Vector3 spawnPosition = new Vector3(-11.5f, 0.5f, 22f);

    // ����� ������ ��ġ �迭 ����
    private GameObject[] enemyPositions;
    private GameObject[] enemies;

    // �� �������� ��ġ
    public Rigidbody enemySpawnerRigid = default;

    private int spawnCount = default;    // ���� ī��Ʈ 
    public int EnemyValue = default;    // �� ��
    private float spawnRate = 0.1f; // ���� ��Ÿ��
    private float timeAfterSpawn = default;
    private bool allEnemiesSpawned = false;



    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyPositions(); // ������ ������ ����
    }
    private void Update()
    {
        enemySpawnerRigid = transform.GetComponent<Rigidbody>();    // �������� ��ġ

        timeAfterSpawn += Time.deltaTime;   // ������ �����ϱ����� �ð�

        if (spawnCount < EnemyValue)           // ������ enemy ��
        {
            if (spawnRate <= timeAfterSpawn)    // ���� ��Ÿ���� ������ ������
            {
            
                timeAfterSpawn = 0;         // ���� ���� �ð� �ʱ�ȭ

                enemies[spawnCount] = Instantiate(enemyPrefab, transform.position, Quaternion.identity);    // [spawnCount]��°�� �� ����
                enemies[spawnCount].tag = enemyTag;

                Enemy enemyFollow = enemies[spawnCount].GetComponent<Enemy>(); //Enemy ������Ʈ �ҷ����� [spawnCount] ��°�� ����
                enemyFollow.target = enemyPositions[spawnCount].transform;      //[spawnCount]��°�� �� ���������� �̵�
                spawnCount++;
                // ī��Ʈ++
                if (spawnCount >= EnemyValue)
                    allEnemiesSpawned = true;

                spawnRate = 0.1f;
            }
        }
        if (allEnemiesSpawned && IsAllEnemiesDestroyed())
        {
            // ��� �����ǰ� ������ ����
            DestroyEnemyPositions();
            ResetSpawner();
        }

    }

    // Update is called once per frame
    void SpawnEnemyPositions()
    {
        enemyPositions = new GameObject[EnemyValue];
        enemies = new GameObject[EnemyValue];

        int enemyvalueTens = EnemyValue % 100;
        int enemyvalueUnits = EnemyValue % 10;

        if(enemyvalueUnits == 0)
        {
            enemyvalueUnits = 10;
        }


        for (int i = 0; i < enemyvalueTens; i++)
        {
            for (int j = 0; j < enemyvalueUnits; j++)
            {
                float x_positionNum = -11.5f + (j * 2.5f);
                float z_positionNum = 22f + (i * 3f);
                spawnPosition = new Vector3(x_positionNum, 0.5f, z_positionNum);

                enemyPositions[j+(i*10)] = Instantiate(enemyPositionPrefab, spawnPosition, Quaternion.identity);
                enemyPositions[j + (i * 10)].tag = enemyTag;

            }
        }
    }


    // ��� ���� ��������� üũ
    private bool IsAllEnemiesDestroyed()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
                return false;
        }
        return true;
    }

    // ��� ���� ������� ��� enemyPositions ����
    private void DestroyEnemyPositions()
    {
        for (int i = 0; i < enemyPositions.Length; i++)
        {
            Destroy(enemyPositions[i]);
        }
    }
    // ��� ���� ���̸� ����
    private void ResetSpawner()
    {
        spawnCount = 0;
        allEnemiesSpawned = false;
        spawnPosition = new Vector3(-11.5f, 0.5f, 22f);
        EnemyValue += 10;

        SpawnEnemyPositions(); // ������ �迭 �ٽ� ����

    }
}