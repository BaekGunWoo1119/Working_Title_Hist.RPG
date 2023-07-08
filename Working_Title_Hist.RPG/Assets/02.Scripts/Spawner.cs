using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public PoolManager pool;
    public Transform[] spawnPoint;

    float SpawnTime = 100.0f;
    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        SpawnTime += Time.deltaTime;

        if(SpawnTime > 1.0f)
        {
            SpawnTime = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject Monster = pool.Get(Random.Range(0, 1));
        Monster.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].transform.position;
    }
}
