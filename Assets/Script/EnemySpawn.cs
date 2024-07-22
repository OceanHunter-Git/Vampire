using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public float spawnWaitTime;
    private float spawnCountDown;
    public Transform minSpawn;
    public Transform maxSpawn;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        spawnCountDown = spawnWaitTime;
        target = PlayerHealthController.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountDown -= Time.deltaTime;
        
        if (spawnCountDown < 0)
        {
            spawnCountDown = spawnWaitTime;
            Instantiate(enemyToSpawn, SelectSpawnPosition(), transform.rotation);
        }
        transform.position = target.position;
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
}
