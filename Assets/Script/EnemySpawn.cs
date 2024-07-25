using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    public float spawnWaitTime;
    private float spawnCountDown;
    public Transform minSpawn;
    public Transform maxSpawn;
    private Transform target;
    public int checkPerFream;
    private int enemyToCheck;
    private float despawnDistance;

    public List<waveInfo> waves;
    private int currentWave;
    private float waveCounter;
    // Start is called before the first frame update
    void Start()
    {
        
        target = PlayerHealthController.instance.transform;
        despawnDistance = Vector3.Distance(transform.position, maxSpawn.position) + 4f;
        currentWave = -1;
        ToNextWave();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerHealthController.instance.gameObject.activeSelf)
        {
            if (currentWave < waves.Count)
            {
                waveCounter -= Time.deltaTime;

                if (waveCounter <= 0)
                {
                    ToNextWave();
                }

                spawnCountDown -= Time.deltaTime;

                if (spawnCountDown <= 0)
                {

                    spawnCountDown = spawnWaitTime;
                    GameObject newEnemy = Instantiate(waves[currentWave].enemyToSpawn, SelectSpawnPosition(), Quaternion.identity);

                    spawnedEnemies.Add(newEnemy);
                }

            }
        }

        transform.position = target.position;

        int checkTarget = enemyToCheck + checkPerFream;

        while (enemyToCheck < checkTarget)
        {
            if (enemyToCheck < spawnedEnemies.Count)
            {
                if (spawnedEnemies[enemyToCheck] != null)
                {
                    if(Vector3.Distance(transform.position, spawnedEnemies[enemyToCheck].transform.position) > despawnDistance)
                    {
                        Destroy(spawnedEnemies[enemyToCheck]);
                        spawnedEnemies.RemoveAt(enemyToCheck);
                        checkTarget--;
                    }
                    else
                    {
                        enemyToCheck++;
                    }
                }
                else
                {
                    spawnedEnemies.RemoveAt(enemyToCheck);
                    checkTarget--;
                }
            }
            else
            {
                enemyToCheck = 0;
                checkTarget = 0;
            }
        }
    }
    private Vector3 SelectSpawnPosition()
    {
        Vector3 spawnPoint = Vector3.zero;
        bool spawnVerticalEdge = UnityEngine.Random.Range(0f, 1f) > 0.5f;
        if (spawnVerticalEdge)
        {
            spawnPoint.y = UnityEngine.Random.Range(minSpawn.position.y, maxSpawn.position.y);

            if (UnityEngine.Random.Range(0f,1f) > 0.5f)
            {
                spawnPoint.x = maxSpawn.position.x;
            }
            else
            {
                spawnPoint.x = minSpawn.position.x;
            }
            
        }
        else
        {
            spawnPoint.x = UnityEngine.Random.Range(minSpawn.position.x, maxSpawn.position.x);

            if (UnityEngine.Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.y = maxSpawn.position.y;
            }
            else
            {
                spawnPoint.y = minSpawn.position.y;
            }
        }
        return spawnPoint;
    }
    private void ToNextWave()
    {
        currentWave++;

        if (currentWave == waves.Count)
        {
            currentWave = waves.Count - 1;
        }
        waveCounter = waves[currentWave].waveLength;
        spawnWaitTime = waves[currentWave].timeBetweenWave;
    }
}

[System.Serializable]
public class waveInfo
{
    public GameObject enemyToSpawn;
    public float waveLength;
    public float timeBetweenWave;
}
