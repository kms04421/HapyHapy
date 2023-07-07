using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawner : MonoBehaviour
{
    // Prefab 가져오기
    public GameObject enemyPrefab;
    public GameObject enemyPositionPrefab;

    public string enemyTag = "Enemy";


    // 첫번째로 스폰될 적의 위치 기준점 (가장 좌측 상단)
    public Vector3 spawnPosition = new Vector3(-11.5f, 0.5f, 22f);

    // 적들과 적들의 위치 배열 생성
    private GameObject[] enemyPositions;
    private GameObject[] enemies;

    // 적 스포너의 위치
    public Rigidbody enemySpawnerRigid = default;

    private int spawnCount = default;    // 스폰 카운트 
    public int EnemyValue = default;    // 적 수
    private float spawnRate = 0.1f; // 스폰 쿨타임
    private float timeAfterSpawn = default;
    private bool allEnemiesSpawned = false;



    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyPositions(); // 적들의 포지션 세팅
    }
    private void Update()
    {
        enemySpawnerRigid = transform.GetComponent<Rigidbody>();    // 스포너의 위치

        timeAfterSpawn += Time.deltaTime;   // 리스폰 측정하기위한 시간

        if (spawnCount < EnemyValue)           // 생성할 enemy 수
        {
            if (spawnRate <= timeAfterSpawn)    // 스폰 쿨타임이 지나면 리스폰
            {
            
                timeAfterSpawn = 0;         // 스폰 기준 시간 초기화

                enemies[spawnCount] = Instantiate(enemyPrefab, transform.position, Quaternion.identity);    // [spawnCount]번째의 적 생성
                enemies[spawnCount].tag = enemyTag;

                Enemy enemyFollow = enemies[spawnCount].GetComponent<Enemy>(); //Enemy 컴포넌트 불러오고 [spawnCount] 번째로 지정
                enemyFollow.target = enemyPositions[spawnCount].transform;      //[spawnCount]번째의 적 포지션으로 이동
                spawnCount++;
                // 카운트++
                if (spawnCount >= EnemyValue)
                    allEnemiesSpawned = true;

                spawnRate = 0.1f;
            }
        }
        if (allEnemiesSpawned && IsAllEnemiesDestroyed())
        {
            // 모든 포지션과 스포너 제거
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


    // 모든 적이 사라지는지 체크
    private bool IsAllEnemiesDestroyed()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
                return false;
        }
        return true;
    }

    // 모든 적이 사라지면 모든 enemyPositions 삭제
    private void DestroyEnemyPositions()
    {
        for (int i = 0; i < enemyPositions.Length; i++)
        {
            Destroy(enemyPositions[i]);
        }
    }
    // 모든 적을 죽이면 리셋
    private void ResetSpawner()
    {
        spawnCount = 0;
        allEnemiesSpawned = false;
        spawnPosition = new Vector3(-11.5f, 0.5f, 22f);
        EnemyValue += 10;

        SpawnEnemyPositions(); // 포지션 배열 다시 생성

    }
}